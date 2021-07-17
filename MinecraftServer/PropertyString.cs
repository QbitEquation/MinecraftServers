using System;

namespace MinecraftServer
{
    public class PropertyString
    {
        public string Name { get; }
        public string Value { get; set; }
        private readonly string originalValue;
        public bool Matches => Value == originalValue;

        public PropertyString(string value)
        {
            string[] nameValue = value.Split('=');

            if (nameValue.Length == 0)
            {
                throw new Exception("NameValue length is zero.");
            }
            if (nameValue.Length > 2)
            {
                throw new Exception("NameValue length is greater than 2.");
            }

            if (nameValue.Length == 1)
            {
                nameValue = new string[2]
                {
                    nameValue[0],
                    string.Empty
                };
            }

            if (nameValue[1] == null)
            {
                nameValue[1] = string.Empty;
            }

            Name = nameValue[0];
            originalValue = nameValue[1];
            Value = nameValue[1];
        }

        public override string ToString()
        {
            return Name + '=' + Value;
        }
    }
}
