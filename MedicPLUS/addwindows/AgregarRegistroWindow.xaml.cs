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
        public AgregarRegistroWindow(Paciente paciente)
        {
            InitializeComponent();

            Paciente = paciente;

            NombrePacienteTextBlock.Text = Paciente.Nombre + " " + Paciente.Apellidos;
            Registro ultimoRegistro = Paciente.Registros[Paciente.Registros.Count - 1];

            FechaRegistroTextBlock.Text = ultimoRegistro.Fecha.ToString("D", culture);

            AntecedentesPersonalesListView.ItemsSource = ultimoRegistro.AntecedentesPersonales;
            AntecedentesFamiliaresListView.ItemsSource = ultimoRegistro.AntecedentesFamiliares;
            MotivoConsultaListView.ItemsSource = ultimoRegistro.MotivoConsulta;
            SignosSintomasListView.ItemsSource = ultimoRegistro.SignosSintomas;
            SegmentoAnteriorListView.ItemsSource = ultimoRegistro.SegmentoAnterior;
            AnexosListView.ItemsSource = ultimoRegistro.Anexos;
            MediosListView.ItemsSource = ultimoRegistro.Medios;
            FondoOjoListView.ItemsSource = ultimoRegistro.FondoOjo;

            OjoDerechoAVITextBox.Text = ultimoRegistro.OjoDerecho.AgudezaVisualInicial;
            OjoDerechoAVFTextBox.Text = ultimoRegistro.OjoDerecho.AgudezaVisualFinal;
            OjoDerechoEsferaTextBox.Text = ultimoRegistro.OjoDerecho.Esfera;
            OjoDerechoCilindroTextBox.Text = ultimoRegistro.OjoDerecho.Cilindro;
            OjoDerechoEjeTextBox.Text = ultimoRegistro.OjoDerecho.Eje;
            OjoDerechoAdicionTextBox.Text = ultimoRegistro.OjoDerecho.Adicion;
            OjoDerechoPresionOcularTextBox.Text = ultimoRegistro.OjoDerecho.PresionOcular;
            OjoDerechoDistanciaPupilarTextBox.Text = ultimoRegistro.OjoDerecho.DistanciaPupilar;
            OjoDerechoTipoLenteTextBox.Text = ultimoRegistro.OjoDerecho.TipoLente;

            OjoIzquierdoAVITextBox.Text = ultimoRegistro.OjoIzquierdo.AgudezaVisualInicial;
            OjoIzquierdoAVFTextBox.Text = ultimoRegistro.OjoIzquierdo.AgudezaVisualFinal;
            OjoIzquierdoEsferaTextBox.Text = ultimoRegistro.OjoIzquierdo.Esfera;
            OjoIzquierdoCilindroTextBox.Text = ultimoRegistro.OjoIzquierdo.Cilindro;
            OjoIzquierdoEjeTextBox.Text = ultimoRegistro.OjoIzquierdo.Eje;
            OjoIzquierdoAdicionTextBox.Text = ultimoRegistro.OjoIzquierdo.Adicion;
            OjoIzquierdoPresionOcularTextBox.Text = ultimoRegistro.OjoIzquierdo.PresionOcular;
            OjoIzquierdoDistanciaPupilarTextBox.Text = ultimoRegistro.OjoIzquierdo.DistanciaPupilar;
            OjoIzquierdoTipoLenteTextBox.Text = ultimoRegistro.OjoIzquierdo.TipoLente;

            DiagnosticoTextBox.Text = ultimoRegistro.Diagnostico;
            NotasTextBox.Text = ultimoRegistro.Notas;

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

            DiagnosticoTextBox.IsReadOnly = false;
            NotasTextBox.IsReadOnly = false;

            DiagnosticoTextBox.Text = "";
            NotasTextBox.Text = "";

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            OjoDerecho ojoDerecho = new OjoDerecho { AgudezaVisualInicial = OjoDerechoAVITextBox.Text, AgudezaVisualFinal = OjoDerechoAVFTextBox.Text, Adicion = OjoDerechoAdicionTextBox.Text, Cilindro = OjoDerechoCilindroTextBox.Text, DistanciaPupilar = OjoDerechoDistanciaPupilarTextBox.Text, Eje = OjoDerechoEjeTextBox.Text, Esfera = OjoDerechoEsferaTextBox.Text, PresionOcular = OjoDerechoPresionOcularTextBox.Text, TipoLente = OjoDerechoTipoLenteTextBox.Text };
            OjoIzquierdo ojoIzquierdo = new OjoIzquierdo { AgudezaVisualInicial = OjoIzquierdoAVITextBox.Text, AgudezaVisualFinal = OjoIzquierdoAVFTextBox.Text, Adicion = OjoIzquierdoAdicionTextBox.Text, Cilindro = OjoIzquierdoCilindroTextBox.Text, DistanciaPupilar = OjoIzquierdoDistanciaPupilarTextBox.Text, Eje = OjoIzquierdoEjeTextBox.Text, Esfera = OjoIzquierdoEsferaTextBox.Text, PresionOcular = OjoIzquierdoPresionOcularTextBox.Text, TipoLente = OjoIzquierdoTipoLenteTextBox.Text };
            fileData.CrearRegistro(Paciente, AntecedentesPersonalesListView.SelectedItems.Cast<string>().ToList(), AntecedentesFamiliaresListView.SelectedItems.Cast<string>().ToList(), MotivoConsultaListView.SelectedItems.Cast<string>().ToList(), SignosSintomasListView.SelectedItems.Cast<string>().ToList(), SegmentoAnteriorListView.SelectedItems.Cast<string>().ToList(), AnexosListView.SelectedItems.Cast<string>().ToList(), MediosListView.SelectedItems.Cast<string>().ToList(), FondoOjoListView.SelectedItems.Cast<string>().ToList(), ojoIzquierdo, ojoDerecho, DiagnosticoTextBox.Text, NotasTextBox.Text);
        }
    }
}
