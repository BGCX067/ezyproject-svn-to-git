using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace G4.Core.Log
{
    public class LingToSqlTraceWriter : TextWriter
    {
        private BooleanSwitch logSwitch;

        public LingToSqlTraceWriter(string switchName)
        {
            logSwitch = new BooleanSwitch(switchName, switchName, "0");

        }
        public override Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }

        public override void Write(char value)
        {
            if (logSwitch.Enabled)
            {
                Trace.Write(value);
            }
        }

        public override void Flush()
        {
            Trace.Flush();
        }

        public override void Close()
        {
            Trace.Close();
        }
        
    }
}
