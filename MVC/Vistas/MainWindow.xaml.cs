using MVC.Controladores;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MVC.Modelos;
using MVC.Vistas;
using System.ComponentModel;

namespace MVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PersonaController controladorPersona;
        public MainWindow()
        {
            InitializeComponent();

            controladorPersona = new PersonaController();

            ActualizarDataGrid();
        }

        private void GuardarPersona(object sender, RoutedEventArgs e)
        {
            EditorPersona editor = new EditorPersona(null);
            editor.ShowDialog();
            ActualizarDataGrid();

            //Persona p = new Persona();

            //p.Nombre = txtNombre.Text;

            //var res = controladorPersona.RegistrarPersona(p);

            //if (res.HayError)
            //{
            //    MessageBox.Show(res.MensajeError);
            //}
            //else
            //{
            //    MessageBox.Show(res.Respuesta.Nombre);
            //    ActualizarDataGrid();
            //}            
        }

        private void ActualizarDataGrid()
        {
            dtgPersonas.ItemsSource = null;
            dtgPersonas.ItemsSource = controladorPersona.ObtenerTodos();
        }

        private void EditarPersona(object sender, RoutedEventArgs e)
        {
            var personaSeleccionada = dtgPersonas.SelectedItem as Persona;

            if(personaSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una persona para editar");
            }
            else
            {
                EditorPersona editor = new EditorPersona(personaSeleccionada);
                editor.ShowDialog();
                ActualizarDataGrid();
            }
        }
    }
}
