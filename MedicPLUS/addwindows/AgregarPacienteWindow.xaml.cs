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

            Registro registro = new Registro{
                AntecedentesPersonales = GetListString(AntecedentesPersonalesListBox),
                AntecedentesFamiliares = GetListString(AntecedentesFamiliaresListBox),
                MotivoConsulta = GetListString(MotivoConsultaListBox),
                SignosSintomas = GetListString(SignosSintomasListBox),
                SegmentoAnterior = GetListString(SegmentoAnteriorListBox),
                Anexos = GetListString(AnexosListBox),
                Medios = GetListString(MediosListBox),
                FondoOjo = GetListString(FondoOjoListBox),

                OjoIzquierdo = ojoIzquierdo,
                OjoDerecho = ojoDerecho,
                Diagnostico = DiagnosticoTextBox.Text,
                Notas = NotasTextBox.Text
            };

            paciente.ID = DBManager.InsertPaciente(paciente);
            DBManager.InsertRegistro(paciente, registro);

            MainWindow.ReloadPacientesItemsSource();
        }

        private bool IsRegistroEmpty()
        {
            if( OjoDerechoAVITextBox.Text != "" ||
                OjoDerechoAVFTextBox.Text != "" || 
                OjoDerechoAdicionTextBox.Text != "" || 
                OjoDerechoCilindroTextBox.Text != "" ||
                OjoDerechoDistanciaPupilarTextBox.Text != "" || 
                OjoDerechoEjeTextBox.Text != "" || 
                OjoDerechoEsferaTextBox.Text != "" ||
                OjoDerechoPresionOcularTextBox.Text != "" ||
                OjoDerechoTipoLenteTextBox.Text != "" ||
                OjoIzquierdoAVITextBox.Text != "" ||
                OjoIzquierdoAVFTextBox.Text != "" || 
                OjoIzquierdoAdicionTextBox.Text != "" ||
                OjoIzquierdoCilindroTextBox.Text != "" ||
                OjoIzquierdoDistanciaPupilarTextBox.Text != "" || 
                OjoIzquierdoEjeTextBox.Text != "" ||
                OjoIzquierdoEsferaTextBox.Text != "" ||
                OjoIzquierdoPresionOcularTextBox.Text != "" || 
                OjoIzquierdoTipoLenteTextBox.Text != "" ||
                DiagnosticoTextBox.Text != "" ||
                NotasTextBox.Text != "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AddAntecedentesPersonalesBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesPersonalesTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(AntecedentesPersonalesTextBox.Text, CategoriaRegistro.AntecedentesPersonales);
                //fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesPersonalesMainLst, AntecedentesPersonalesTextBox.Text, FileData.RegistrosPropiedades.AntecedentesPersonales);
            }

            RefreshList(CategoriaRegistro.AntecedentesPersonales, UserControlPacientes.AntecedentesPersonalesMainLst, AntecedentesPersonalesListBox, AntecedentesPersonalesTextBox);
        }

        private void AddAntecedentesFamiliaresBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AntecedentesFamiliaresTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(AntecedentesFamiliaresTextBox.Text, CategoriaRegistro.AntecedentesFamiliares);
                //fileData.AgregarListaRegistros(UserControlPacientes.AntecedentesFamiliaresMainLst, AntecedentesFamiliaresTextBox.Text, FileData.RegistrosPropiedades.AntecedentesFamiliares);
            }

            RefreshList(CategoriaRegistro.AntecedentesFamiliares, UserControlPacientes.AntecedentesFamiliaresMainLst, AntecedentesFamiliaresListBox, AntecedentesFamiliaresTextBox);
        }

        private void AddMotivoConsultaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MotivoConsultaTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(MotivoConsultaTextBox.Text, CategoriaRegistro.MotivoConsulta);
                //fileData.AgregarListaRegistros(UserControlPacientes.MotivoConsultaMainLst, MotivoConsultaTextBox.Text, FileData.RegistrosPropiedades.MotivoConsulta);
            }

            RefreshList(CategoriaRegistro.MotivoConsulta, UserControlPacientes.MotivoConsultaMainLst, MotivoConsultaListBox, MotivoConsultaTextBox);
        }

        private void AddSignosSintomasBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SignosSintomasTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(SignosSintomasTextBox.Text, CategoriaRegistro.SignosSintomas);
                //fileData.AgregarListaRegistros(UserControlPacientes.SignosSintomasMainLst, SignosSintomasTextBox.Text, FileData.RegistrosPropiedades.SignosSintomas);
            }

            RefreshList(CategoriaRegistro.SignosSintomas, UserControlPacientes.SignosSintomasMainLst, SignosSintomasListBox, SignosSintomasTextBox);
        }

        private void AddSegmentoAnteriorBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SegmentoAnteriorTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(SegmentoAnteriorTextBox.Text, CategoriaRegistro.SegmentoAnterior);
                //fileData.AgregarListaRegistros(UserControlPacientes.SegmentoAnteriorMainLst, SegmentoAnteriorTextBox.Text, FileData.RegistrosPropiedades.SegmentoAnterior);
            }
            
            RefreshList(CategoriaRegistro.SegmentoAnterior, UserControlPacientes.SegmentoAnteriorMainLst, SegmentoAnteriorListBox, SegmentoAnteriorTextBox);
        }

        private void AddAnexosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AnexosTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(AnexosTextBox.Text, CategoriaRegistro.Anexos);
                //fileData.AgregarListaRegistros(UserControlPacientes.AnexosMainLst, AnexosTextBox.Text, FileData.RegistrosPropiedades.Anexos);
            }

            RefreshList(CategoriaRegistro.Anexos, UserControlPacientes.AnexosMainLst, AnexosListBox, AnexosTextBox);
        }

        private void AddMediosBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MediosTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(MediosTextBox.Text, CategoriaRegistro.Medios);
                //fileData.AgregarListaRegistros(UserControlPacientes.MediosMainLst, MediosTextBox.Text, FileData.RegistrosPropiedades.Medios);
            }

            RefreshList(CategoriaRegistro.Medios, UserControlPacientes.MediosMainLst, MediosListBox, MediosTextBox);
        }

        private void AddFondoOjoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FondoOjoTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(FondoOjoTextBox.Text, CategoriaRegistro.FondoOjo);
                //fileData.AgregarListaRegistros(UserControlPacientes.FondoOjoMainLst, FondoOjoTextBox.Text, FileData.RegistrosPropiedades.FondoOjo);
            }

            RefreshList(CategoriaRegistro.FondoOjo, UserControlPacientes.FondoOjoMainLst, FondoOjoListBox, FondoOjoTextBox);
        }

        private void AddTratamientoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TratamientoTextBox.Text != "")
            {
                DBManager.InsertSourceRegistro(TratamientoTextBox.Text, CategoriaRegistro.Tratamiento);
                //fileData.AgregarListaRegistros(UserControlPacientes.TratamientoMainLst, TratamientoTextBox.Text, FileData.RegistrosPropiedades.Tratamiento);
            }

            RefreshList(CategoriaRegistro.Tratamiento, UserControlPacientes.TratamientoMainLst, TratamientoListBox, TratamientoTextBox);
        }

        private void RefreshList(CategoriaRegistro categoria, List<ListBoxItem> mainList, ListBox itemsList, TextBox textBox)
        {
            var temp = DBManager.GetSourceRegistrosByCategoria(categoria);
            int count = mainList.Count;
            mainList.AddRange(temp.GetRange(count, temp.Count - count));
            itemsList.Items.Refresh();
            textBox.Text = "";
        }

        private void CloseDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text != "" && LastNameTextBox.Text != "" && AgeComboBox.SelectedItem != null && !IsRegistroEmpty())
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
            }
        }

        private void AgeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NameTextBox.Text != "" && LastNameTextBox.Text != "" && AgeComboBox.SelectedItem != null && !IsRegistroEmpty())
            {
                SaveBtn.IsEnabled = true;
            }
            else
            {
                SaveBtn.IsEnabled = false;
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
