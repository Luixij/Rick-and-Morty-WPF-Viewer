using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WpfApp_ejer4.Models;

namespace WpfApp_ejer4.Services
{
    // Clase encargada de comunicarse con la API de Rick and Morty
    public class RickMortyService
    {

        // URL base de la API para obtener personajes
        private const string BaseUrl = "https://rickandmortyapi.com/api/character";

        // Cliente HTTP que se usa para hacer las peticiones
        private readonly HttpClient _httpClient;

        // Propiedad que almacena el número total de páginas (paginación de la API)
        public int TotalPages { get; private set; } = 1;

        // Constructor: inicializa el cliente HTTP
        public RickMortyService()
        {
            _httpClient = new HttpClient();
        }


        // Método principal que obtiene una lista de personajes de la página indicada
        public async Task<List<RickMortyCharacter>> GetCharactersAsync(int page = 1)
        {
            // Construye la URL con el número de página
            string url = $"{BaseUrl}?page={page}";

            try
            {
                // Realiza una solicitud GET a la API
                var response = await _httpClient.GetAsync(url);
                // Si la respuesta no fue exitosa, muestra el error y retorna lista vacía
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"❌ Error: {error}");
                    return new List<RickMortyCharacter>();
                }

                // Lee el contenido JSON devuelto por la API
                string json = await response.Content.ReadAsStringAsync();

                // Deserializa el JSON a un objeto de tipo RickMortyApiResponse
                var data = JsonSerializer.Deserialize<RickMortyApiResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                //  Guardamos el número total de páginas para control en el frontend
                TotalPages = data?.Info?.Pages ?? 1;

                // Devuelve la lista de personajes obtenida o una lista vacía si es null
                return data?.Results ?? new List<RickMortyCharacter>();
            }
            catch (Exception ex)
            {
                // Si ocurre un error en la conexión o procesamiento, lo muestra y retorna lista vacía
                System.Diagnostics.Debug.WriteLine($"❗ Error de red: {ex.Message}");
                return new List<RickMortyCharacter>();
            }
        }
    }
}