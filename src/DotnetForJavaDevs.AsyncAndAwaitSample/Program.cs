using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DotnetForJavaDevs.AsyncAndAwaitSample.Extensions;
using DotnetForJavaDevs.AsyncAndAwaitSample.Responses;
using static System.Console;

namespace DotnetForJavaDevs.AsyncAndAwaitSample
{
    public class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string PokemonApiBaseAddres = "https://pokeapi.co/api/v2/";

        private static readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        static async Task Main(string[] args)
        {
            ConfigureHttpClient();

            var pokemons = await GetPokemons();

            WriteTitle("Listing some pokemons:");

            foreach (var pokemon in pokemons.Results)
            {
                WriteLine($"Pokemon: {pokemon.Name.ToPascalCase()}");
            }

            WriteTitle("Show Bulbasaur details:");

            var bulbasaur = await GetPokemon("bulbasaur");

            WriteLine(JsonSerializer.Serialize(bulbasaur, serializerOptions));
        }

        public void MeuMetodo()
        {
            throw new ArgumentException("Não preciso informar que estou lançando uma exceção!");
        }

        static void ConfigureHttpClient()
        {
            httpClient.BaseAddress = new Uri(PokemonApiBaseAddres);
        }

        static async Task<PagedResponse<Pokemon>> GetPokemons(int limit = 25, int offset = 0)
        {
            var response = await httpClient.GetAsync($"pokemon?limit={limit}&offset={offset}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<PagedResponse<Pokemon>>(json, serializerOptions);
        }

        static async Task<PokemonDetails> GetPokemon(string name)
        {
            var response = await httpClient.GetAsync($"pokemon/{name}");
            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<PokemonDetails>(json, serializerOptions);
        }

        static void WriteTitle(string title)
        {
            WriteLine();
            WriteLine(new string('-', 50));
            WriteLine(title);
            WriteLine(new string('-', 50));
            WriteLine();
        }
    }
}
