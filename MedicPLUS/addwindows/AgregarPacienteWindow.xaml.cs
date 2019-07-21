using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MedicPLUS.classes;
using MedicPLUS.usercontrols;
using System.Collections.ObjectModel;

namespace MedicPLUS.addwindows
{
    /// <summary>
    /// Interaction logic for AgregarPacienteWindow.xaml
    /// </summary>
    public partial class AgregarPacienteWindow : Window
    {
        FileData fileData = new FileData();
        int[] Edades = new int[120];

        List<string> AntecedentesPersonales_lst = new List<string>();
        List<string> AntecedentesFamiliares_lst = new List<string>();
        List<string> MotivoConsulta_lst = new List<string>();
        List<string> SignosSintomas_lst = new List<string>();
        List<string> SegmentoAnterior_lst = new List<string>();
        List<string> Anexos_lst = new List<string>();
        List<string> Medios_lst = new List<string>();
        List<string> FondoOjo_lst = new List<string>();
        public AgregarPacienteWindow()
        {
            InitializeComponent();
            for (int x = 0; x < Edades.Length; x++)
                Edades[x] = x + 1;

            AntecedentesPersonales_lst.Add("hola");
            AntecedentesPersonales_lst.Add("mundo");
            AntecedentesPersonales_lst.Add("!");

            AntecedentesFamiliares_lst.Add("hola");
            AntecedentesFamiliares_lst.Add("mundo");

            MotivoConsulta_lst.Add("!");
            MotivoConsulta_lst.Add("hola");

            SignosSintomas_lst.Add("mundo");
            SignosSintomas_lst.Add("!");

            SegmentoAnterior_lst.Add("hola");
            SegmentoAnterior_lst.Add("mundo");
            SegmentoAnterior_lst.Add("!");

            Anexos_lst.Add("hola");
            Anexos_lst.Add("mundo");

            Medios_lst.Add("!");

            FondoOjo_lst.Add("hola");
            FondoOjo_lst.Add("mundo");

            AgeComboBox.ItemsSource = Edades;
            AntecedentesPersonalesListBox.ItemsSource = AntecedentesPersonales_lst;
            AntecedentesFamiliaresListBox.ItemsSource = AntecedentesFamiliares_lst;
            MotivoConsultaListBox.ItemsSource = MotivoConsulta_lst;
            SignosSintomasListBox.ItemsSource = SignosSintomas_lst;
            SegmentoAnteriorListBox.ItemsSource = SegmentoAnterior_lst;
            AnexosListBox.ItemsSource = Anexos_lst;
            MediosListBox.ItemsSource = Medios_lst;
            FondoOjoListBox.ItemsSource = FondoOjo_lst;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Paciente paciente = new Paciente() { Nombre = NameTextBox.Text, Apellidos = LastNameTextBox.Text, Telefono = PhoneTextBox.Text, Correo = MailTextBox.Text, Edad = (int)AgeComboBox.SelectedItem };
            OjoDerecho ojoDerecho = new OjoDerecho { AgudezaVisualInicial = OjoDerechoAVITextBox.Text, AgudezaVisualFinal = OjoDerechoAVFTextBox.Text, Adicion = OjoDerechoAdicionTextBox.Text, Cilindro = OjoDerechoCilindroTextBox.Text, DistanciaPupilar = OjoDerechoDistanciaPupilarTextBox.Text, Eje = OjoDerechoEjeTextBox.Text, Esfera = OjoDerechoEsferaTextBox.Text, PresionOcular = OjoDerechoPresionOcularTextBox.Text, TipoLente = OjoDerechoTipoLenteTextBox.Text };
            OjoIzquierdo ojoIzquierdo = new OjoIzquierdo { AgudezaVisualInicial = OjoIzquierdoAVITextBox.Text, AgudezaVisualFinal = OjoIzquierdoAVFTextBox.Text, Adicion = OjoIzquierdoAdicionTextBox.Text, Cilindro = OjoIzquierdoCilindroTextBox.Text, DistanciaPupilar = OjoIzquierdoDistanciaPupilarTextBox.Text, Eje = OjoIzquierdoEjeTextBox.Text, Esfera = OjoIzquierdoEsferaTextBox.Text, PresionOcular = OjoIzquierdoPresionOcularTextBox.Text, TipoLente = OjoIzquierdoTipoLenteTextBox.Text };

            fileData.AgregarPaciente(UserControlPacientes.Pacientes, paciente);
            fileData.CrearRegistro(paciente, AntecedentesPersonalesListBox.SelectedItems.Cast<string>().ToList(), AntecedentesFamiliaresListBox.SelectedItems.Cast<string>().ToList(), MotivoConsultaListBox.SelectedItems.Cast<string>().ToList(), SignosSintomasListBox.SelectedItems.Cast<string>().ToList(), SegmentoAnteriorListBox.SelectedItems.Cast<string>().ToList(), AnexosListBox.SelectedItems.Cast<string>().ToList(), MediosListBox.SelectedItems.Cast<string>().ToList(), FondoOjoListBox.SelectedItems.Cast<string>().ToList(), ojoIzquierdo, ojoDerecho, DiagnosticoTextBox.Text, NotasTextBox.Text);
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
