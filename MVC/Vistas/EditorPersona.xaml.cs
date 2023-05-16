using MVC.Controladores;
using MVC.Modelos;
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

namespace MVC.Vistas
{
    /// <summary>
    /// Lógica de interacción para EditorPersona.xaml
    /// </summary>
    public partial class EditorPersona : Window
    {
        public Persona context { get; set; }
        private bool edicion;
        private PersonaController personaController;

        public EditorPersona(Persona p)
        {
            InitializeComponent();

            if (p == null)
            {
                context = new Persona();
                edicion = false;
            }
            else
            {
                context = p;
                edicion = true;
            }

            DataContext = context;

            personaController = new PersonaController();
        }
        //public EditorPersona()
        //{
        //    InitializeComponent();
        //    edicion = false;
        //    context = new Persona();

        //    DataContext = context;
        //}

        //public EditorPersona(Persona p)
        //{
        //    InitializeComponent();
        //    edicion = true;
        //    context = p;

        //    DataContext = context;
        //}

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            if (edicion)
            {
                personaController.Actualizar(context);
                Close();
            }
            else
            {
                personaController.RegistrarPersona(context);
                Close();
            }
            
        }
    }
}
