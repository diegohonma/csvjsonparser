using Newtonsoft.Json;

namespace CSVJsonParser.Domain
{
    public class Guest
    {
        public Guest(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }

        [JsonProperty(PropertyName = "E-mail")]
        public string Email { get; }

        public bool IsValid() => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Email);
    }
}
