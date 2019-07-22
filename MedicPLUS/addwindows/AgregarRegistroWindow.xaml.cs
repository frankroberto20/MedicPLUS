using System;
using System.Collections.Generic;
using System.Globalization;
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
using MedicPLUS.classes;
using MedicPLUS.usercontrols;

namespace MedicPLUS.addwindows
{
    /// <summary>
    /// Interaction logic for AgregarRegistroWindow.xaml
    /// </summary>
    public partial class AgregarRegistroWindow : Window
    {
        CultureInfo culture = new CultureInfo("es-DO");
        FileData fileData = new FileData();
        Paciente Paciente;
        int RegistroCounter;

        public AgregarRegistroWindow(Paciente paciente)
        {
            InitializeComponent();

            Paciente = paciente;

            NombrePacienteTextBlock.Text = Paciente.Nombre + " " + Paciente.Apellidos;
            Registro ultimoRegistro = Paciente.Registros[Paciente.Registros.Count - 1];

            RegistroCounter = Paciente.Registros.Count - 1;

            if (Paciente.Registros.Count == 1)
                PreviousRegistroBtn.IsEnabled = false;

            NextRegistroBtn.IsEnabled = false;

            ShowRegistro(ultimoRegistro);

        }

        private void ShowRegistro(Registro registro)
        {
            FechaRegistroTextBlock.Text = registro.Fecha.ToString("dddd, dd MMMM yyyy hh:mm tt", culture);

            AntecedentesPersonalesListView.ItemsSource = registro.AntecedentesPersonales;
            AntecedentesFamiliaresListView.ItemsSource = registro.AntecedentesFamiliares;
            MotivoConsultaListView.ItemsSource = registro.MotivoConsulta;
            SignosSintomasListView.ItemsSource = registro.SignosSintomas;
            SegmentoAnteriorListView.ItemsSource = registro.SegmentoAnterior;
            AnexosListView.ItemsSource = registro.Anexos;
            MediosListView.ItemsSource = registro.Medios;
            FondoOjoListView.ItemsSource = registro.FondoOjo;
            TratamientoListView.ItemsSource = registro.Tratamiento;

            OjoDerechoAVITextBox.Text = registro.OjoDerecho.AgudezaVisualInicial;
            OjoDerechoAVFTextBox.Text = registro.OjoDerecho.AgudezaVisualFinal;
            OjoDerechoEsferaTextBox.Text = registro.OjoDerecho.Esfera;
            OjoDerechoCilindroTextBox.Text = registro.OjoDerecho.Cilindro;
            OjoDerechoEjeTextBox.Text = registro.OjoDerecho.Eje;
            OjoDerechoAdicionTextBox.Text = registro.OjoDerecho.Adicion;
            OjoDerechoPresionOcularTextBox.Text = registro.OjoDerecho.PresionOcular;
            OjoDerechoDistanciaPupilarTextBox.Text = registro.OjoDerecho.DistanciaPupilar;
            OjoDerechoTipoLenteTextBox.Text = registro.OjoDerecho.TipoLente;

            OjoIzquierdoAVITextBox.Text = registro.OjoIzquierdo.AgudezaVisualInicial;
            OjoIzquierdoAVFTextBox.Text = registro.OjoIzquierdo.AgudezaVisualFinal;
            OjoIzquierdoEsferaTextBox.Text = registro.OjoIzquierdo.Esfera;
            OjoIzquierdoCilindroTextBox.Text = registro.OjoIzquierdo.Cilindro;
            OjoIzquierdoEjeTextBox.Text = registro.OjoIzquierdo.Eje;
            OjoIzquierdoAdicionTextBox.Text = registro.OjoIzquierdo.Adicion;
            OjoIzquierdoPresionOcularTextBox.Text = registro.OjoIzquierdo.PresionOcular;
            OjoIzquierdoDistanciaPupilarTextBox.Text = registro.OjoIzquierdo.DistanciaPupilar;
            OjoIzquierdoTipoLenteTextBox.Text = registro.OjoIzquierdo.TipoLente;

            DiagnosticoTextBox.Text = registro.Diagnostico;
            NotasTextBox.Text = registro.Notas;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AgregarRegistroBtn_Click(object sender, RoutedEventArgs e)
        {
            FechaRegistroTextBlock.Text = DateTime.Now.ToString("D", culture);
            NombreRegistroTextBloxk.Text = "Nuevo Registro";

            AgregarRegistroBtn.IsEnabled = false;
            SaveBtn.Visibility = Visibility.Visible;

            AntecedentesPersonalesListView.ItemsSource = UserControlPacientes.AntecedentesPersonalesMainLst;
            AntecedentesFamiliaresListView.ItemsSource = UserControlPacientes.AntecedentesFamiliaresMainLst;
            MotivoConsultaListView.ItemsSource = UserControlPacientes.MotivoConsultaMainLst;
            SignosSintomasListView.ItemsSource = UserControlPacientes.SignosSintomasMainLst;
            SegmentoAnteriorListView.ItemsSource = UserControlPacientes.SegmentoAnteriorMainLst;
            AnexosListView.ItemsSource = UserControlPacientes.AnexosMainLst;
            MediosListView.ItemsSource = UserControlPacientes.MediosMainLst;
            FondoOjoListView.ItemsSource = UserControlPacientes.FondoOjoMainLst;
            TratamientoListView.ItemsSource = UserControlPacientes.TratamientoMainLst;

            AntecedentesPersonalesListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            AntecedentesPersonalesOpenDialogHostBtn.Visibility = Visibility.Visible;

            AntecedentesFamiliaresListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            AntecedentesFamiliaresOpenDialogHostBtn.Visibility = Visibility.Visible;

            MotivoConsultaListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            MotivoConsultaOpenDialogHostBtn.Visibility = Visibility.Visible;

            SignosSintomasListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            SignosSintomasOpenDialogHostBtn.Visibility = Visibility.Visible;

            SegmentoAnteriorListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            SegmentoAnteriorOpenDialogHostBtn.Visibility = Visibility.Visible;

            AnexosListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            AnexosOpenDialogHostBtn.Visibility = Visibility.Visible;

            MediosListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            MediosOpenDialogHostBtn.Visibility = Visibility.Visible;

            FondoOjoListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            FondoOjoOpenDialogHostBtn.Visibility = Visibility.Visible;

            TratamientoListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            TratamientoOpenDialogHostBtn.Visibility = Visibility.Visible;

            OjoDerechoAVITextBox.IsReadOnly = false;
            OjoDerechoAVFTextBox.IsReadOnly = false;
            OjoDerechoEsferaTextBox.IsReadOnly = false;
            OjoDerechoCilindroTextBox.IsReadOnly = false;
            OjoDerechoEjeTextBox.IsReadOnly = false;
            OjoDerechoAdicionTextBox.IsReadOnly = false;
            OjoDerechoPresionOcularTextBox.IsReadOnly = false;
            OjoDerechoDistanciaPupilarTextBox.IsReadOnly = false;
            OjoDerechoTipoLenteTextBox.IsReadOnly = false;

            OjoIzquierdoAVITextBox.IsReadOnly = false;
            OjoIzquierdoAVFTextBox.IsReadOnly = false;
            OjoIzquierdoEsferaTextBox.IsReadOnly = false;
            OjoIzquierdoCilindroTextBox.IsReadOnly = false;
            OjoIzquierdoEjeTextBox.IsReadOnly = false;
            OjoIzquierdoAdicionTextBox.IsReadOnly = false;
            OjoIzquierdoPresionOcularTextBox.IsReadOnly = false;
            OjoIzquierdoDistanciaPupilarTextBox.IsReadOnly = false;
            OjoIzquierdoTipoLenteTextBox.IsReadOnly = false;

            /*
            OjoDerechoAVITextBox.Text = "";
            OjoDerechoAVFTextBox.Text = "";
            OjoDerechoEsferaTextBox.Text = "";
            OjoDerechoCilindroTextBox.Text = "";
            OjoDerechoEjeTextBox.Text = "";
            OjoDerechoAdicionTextBox.Text = "";
            OjoDerechoPresionOcularTextBox.Text = "";
            OjoDerechoDistanciaPupilarTextBox.Text = "";
            OjoDerechoTipoLenteTextBox.Text = "";

            OjoIzquierdoAVITextBox.Text = "";
            OjoIzquierdoAVFTextBox.Text = "";
            OjoIzquierdoEsferaTextBox.Text = "";
            OjoIzquierdoCilindroTextBox.Text = "";
            OjoIzquierdoEjeTextBox.Text = "";
            OjoIzquierdoAdicionTextBox.Text = "";
            OjoIzquierdoPresionOcularTextBox.Text = "";
            OjoIzquierdoDistanciaPupilarTextBox.Text = "";
            OjoIzquierdoTipoLenteTextBox.Text = "";
            */

            DiagnosticoTextBox.IsReadOnly = false;
            NotasTextBox.IsReadOnly = false;

            //DiagnosticoTextBox.Text = "";
            //NotasTextBox.Text = "";

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            OjoDerecho ojoDerecho = new OjoDerecho { AgudezaVisualInicial = OjoDerechoAVITextBox.Text, AgudezaVisualFinal = OjoDerechoAVFTextBox.Text, Adicion = OjoDerechoAdicionTextBox.Text, Cilindro = OjoDerechoCilindroTextBox.Text, DistanciaPupilar = OjoDerechoDistanciaPupilarTextBox.Text, Eje = OjoDerechoEjeTextBox.Text, Esfera = OjoDerechoEsferaTextBox.Text, PresionOcular = OjoDerechoPresionOcularTextBox.Text, TipoLente = OjoDerechoTipoLenteTextBox.Text };
            OjoIzquierdo ojoIzquierdo = new OjoIzquierdo { AgudezaVisualInicial = OjoIzquierdoAVITextBox.Text, AgudezaVisualFinal = OjoIzquierdoAVFTextBox.Text, Adicion = OjoIzquierdoAdicionTextBox.Text, Cilindro = OjoIzquierdoCilindroTextBox.Text, DistanciaPupilar = OjoIzquierdoDistanciaPupilarTextBox.Text, Eje = OjoIzquierdoEjeTextBox.Text, Esfera = OjoIzquierdoEsferaTextBox.Text, PresionOcular = OjoIzquierdoPresionOcularTextBox.Text, TipoLente = OjoIzquierdoTipoLenteTextBox.Text };
            fileData.CrearRegistro(Paciente, AntecedentesPersonalesListView.SelectedItems.Cast<string>().ToList(), AntecedentesFamiliaresListView.SelectedItems.Cast<string>().ToList(), MotivoConsultaListView.SelectedItems.Cast<string>().ToList(), SignosSintomasListView.SelectedItems.Cast<string>().ToList(), SegmentoAnteriorListView.SelectedItems.Cast<string>().ToList(), AnexosListView.SelectedItems.Cast<string>().ToList(), MediosListView.SelectedItems.Cast<string>().ToList(), FondoOjoListView.SelectedItems.Cast<string>().ToList(), ojoIzquierdo, ojoDerecho, DiagnosticoTextBox.Text, NotasTextBox.Text);

            
        }

        private void AddAntecedentesPersonalesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesPersonalesTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesPersonalesMainLst, AntecedentesPersonalesTextBox.Text, FileData.RegistrosPropiedades.AntecedentesPersonales);
            }
            AntecedentesPersonalesListView.ItemsSource = null;
            AntecedentesPersonalesListView.ItemsSource = UserControlPacientes.AntecedentesPersonalesMainLst;
        }

        private void AddAntecedentesFamiliaresBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesFamiliaresTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesFamiliaresMainLst, AntecedentesFamiliaresTextBox.Text, FileData.RegistrosPropiedades.AntecedentesFamiliares);
            }

            AntecedentesFamiliaresListView.ItemsSource = null;
            AntecedentesFamiliaresListView.ItemsSource = UserControlPacientes.AntecedentesFamiliaresMainLst;
        }

        private void AddMotivoConsultaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MotivoConsultaTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.MotivoConsultaMainLst, MotivoConsultaTextBox.Text, FileData.RegistrosPropiedades.MotivoConsulta);
            }

            MotivoConsultaListView.ItemsSource = null;
            MotivoConsultaListView.ItemsSource = UserControlPacientes.MotivoConsultaMainLst;
        }

        private void AddSignosSintomasBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SignosSintomasTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.SignosSintomasMainLst, SignosSintomasTextBox.Text, FileData.RegistrosPropiedades.SignosSintomas);
            }

            SignosSintomasListView.ItemsSource = null;
            SignosSintomasListView.ItemsSource = UserControlPacientes.SignosSintomasMainLst;
        }

        private void AddSegmentoAnteriorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SegmentoAnteriorTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.SegmentoAnteriorMainLst, SegmentoAnteriorTextBox.Text, FileData.RegistrosPropiedades.SegmentoAnterior);
            }

            SegmentoAnteriorListView.ItemsSource = null;
            SegmentoAnteriorListView.ItemsSource = UserControlPacientes.SegmentoAnteriorMainLst;
        }

        private void AddAnexosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AnexosTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.AnexosMainLst, AnexosTextBox.Text, FileData.RegistrosPropiedades.Anexos);
            }

            AnexosListView.ItemsSource = null;
            AnexosListView.ItemsSource = UserControlPacientes.AnexosMainLst;
        }

        private void AddMediosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MediosTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.MediosMainLst, MediosTextBox.Text, FileData.RegistrosPropiedades.Medios);
            }

            MediosListView.ItemsSource = null;
            MediosListView.ItemsSource = UserControlPacientes.MediosMainLst;
        }

        private void AddFondoOjoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FondoOjoTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.FondoOjoMainLst, FondoOjoTextBox.Text, FileData.RegistrosPropiedades.FondoOjo);
            }

            FondoOjoListView.ItemsSource = null;
            FondoOjoListView.ItemsSource = UserControlPacientes.FondoOjoMainLst;
        }

        private void AddTratamientoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TratamientoTextBox.Text != "")
            {
                fileData.AgregarListaRegistros(UserControlPacientes.TratamientoMainLst, TratamientoTextBox.Text, FileData.RegistrosPropiedades.Tratamiento);
            }

            TratamientoListView.ItemsSource = null;
            TratamientoListView.ItemsSource = UserControlPacientes.TratamientoMainLst;
        }

        private void NextRegistroBtn_Click(object sender, RoutedEventArgs e)
        {
            NextRegistroBtn.IsEnabled = true;
            PreviousRegistroBtn.IsEnabled = true;

            ShowRegistro(Paciente.Registros[RegistroCounter += 1]);

            if (RegistroCounter == Paciente.Registros.Count - 1)
                NextRegistroBtn.IsEnabled = false;
        }

        private void PreviousRegistroBtn_Click(object sender, RoutedEventArgs e)
        {
            NextRegistroBtn.IsEnabled = true;
            PreviousRegistroBtn.IsEnabled = true;

            ShowRegistro(Paciente.Registros[RegistroCounter -= 1]);

            if (RegistroCounter == 0)
                PreviousRegistroBtn.IsEnabled = false;
        }

        private void CloseDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            NombreRegistroTextBloxk.Text = "Registro";
            ShowRegistro(Paciente.Registros[Paciente.Registros.Count - 1]);

            AntecedentesPersonalesListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            AntecedentesPersonalesOpenDialogHostBtn.Visibility = Visibility.Hidden;

            AntecedentesFamiliaresListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            AntecedentesFamiliaresOpenDialogHostBtn.Visibility = Visibility.Hidden;

            MotivoConsultaListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            MotivoConsultaOpenDialogHostBtn.Visibility = Visibility.Hidden;

            SignosSintomasListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            SignosSintomasOpenDialogHostBtn.Visibility = Visibility.Hidden;

            SegmentoAnteriorListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            SegmentoAnteriorOpenDialogHostBtn.Visibility = Visibility.Hidden;

            AnexosListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            AnexosOpenDialogHostBtn.Visibility = Visibility.Hidden;

            MediosListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            MediosOpenDialogHostBtn.Visibility = Visibility.Hidden;

            FondoOjoListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            FondoOjoOpenDialogHostBtn.Visibility = Visibility.Hidden;

            TratamientoListView.ItemContainerStyle = (Style)Resources["ListBoxReadMode"];
            TratamientoOpenDialogHostBtn.Visibility = Visibility.Hidden;

            OjoDerechoAVITextBox.IsReadOnly = true;
            OjoDerechoAVFTextBox.IsReadOnly = true;
            OjoDerechoEsferaTextBox.IsReadOnly = true;
            OjoDerechoCilindroTextBox.IsReadOnly = true;
            OjoDerechoEjeTextBox.IsReadOnly = true;
            OjoDerechoAdicionTextBox.IsReadOnly = true;
            OjoDerechoPresionOcularTextBox.IsReadOnly = true;
            OjoDerechoDistanciaPupilarTextBox.IsReadOnly = true;
            OjoDerechoTipoLenteTextBox.IsReadOnly = true;

            OjoIzquierdoAVITextBox.IsReadOnly = true;
            OjoIzquierdoAVFTextBox.IsReadOnly = true;
            OjoIzquierdoEsferaTextBox.IsReadOnly = true;
            OjoIzquierdoCilindroTextBox.IsReadOnly = true;
            OjoIzquierdoEjeTextBox.IsReadOnly = true;
            OjoIzquierdoAdicionTextBox.IsReadOnly = true;
            OjoIzquierdoPresionOcularTextBox.IsReadOnly = true;
            OjoIzquierdoDistanciaPupilarTextBox.IsReadOnly = true;
            OjoIzquierdoTipoLenteTextBox.IsReadOnly = true;
        }
    }
}
