using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;
using StructureMap;

namespace G4.WCF
{
    /// <summary>
    /// When applying this attribute to a service contract,
    /// the input and output messages will be logged.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageLoggingBehaviorAttribute : Attribute, IDispatchMessageInspector, IServiceBehavior, IEndpointBehavior
    {
        #region Private Members
        private long _idLogMessage;
        private const string ENABLEWCFLOG = "EnableWcfLog";
        #endregion

        #region IDispatchMessageInspector Members

        /// <summary>
        /// Will be executed after a request is received.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="channel">The channel.</param>
        /// <param name="instanceContext">The instance context.</param>
        /// <returns></returns>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">Throws a configuration exception if the environments don't match.</exception>
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            LogMessage(ref request, null);
            return null;
        }

        /// <summary>
        /// Will be executed before the reply is send.
        /// </summary>
        /// <param name="reply">The reply.</param>
        /// <param name="correlationState">State of the correlation.</param>
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            LogMessage(ref reply, _idLogMessage);
        }

        #endregion

        #region IServiceBehavior Members

        /// <summary>
        /// Adds the binding parameters.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host base.</param>
        /// <param name="endpoints">The endpoints.</param>
        /// <param name="bindingParameters">The binding parameters.</param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Applies the dispatch behavior.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host base.</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                {
                    epDisp.DispatchRuntime.MessageInspectors.Add(new MessageLoggingBehaviorAttribute());
                }
            }
        }

        /// <summary>
        /// Validates the specified service description.
        /// </summary>
        /// <param name="serviceDescription">The service description.</param>
        /// <param name="serviceHostBase">The service host base.</param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion

        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new MessageLoggingBehaviorAttribute());
        }

        public void Validate(ServiceEndpoint endpoint) { }

        #endregion

        #region Private Methods
        private void LogMessage(ref Message message, long? idMessage)
        {
            bool enableLog = bool.Parse(Core.Config.Setting.Get(ENABLEWCFLOG, false));
            if (enableLog)
            {
                string callingAddress = OperationContext.Current.IncomingMessageProperties["OriginalHttpRequestUri"] == null ? string.Empty : OperationContext.Current.IncomingMessageProperties["OriginalHttpRequestUri"].ToString();
                string operationName = string.Empty;
                if (!string.IsNullOrEmpty(callingAddress))
                {
                    operationName = callingAddress.Substring(callingAddress.LastIndexOf("/", StringComparison.Ordinal) + 1);
                }

                //foreach (var item in OperationContext.Current.IncomingMessageProperties)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format(" {0} - {1}", item.Key, item.Value));
                //}

                IWcfLogService logService = ObjectFactory.GetInstance<IWcfLogService>();
                string msg = MessageToString(ref message);
                if (logService != null)
                {
                    if (!idMessage.HasValue)
                        _idLogMessage = logService.LogRequest(operationName, callingAddress, msg);
                    else
                        logService.LogResponse(_idLogMessage, msg);
                }

            }
        }

        private WebContentFormat GetMessageContentFormat(Message message)
        {
            WebContentFormat format = WebContentFormat.Default;
            if (message.Properties.ContainsKey(WebBodyFormatMessageProperty.Name))
            {
                WebBodyFormatMessageProperty bodyFormat = (WebBodyFormatMessageProperty)message.Properties[WebBodyFormatMessageProperty.Name];
                format = bodyFormat.Format;
            }

            return format;
        }

        private string MessageToString(ref Message message)
        {
            WebContentFormat messageFormat = this.GetMessageContentFormat(message);
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = null;
            switch (messageFormat)
            {
                case WebContentFormat.Default:
                    // If we can't determine the message body format, we should ignore message body instead of creating the instance of writer object.
                    break;
                case WebContentFormat.Xml:
                    writer = XmlDictionaryWriter.CreateTextWriter(ms);
                    break;
                case WebContentFormat.Json:
                    writer = JsonReaderWriterFactory.CreateJsonWriter(ms);
                    break;
                case WebContentFormat.Raw:
                    // special case for raw, easier implemented separately
                    return this.ReadRawBody(ref message);
            }

            // Message body can't be determined, so writer object will be null.
            if (writer == null)
                return string.Empty;

            message.WriteMessage(writer);
            writer.Flush();
            string messageBody = Encoding.UTF8.GetString(ms.ToArray());

            // Here would be a good place to change the message body, if so desired.

            // now that the message was read, it needs to be recreated.
            ms.Position = 0;

            // if the message body was modified, needs to reencode it, as show below
            // ms = new MemoryStream(Encoding.UTF8.GetBytes(messageBody));

            XmlDictionaryReader reader;
            if (messageFormat == WebContentFormat.Json)
                reader = JsonReaderWriterFactory.CreateJsonReader(ms, XmlDictionaryReaderQuotas.Max);
            else
                reader = XmlDictionaryReader.CreateTextReader(ms, XmlDictionaryReaderQuotas.Max);

            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }

        private string ReadRawBody(ref Message message)
        {
            XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
            bodyReader.ReadStartElement("Binary");
            byte[] bodyBytes = bodyReader.ReadContentAsBase64();
            string messageBody = Encoding.UTF8.GetString(bodyBytes);

            // Now to recreate the message
            MemoryStream ms = new MemoryStream();
            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(ms);
            writer.WriteStartElement("Binary");
            writer.WriteBase64(bodyBytes, 0, bodyBytes.Length);
            writer.WriteEndElement();
            writer.Flush();
            ms.Position = 0;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(ms, XmlDictionaryReaderQuotas.Max);
            Message newMessage = Message.CreateMessage(reader, int.MaxValue, message.Version);
            newMessage.Properties.CopyProperties(message.Properties);
            message = newMessage;

            return messageBody;
        }
        #endregion
    }

    public class MessageLoggingBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(MessageLoggingBehaviorAttribute); }
        }

        protected override object CreateBehavior()
        {
            return new MessageLoggingBehaviorAttribute();
        }
    }
}
