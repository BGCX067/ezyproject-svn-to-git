

namespace G4.Core.Config
{
    using System;
    public class ConsoleArgumentDecoder
    {
        protected string[] _args;

        public ConsoleArgumentDecoder(string[] args)
        {
            _args = args;
        }

        private string[] ArgArray(string option)
        {
            int start = 0, length = 0;
            if (_args.Length > 0)
                for (int i = 0; i < _args.Length; i++)
                {
                    if (_args[i].StartsWith("-") && _args[i].Length > 1 && _args[i].Substring(1) == option)
                    {
                        start = i + 1;
                        for (int j = 1; i + j < _args.Length; j++)
                        {
                            if (_args[i + j].StartsWith("-")) break;
                            length = j;
                        }
                        break;
                    }
                }

            string[] result = new string[length];
            if (length > 0)
                Array.Copy(_args, start, result, 0, length);

            return result;
        }

        public string Value(string option, string defaultValue)
        {
            string[] result = ArgArray(option);
            if (result.Length > 0)
                return result[0];
            else
                return defaultValue;
        }

        public bool Exist(string option)
        {
            for (int i = 0; i < _args.Length; i++)
                if (_args[i].StartsWith("-") && _args[i].Length > 1 && _args[i].Substring(1).Contains(option))
                    return true;
            return false;
        }
    }
}