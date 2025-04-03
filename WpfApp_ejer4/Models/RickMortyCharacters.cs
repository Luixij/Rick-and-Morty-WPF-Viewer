using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_ejer4.Models
{
    // Modelo principal que representa un personaje de Rick and Morty
    public class RickMortyCharacter
    {
        // Nombre del personaje
        public string Name { get; set; }

        // Estado del personaje (Alive, Dead, unknown)
        public string Status { get; set; }

        // Especie del personaje (Human, Alien, etc.)
        public string Species { get; set; }

        // URL de la imagen del personaje (devuelta por la API)
        public string Image { get; set; }

        // Propiedad calculada para mostrar una descripción combinada
        public string Description => $"{Species} - {Status}";

        // Propiedad de compatibilidad con la interfaz que espera ImageUrl
        public string ImageUrl => Image;
    }

    // Modelo de respuesta completa de la API de Rick and Morty
    public class RickMortyApiResponse
    {
        // Información sobre paginación (número de páginas, total de personajes)
        public Info Info { get; set; } 

        // Lista de personajes en esta página
        public List<RickMortyCharacter> Results { get; set; }
    }

    // Modelo que representa la sección "info" del JSON
    public class Info
    {
        // Cantidad total de personajes disponibles
        public int Count { get; set; }

        // Cantidad total de páginas disponibles
        public int Pages { get; set; }
    }
}