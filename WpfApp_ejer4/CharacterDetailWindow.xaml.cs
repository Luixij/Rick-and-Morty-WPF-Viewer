using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp_ejer4.Models;

namespace WpfApp_ejer4
{
    /// <summary>
    /// Lógica de interacción para CharacterDetailWindow.xaml
    /// </summary>
    /// 

    // Clase parcial que representa la ventana de detalles del personaje
    public partial class CharacterDetailWindow : Window
    {

        // Constructor que recibe un objeto RickMortyCharacter
        public CharacterDetailWindow(RickMortyCharacter character)
        {
            InitializeComponent(); // Inicializa los componentes definidos en XAML

            // Asigna el nombre del personaje al TextBlock correspondiente
            CharacterName.Text = character.Name;

            // Asigna la descripción (especie + estado) al TextBlock
            CharacterDescription.Text = character.Description;

            try
            {
                // Intenta cargar la imagen del personaje desde la URL
                CharacterImage.Source = new BitmapImage(new Uri(character.ImageUrl));
            }
            catch
            {
                // Si hay un error al cargar la imagen, deja el control vacío (null)
                CharacterImage.Source = null;
            }
        }

        // Método que se ejecuta al hacer clic en el botón "Cerrar"
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana de detalles
        }
    }
}