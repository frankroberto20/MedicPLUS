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
using System.IO;
using System.Collections.ObjectModel;
using MedicPLUS.classes;
using MedicPLUS.addwindows;

namespace MedicPLUS.usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlPacientes.xaml
    /// </summary>
    public partial class UserControlPacientes : UserControl
    {

        public static ObservableCollection<Paciente> Pacientes = new ObservableCollection<Paciente>();
        FileData fileData = new FileData();

        public static List<ListBoxItem> AntecedentesPersonalesMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> AntecedentesFamiliaresMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> MotivoConsultaMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> SignosSintomasMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> SegmentoAnteriorMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> AnexosMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> MediosMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> FondoOjoMainLst = new List<ListBoxItem>();
        public static List<ListBoxItem> TratamientoMainLst = new List<ListBoxItem>();

        public UserControlPacientes()
        {
            InitializeComponent();

            AntecedentesPersonalesMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.AntecedentesPersonales);
            AntecedentesFamiliaresMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.AntecedentesFamiliares);
            MotivoConsultaMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.MotivoConsulta);
            SignosSintomasMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.SignosSintomas);
            SegmentoAnteriorMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.SegmentoAnterior);
            AnexosMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.Anexos);
            MediosMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.Medios);
            FondoOjoMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.FondoOjo);
            TratamientoMainLst = DBManager.GetSourceRegistrosByCategoria(CategoriaRegistro.Tratamiento);

            Pacientes = DBManager.GetPacientes();
            DataGridPacientes.ItemsSource = Pacientes;
            
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            AgregarPacienteWindow window = new AgregarPacienteWindow();
            window.ShowDialog();
        }

        private void DataGridPacientes_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Registros")
            {
                //e.Column.Header = "Cantidad de Registros";
                e.Column.Visibility = Visibility.Collapsed;
                //e.ToString();
            }
        }

        private void SearchDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchFieldTextBox.Text = "";
        }

        private void SearchFieldTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchFieldTextBox.Text != "")
            {
                SearchDeleteBtn.Visibility = Visibility.Visible;
                DataGridPacientes.ItemsSource = Pacientes.Where(paciente => (paciente.Nombre.ToLower() + " " + paciente.Apellidos.ToLower()).Contains(SearchFieldTextBox.Text));
            }
            else
            {
                SearchDeleteBtn.Visibility = Visibility.Collapsed;
                DataGridPacientes.ItemsSource = Pacientes;
            }
                
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as DataGridRow).GetIndex() != -1)
            {
                AgregarRegistroWindow agregarRegistro = new AgregarRegistroWindow((Paciente)DataGridPacientes.SelectedItem);
                agregarRegistro.ShowDialog();
            }
        }

        public void ReloadItemsSource()
        {
            var temp = DBManager.GetPacientes();
            int count = Pacientes.Count;
            for (int i = count; i < temp.Count; i++)
            {
                Pacientes.Add(temp[i]);
            }
            DataGridPacientes.Items.Refresh();
        }
    }
}
