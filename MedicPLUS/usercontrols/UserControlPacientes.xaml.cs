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

        public static List<string> AntecedentesPersonalesMainLst = new List<string>();
        public static List<string> AntecedentesFamiliaresMainLst = new List<string>();
        public static List<string> MotivoConsultaMainLst = new List<string>();
        public static List<string> SignosSintomasMainLst = new List<string>();
        public static List<string> SegmentoAnteriorMainLst = new List<string>();
        public static List<string> AnexosMainLst = new List<string>();
        public static List<string> MediosMainLst = new List<string>();
        public static List<string> FondoOjoMainLst = new List<string>();
        public static List<string> TratamientoMainLst = new List<string>();

        public UserControlPacientes()
        {
            InitializeComponent();

            
            if (File.Exists(fileData.FilePathPacientes))
            {
                fileData.RecuperarLista(Pacientes);

                foreach (var paciente in Pacientes)
                    fileData.RecuperarRegistros(paciente);
            }

            fileData.RecuperarListasRegistros(AntecedentesPersonalesMainLst, AntecedentesFamiliaresMainLst, MotivoConsultaMainLst, SignosSintomasMainLst, SegmentoAnteriorMainLst, AnexosMainLst, MediosMainLst, FondoOjoMainLst, TratamientoMainLst);

            DataGridPacientes.ItemsSource = DBManager.GetPacientes();
            
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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as DataGridRow).GetIndex() != -1)
            {
                AgregarRegistroWindow agregarRegistro = new AgregarRegistroWindow((Paciente)DataGridPacientes.SelectedItem);
                agregarRegistro.ShowDialog();
            }
        }
    }
}
