namespace G4.Mvc.HtmlHelpers
{
    public class ViewMessage
    {
        /// <summary>
        /// Message status enum
        /// </summary>
        public enum MessageStatusType { Information, Warning, Error }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>
        /// The type of the message.
        /// </value>
        public MessageStatusType MessageType { get; set; }
    }
}