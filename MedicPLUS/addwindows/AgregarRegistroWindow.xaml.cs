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
        Registro UltimoRegistro;
        int RegistroCounter;

        public AgregarRegistroWindow(Paciente paciente)
        {
            InitializeComponent();
            LoadWindow(paciente);

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

            

            AntecedentesPersonalesListView.ItemsSource = UserControlPacientes.AntecedentesPersonalesMainLst;
            AntecedentesFamiliaresListView.ItemsSource = UserControlPacientes.AntecedentesFamiliaresMainLst;
            MotivoConsultaListView.ItemsSource = UserControlPacientes.MotivoConsultaMainLst;
            SignosSintomasListView.ItemsSource = UserControlPacientes.SignosSintomasMainLst;
            SegmentoAnteriorListView.ItemsSource = UserControlPacientes.SegmentoAnteriorMainLst;
            AnexosListView.ItemsSource = UserControlPacientes.AnexosMainLst;
            MediosListView.ItemsSource = UserControlPacientes.MediosMainLst;
            FondoOjoListView.ItemsSource = UserControlPacientes.FondoOjoMainLst;
            TratamientoListView.ItemsSource = UserControlPacientes.TratamientoMainLst;

            EnableEditMode();


        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            OjoDerecho ojoDerecho = new OjoDerecho { 
                AgudezaVisualInicial = OjoDerechoAVITextBox.Text, 
                AgudezaVisualFinal = OjoDerechoAVFTextBox.Text, 
                Adicion = OjoDerechoAdicionTextBox.Text, 
                Cilindro = OjoDerechoCilindroTextBox.Text, 
                DistanciaPupilar = OjoDerechoDistanciaPupilarTextBox.Text, 
                Eje = OjoDerechoEjeTextBox.Text, 
                Esfera = OjoDerechoEsferaTextBox.Text, 
                PresionOcular = OjoDerechoPresionOcularTextBox.Text, 
                TipoLente = OjoDerechoTipoLenteTextBox.Text };
            
            OjoIzquierdo ojoIzquierdo = new OjoIzquierdo { 
                AgudezaVisualInicial = OjoIzquierdoAVITextBox.Text, 
                AgudezaVisualFinal = OjoIzquierdoAVFTextBox.Text, 
                Adicion = OjoIzquierdoAdicionTextBox.Text, 
                Cilindro = OjoIzquierdoCilindroTextBox.Text, 
                DistanciaPupilar = OjoIzquierdoDistanciaPupilarTextBox.Text, 
                Eje = OjoIzquierdoEjeTextBox.Text, 
                Esfera = OjoIzquierdoEsferaTextBox.Text, 
                PresionOcular = OjoIzquierdoPresionOcularTextBox.Text, 
                TipoLente = OjoIzquierdoTipoLenteTextBox.Text };
           
            Registro registro = new Registro
            {
                AntecedentesPersonales = GetListString(AntecedentesPersonalesListView),
                AntecedentesFamiliares = GetListString(AntecedentesFamiliaresListView),
                MotivoConsulta = GetListString(MotivoConsultaListView),
                SignosSintomas = GetListString(SignosSintomasListView),
                SegmentoAnterior = GetListString(SegmentoAnteriorListView),
                Anexos = GetListString(AnexosListView),
                Medios = GetListString(MediosListView),
                FondoOjo = GetListString(FondoOjoListView),

                OjoIzquierdo = ojoIzquierdo,
                OjoDerecho = ojoDerecho,
                Diagnostico = DiagnosticoTextBox.Text,
                Notas = NotasTextBox.Text
            };
            DBManager.InsertRegistro(Paciente, registro);
            //fileData.CrearRegistro(Paciente, AntecedentesPersonalesListView.SelectedItems.Cast<string>().ToList(), AntecedentesFamiliaresListView.SelectedItems.Cast<string>().ToList(), MotivoConsultaListView.SelectedItems.Cast<string>().ToList(), SignosSintomasListView.SelectedItems.Cast<string>().ToList(), SegmentoAnteriorListView.SelectedItems.Cast<string>().ToList(), AnexosListView.SelectedItems.Cast<string>().ToList(), MediosListView.SelectedItems.Cast<string>().ToList(), FondoOjoListView.SelectedItems.Cast<string>().ToList(), ojoIzquierdo, ojoDerecho, DiagnosticoTextBox.Text, NotasTextBox.Text);

            LoadWindow(Paciente);

        }

        private void LoadWindow(Paciente paciente)
        {
            paciente.Registros = DBManager.GetRegistrosPaciente(paciente.ID);
            Paciente = paciente;

            NombrePacienteTextBlock.Text = Paciente.Nombre + " " + Paciente.Apellidos;
            UltimoRegistro = Paciente.Registros[Paciente.Registros.Count - 1];

            RegistroCounter = Paciente.Registros.Count - 1;

            if (Paciente.Registros.Count < 2)
                PreviousRegistroBtn.IsEnabled = false;
            else
                PreviousRegistroBtn.IsEnabled = true;

            NextRegistroBtn.IsEnabled = false;

            ShowRegistro(UltimoRegistro);
        }

        private void AddAntecedentesPersonalesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesPersonalesTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(AntecedentesPersonalesTextBox.Text, CategoriaRegistro.AntecedentesPersonales);
                //fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesPersonalesMainLst, AntecedentesPersonalesTextBox.Text, FileData.RegistrosPropiedades.AntecedentesPersonales);
            }

            RefreshList(CategoriaRegistro.AntecedentesPersonales, UserControlPacientes.AntecedentesPersonalesMainLst, AntecedentesPersonalesListView, AntecedentesPersonalesTextBox);
        }

        

        private void AddAntecedentesFamiliaresBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesFamiliaresTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(AntecedentesFamiliaresTextBox.Text, CategoriaRegistro.AntecedentesFamiliares);
                //fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesFamiliaresMainLst, AntecedentesFamiliaresTextBox.Text, FileData.RegistrosPropiedades.AntecedentesFamiliares);
            }

            RefreshList(CategoriaRegistro.AntecedentesFamiliares, UserControlPacientes.AntecedentesFamiliaresMainLst, AntecedentesFamiliaresListView, AntecedentesFamiliaresTextBox);
        }

        private void AddMotivoConsultaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MotivoConsultaTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(MotivoConsultaTextBox.Text, CategoriaRegistro.MotivoConsulta);
                //fileData.AgregarListaRegistros(UserControlPacientes.MotivoConsultaMainLst, MotivoConsultaTextBox.Text, FileData.RegistrosPropiedades.MotivoConsulta);
            }

            RefreshList(CategoriaRegistro.MotivoConsulta, UserControlPacientes.MotivoConsultaMainLst, MotivoConsultaListView, MotivoConsultaTextBox);
            
        }

        private void AddSignosSintomasBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SignosSintomasTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(SignosSintomasTextBox.Text, CategoriaRegistro.SignosSintomas);
                //fileData.AgregarListaRegistros(UserControlPacientes.SignosSintomasMainLst, SignosSintomasTextBox.Text, FileData.RegistrosPropiedades.SignosSintomas);
            }

            RefreshList(CategoriaRegistro.SignosSintomas, UserControlPacientes.SignosSintomasMainLst, SignosSintomasListView, SignosSintomasTextBox);
        }

        private void AddSegmentoAnteriorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SegmentoAnteriorTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(SegmentoAnteriorTextBox.Text, CategoriaRegistro.SegmentoAnterior);
                //fileData.AgregarListaRegistros(UserControlPacientes.SegmentoAnteriorMainLst, SegmentoAnteriorTextBox.Text, FileData.RegistrosPropiedades.SegmentoAnterior);
            }

            RefreshList(CategoriaRegistro.SegmentoAnterior, UserControlPacientes.SegmentoAnteriorMainLst, SegmentoAnteriorListView, SegmentoAnteriorTextBox);
        }

        private void AddAnexosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AnexosTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(AnexosTextBox.Text, CategoriaRegistro.Anexos);
                //fileData.AgregarListaRegistros(UserControlPacientes.AnexosMainLst, AnexosTextBox.Text, FileData.RegistrosPropiedades.Anexos);
            }

            RefreshList(CategoriaRegistro.Anexos, UserControlPacientes.AnexosMainLst, AnexosListView, AnexosTextBox);
        }

        private void AddMediosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MediosTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(MediosTextBox.Text, CategoriaRegistro.Medios);
                //fileData.AgregarListaRegistros(UserControlPacientes.MediosMainLst, MediosTextBox.Text, FileData.RegistrosPropiedades.Medios);
            }

            RefreshList(CategoriaRegistro.Medios, UserControlPacientes.MediosMainLst, MediosListView, MediosTextBox);
        }

        private void AddFondoOjoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FondoOjoTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(FondoOjoTextBox.Text, CategoriaRegistro.FondoOjo);
                //fileData.AgregarListaRegistros(UserControlPacientes.FondoOjoMainLst, FondoOjoTextBox.Text, FileData.RegistrosPropiedades.FondoOjo);
            }

            RefreshList(CategoriaRegistro.FondoOjo, UserControlPacientes.FondoOjoMainLst, FondoOjoListView, FondoOjoTextBox);
        }

        private void AddTratamientoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TratamientoTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(TratamientoTextBox.Text, CategoriaRegistro.Tratamiento);
                //fileData.AgregarListaRegistros(UserControlPacientes.TratamientoMainLst, TratamientoTextBox.Text, FileData.RegistrosPropiedades.Tratamiento);
            }

            RefreshList(CategoriaRegistro.Tratamiento, UserControlPacientes.TratamientoMainLst, TratamientoListView, TratamientoTextBox);
        }

        private void RefreshList(CategoriaRegistro categoria, List<ListBoxItem> mainList, ListBox itemsList, TextBox textBox)
        {
            var temp = DBManager.GetSourceRegistrosByCategoria(categoria);
            int count = mainList.Count;
            mainList.AddRange(temp.GetRange(count, temp.Count - count));
            itemsList.Items.Refresh();
            textBox.Text = "";
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
            EnableReadMode();
        }

        private void EnableReadMode()
        {

            AgregarRegistroBtn.IsChecked = false;
            AgregarRegistroBtn.IsEnabled = true;
            SaveBtn.Visibility = Visibility.Collapsed;

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

            DiagnosticoTextBox.IsReadOnly = true;
            NotasTextBox.IsReadOnly = true;
            
        }
        private void EnableEditMode()
        {
            NextRegistroBtn.IsEnabled = false;
            PreviousRegistroBtn.IsEnabled = false;

            AgregarRegistroBtn.IsEnabled = false;
            SaveBtn.Visibility = Visibility.Visible;

            AntecedentesPersonalesListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            AntecedentesPersonalesOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(AntecedentesPersonalesListView, UltimoRegistro.AntecedentesPersonales);

            AntecedentesFamiliaresListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            AntecedentesFamiliaresOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(AntecedentesFamiliaresListView, UltimoRegistro.AntecedentesFamiliares);

            MotivoConsultaListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            MotivoConsultaOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(MotivoConsultaListView, UltimoRegistro.MotivoConsulta);

            SignosSintomasListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            SignosSintomasOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(SignosSintomasListView, UltimoRegistro.SignosSintomas);

            SegmentoAnteriorListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            SegmentoAnteriorOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(SegmentoAnteriorListView, UltimoRegistro.SegmentoAnterior);

            AnexosListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            AnexosOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(AnexosListView, UltimoRegistro.Anexos);

            MediosListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            MediosOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(MediosListView, UltimoRegistro.Medios);

            FondoOjoListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            FondoOjoOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(FondoOjoListView, UltimoRegistro.FondoOjo);

            TratamientoListView.ItemContainerStyle = (Style)Resources["ListBoxEditMode"];
            TratamientoOpenDialogHostBtn.Visibility = Visibility.Visible;
            SelectItemsInList(TratamientoListView, UltimoRegistro.Tratamiento);

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

            DiagnosticoTextBox.IsReadOnly = false;
            NotasTextBox.IsReadOnly = false;
        }

        private void SelectItemsInList(ListBox selectList, List<string> fields)
        {
            foreach(ListBoxItem item in selectList.Items)
            {
                if (fields.Contains(item.Content.ToString()))
                    item.IsSelected = true;
            }
        }

        private List<string> GetListString(ListBox list)
        {
            if (list == null)
                return null;

            var result = new List<string>();
            foreach(ListBoxItem item in list.Items)
            {
                if(item.IsSelected == true)
                    result.Add(item.Content.ToString());
            }
            return result;
        }
    }
}
