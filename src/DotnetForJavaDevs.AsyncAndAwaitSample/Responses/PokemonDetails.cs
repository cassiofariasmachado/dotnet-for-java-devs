using System.Text.Json.Serialization;

namespace DotnetForJavaDevs.AsyncAndAwaitSample.Responses
{
    public class PokemonDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}