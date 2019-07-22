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

        public AgregarPacienteWindow()
        {
            InitializeComponent();
            for (int x = 0; x < Edades.Length; x++)
                Edades[x] = x + 1;

            AgeComboBox.ItemsSource = Edades;

            AntecedentesPersonalesListBox.ItemsSource = UserControlPacientes.AntecedentesPersonalesMainLst;
            AntecedentesFamiliaresListBox.ItemsSource = UserControlPacientes.AntecedentesFamiliaresMainLst;
            MotivoConsultaListBox.ItemsSource = UserControlPacientes.MotivoConsultaMainLst;
            SignosSintomasListBox.ItemsSource = UserControlPacientes.SignosSintomasMainLst;
            SegmentoAnteriorListBox.ItemsSource = UserControlPacientes.SegmentoAnteriorMainLst;
            AnexosListBox.ItemsSource = UserControlPacientes.AnexosMainLst;
            MediosListBox.ItemsSource = UserControlPacientes.MediosMainLst;
            FondoOjoListBox.ItemsSource = UserControlPacientes.FondoOjoMainLst;
            TratamientoListBox.ItemsSource = UserControlPacientes.TratamientoMainLst;
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

        private void AddAntecedentesPersonalesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesPersonalesTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesPersonalesMainLst, AntecedentesPersonalesTextBox.Text, FileData.RegistrosPropiedades.AntecedentesPersonales);
            }

            AntecedentesPersonalesListBox.ItemsSource = null;
            AntecedentesPersonalesListBox.ItemsSource = UserControlPacientes.AntecedentesPersonalesMainLst;
        }

        private void AddAntecedentesFamiliaresBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesFamiliaresTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesFamiliaresMainLst, AntecedentesFamiliaresTextBox.Text, FileData.RegistrosPropiedades.AntecedentesFamiliares);
            }

            AntecedentesFamiliaresListBox.ItemsSource = null;
            AntecedentesFamiliaresListBox.ItemsSource = UserControlPacientes.AntecedentesFamiliaresMainLst;
        }

        private void AddMotivoConsultaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MotivoConsultaTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.MotivoConsultaMainLst, MotivoConsultaTextBox.Text, FileData.RegistrosPropiedades.MotivoConsulta);
            }

            MotivoConsultaListBox.ItemsSource = null;
            MotivoConsultaListBox.ItemsSource = UserControlPacientes.MotivoConsultaMainLst;
        }

        private void AddSignosSintomasBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SignosSintomasTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.SignosSintomasMainLst, SignosSintomasTextBox.Text, FileData.RegistrosPropiedades.SignosSintomas);
            }

            SignosSintomasListBox.ItemsSource = null;
            SignosSintomasListBox.ItemsSource = UserControlPacientes.SignosSintomasMainLst;
        }

        private void AddSegmentoAnteriorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SegmentoAnteriorTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.SegmentoAnteriorMainLst, SegmentoAnteriorTextBox.Text, FileData.RegistrosPropiedades.SegmentoAnterior);
            }

            SegmentoAnteriorListBox.ItemsSource = null;
            SegmentoAnteriorListBox.ItemsSource = UserControlPacientes.SegmentoAnteriorMainLst;
        }

        private void AddAnexosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AnexosTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.AnexosMainLst, AnexosTextBox.Text, FileData.RegistrosPropiedades.Anexos);
            }

            AnexosListBox.ItemsSource = null;
            AnexosListBox.ItemsSource = UserControlPacientes.AnexosMainLst;
        }

        private void AddMediosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MediosTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.MediosMainLst, MediosTextBox.Text, FileData.RegistrosPropiedades.Medios);
            }

            MediosListBox.ItemsSource = null;
            MediosListBox.ItemsSource = UserControlPacientes.MediosMainLst;
        }

        private void AddFondoOjoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FondoOjoTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.FondoOjoMainLst, FondoOjoTextBox.Text, FileData.RegistrosPropiedades.FondoOjo);
            }

            FondoOjoListBox.ItemsSource = null;
            FondoOjoListBox.ItemsSource = UserControlPacientes.FondoOjoMainLst;
        }

        private void AddTratamientoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TratamientoTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.TratamientoMainLst, TratamientoTextBox.Text, FileData.RegistrosPropiedades.Tratamiento);
            }

            TratamientoListBox.ItemsSource = null;
            TratamientoListBox.ItemsSource = UserControlPacientes.TratamientoMainLst;
        }

        private void CloseDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text != "" && LastNameTextBox.Text != "" && AgeComboBox.SelectedItem != null)
            {
                SaveBtn.IsEnabled = true;
            }
        }

        private void AgeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameTextBox.Text != "" && LastNameTextBox.Text != "" && AgeComboBox.SelectedItem != null)
            {
                SaveBtn.IsEnabled = true;
            }
        }
    }
}
