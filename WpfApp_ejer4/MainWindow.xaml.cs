using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp_ejer4.Models;
using WpfApp_ejer4.Services;
using System.Diagnostics;

namespace WpfApp_ejer4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // Instancia del servicio que se conecta a la API de Rick and Morty
    private readonly RickMortyService service = new RickMortyService();

    // Página actual que estás mostrando
    private int currentPage = 1;

    // Constructor principal de la ventana
    public MainWindow()
    {
        InitializeComponent(); // Inicializa la interfaz gráfica definida en XAML
        LoadCharacters(); // Carga la lista de personajes al iniciar
    }

    // Método que obtiene los personajes de la API y los muestra en el DataGrid
    private async void LoadCharacters()
    {
        // Obtiene la lista de personajes desde la API en la página actual
        List<RickMortyCharacter> characters = await service.GetCharactersAsync(currentPage);
        // Asigna la lista al DataGrid en la interfaz
        RickDataGrid.ItemsSource = characters;
        // Muestra en la consola de depuración la página actual y el total
        System.Diagnostics.Debug.WriteLine($"Página actual: {currentPage} / {service.TotalPages}");
    }


    // Evento al hacer clic en el botón "Siguiente"
    private void NextPage_Click(object sender, RoutedEventArgs e)
    {
        // Solo avanza si no estás en la última página
        if (currentPage < service.TotalPages)
        {
            currentPage++; // Incrementa el número de página
            LoadCharacters(); // Carga los personajes de la nueva página
        }
    }

    // Evento al hacer clic en el botón "Anterior"
    private void PreviousPage_Click(object sender, RoutedEventArgs e)
    {
        // Solo retrocede si no estás en la primera página
        if (currentPage > 1)
        {
            currentPage--; // Disminuye el número de página
            LoadCharacters(); // Carga los personajes de la nueva página
        }
    }

    // Evento cuando se selecciona un personaje en el DataGrid
    private void RickDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Verifica que haya un personaje seleccionado
        if (RickDataGrid.SelectedItem is RickMortyCharacter character)
        {
            // Crea una ventana de detalle con el personaje seleccionado
            var detailWindow = new CharacterDetailWindow(character);
            // Muestra la ventana como un cuadro de diálogo (bloquea la principal)
            detailWindow.ShowDialog();
        }
    }
}