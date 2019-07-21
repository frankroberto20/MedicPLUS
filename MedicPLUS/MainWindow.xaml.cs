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
using MaterialDesignThemes;

namespace MedicPLUS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(uscInicio, 1);
            Panel.SetZIndex(uscPacientes, 0);
        }

        private void Pacientes_Click(object sender, RoutedEventArgs e)
        {
            Panel.SetZIndex(uscInicio, 0);
            Panel.SetZIndex(uscPacientes, 1);
            
        }

        private void Citas_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Videos_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
