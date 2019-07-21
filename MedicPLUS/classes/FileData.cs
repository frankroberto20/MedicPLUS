using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;

namespace MedicPLUS.classes
{
    public class FileData
    {
        public string FilePathPacientes = "./data/Paciente/Pacientes.csv";
        public string DataDirectory = "./data";
        string[] PropiedadesRegistro = { "antecedentesPersonales", "antecedentesFamiliares", "motivoConsulta", "signosSintomas", "segmentoAnterior", "anexos", "medios", "fondoOjo", "tratamiento", "diagnostico", "notas" };
        string[] OjosRegistro = { "ojoDerecho", "ojoIzquierdo" };

        public enum RegistrosPropiedades
        {
            AntecedentesPersonales,
            AntecedentesFamiliares,
            MotivoConsulta,
            SignosSintomas,
            SegmentoAnterior,
            Anexos,
            Medios,
            FondoOjo,
            Tratamiento
        }

        public void RecuperarLista(ObservableCollection<Paciente> pacientes)
        {
            foreach (var line in File.ReadLines(FilePathPacientes).Skip(1))
            {
                var data = line.Split(',');
                if (data.Length == 6)
                {
                    Paciente paciente = new Paciente { ID = data[0], Nombre = data[1], Apellidos = data[2], Telefono = data[3], Correo = data[4], Edad = Convert.ToInt32(data[5]) };
                    pacientes.Add(paciente);
                }

            }

        }

        public void RecuperarListasRegistros(List<string> antecedentesPersonales, List<string> antecedentesFamiliares, List<string> motivoConsulta, List<string> signosSintomas, List<string> segmentoAnterior, List<string> anexos, List<string> medios, List<string> fondoOjo, List<string> tratamiento)
        {
            string filePathRegistroLista;
            RegistrosPropiedades[] registrosPropiedades = { RegistrosPropiedades.AntecedentesPersonales, RegistrosPropiedades.AntecedentesFamiliares, RegistrosPropiedades.MotivoConsulta, RegistrosPropiedades.SignosSintomas, RegistrosPropiedades.SegmentoAnterior, RegistrosPropiedades.Anexos, RegistrosPropiedades.Medios, RegistrosPropiedades.FondoOjo, RegistrosPropiedades.Tratamiento };

            foreach (var propiedad in registrosPropiedades)
            {
                filePathRegistroLista = DataDirectory + "/" + propiedad + ".data";

                if (File.Exists(filePathRegistroLista))
                {
                    foreach (var line in File.ReadAllLines(filePathRegistroLista))
                    {
                        if (propiedad == registrosPropiedades[0])
                            antecedentesPersonales.Add(line);
                        if (propiedad == registrosPropiedades[1])
                            antecedentesFamiliares.Add(line);
                        if (propiedad == registrosPropiedades[2])
                            motivoConsulta.Add(line);
                        if (propiedad == registrosPropiedades[3])
                            signosSintomas.Add(line);
                        if (propiedad == registrosPropiedades[4])
                            segmentoAnterior.Add(line);
                        if (propiedad == registrosPropiedades[5])
                            anexos.Add(line);
                        if (propiedad == registrosPropiedades[6])
                            medios.Add(line);
                        if (propiedad == registrosPropiedades[7])
                            fondoOjo.Add(line);
                        if (propiedad == registrosPropiedades[8])
                            tratamiento.Add(line);
                    }
                }
            }
        }

        public void RecuperarRegistros(Paciente paciente)
        {
            string directoryRegistro = "./data/Paciente/" + paciente.ID + "-" + paciente.Nombre.Replace(" ", "") + "-Registros";

            foreach (var directory in Directory.GetDirectories(directoryRegistro))
            {
                Registro registro = new Registro();
                
                string filePathRegistro;

                filePathRegistro = directory + "/fecha.out";
                string fecha = File.ReadAllText(filePathRegistro);
                registro.Fecha = Convert.ToDateTime(fecha);

                foreach (var propiedad in PropiedadesRegistro)
                {
                    filePathRegistro = directory + "/" + propiedad + ".out";

                    foreach (var line in File.ReadAllLines(filePathRegistro))
                    {
                        if (propiedad == PropiedadesRegistro[0])
                            registro.AntecedentesPersonales.Add(line);
                        if (propiedad == PropiedadesRegistro[1])
                            registro.AntecedentesFamiliares.Add(line);
                        if (propiedad == PropiedadesRegistro[2])
                            registro.MotivoConsulta.Add(line);
                        if (propiedad == PropiedadesRegistro[3])
                            registro.SignosSintomas.Add(line);
                        if (propiedad == PropiedadesRegistro[4])
                            registro.SegmentoAnterior.Add(line);
                        if (propiedad == PropiedadesRegistro[5])
                            registro.Anexos.Add(line);
                        if (propiedad == PropiedadesRegistro[6])
                            registro.Medios.Add(line);
                        if (propiedad == PropiedadesRegistro[7])
                            registro.FondoOjo.Add(line);
                        if (propiedad == PropiedadesRegistro[8])
                            registro.Tratamiento.Add(line);
                        if (propiedad == PropiedadesRegistro[9])
                            registro.Diagnostico = line;
                        if (propiedad == PropiedadesRegistro[10])
                            registro.Notas = line;
                    }
                }

                foreach (var ojo in OjosRegistro)
                {

                    filePathRegistro = directory + "/" + ojo + ".out";

                    foreach (var line in File.ReadLines(filePathRegistro).Skip(1))
                    {
                        if (ojo == OjosRegistro[0])
                        {
                            var data = line.Split(',');
                            if (data.Length == 9)
                            {
                                registro.OjoDerecho = new OjoDerecho() { AgudezaVisualInicial = data[0], AgudezaVisualFinal = data[1], Esfera = data[2], Cilindro = data[3], Eje = data[4], Adicion = data[5], PresionOcular = data[6], DistanciaPupilar = data[7], TipoLente = data[8] };
                            }
                        }

                        if (ojo == OjosRegistro[1])
                        {
                            var data = line.Split(',');
                            if (data.Length == 9)
                            {
                                registro.OjoIzquierdo = new OjoIzquierdo() { AgudezaVisualInicial = data[0], AgudezaVisualFinal = data[1], Esfera = data[2], Cilindro = data[3], Eje = data[4], Adicion = data[5], PresionOcular = data[6], DistanciaPupilar = data[7], TipoLente = data[8] };
                            }
                        }

                    }
                }

                paciente.Registros.Add(registro);

            }
        }

        public void CrearRegistro(Paciente paciente, List<string> antecedentesPersonales, List<string> antecedentesFamiliares, List<string> motivoConsulta, List<string> signosSintomas, List<string> segmentoAnterior, List<string> anexos, List<string> medios, List<string> fondoOjo, OjoIzquierdo ojoIzquierdo, OjoDerecho ojoDerecho, string diagnostico, string notas)
        {
            string directoryRegistro = "./data/Paciente/" + paciente.ID + "-" + paciente.Nombre.Replace(" ", "") + "-Registros";

            if (!Directory.Exists(directoryRegistro))
                Directory.CreateDirectory(directoryRegistro);

            Registro registro = new Registro() { Fecha = DateTime.Now, AntecedentesPersonales = antecedentesPersonales, AntecedentesFamiliares = antecedentesFamiliares, MotivoConsulta = motivoConsulta, SignosSintomas = signosSintomas, SegmentoAnterior = segmentoAnterior, Anexos = anexos, Medios = medios, FondoOjo = fondoOjo, OjoIzquierdo = ojoIzquierdo, OjoDerecho = ojoDerecho, Diagnostico = diagnostico, Notas = notas };

            string directoryFilePathRegistro = directoryRegistro + "/Registro-" + registro.Fecha.ToShortDateString().Replace("/", "-");
            Directory.CreateDirectory(directoryFilePathRegistro);

            string filePathRegistro = "./data/Paciente/" + paciente.ID + "-" + paciente.Nombre.Replace(" ", "") + "-Registros/Registro-" + registro.Fecha.ToShortDateString().Replace("/", "-");

            File.WriteAllText(filePathRegistro + "/fecha.out", registro.Fecha.ToShortDateString());

            
            foreach (var propiedad in PropiedadesRegistro)
            {
                if (propiedad == PropiedadesRegistro[0])
                {
                    var data = registro.AntecedentesPersonales.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                    
                if (propiedad == PropiedadesRegistro[1])
                {
                    var data = registro.AntecedentesFamiliares.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                if (propiedad == PropiedadesRegistro[2])
                {
                    var data = registro.MotivoConsulta.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                if (propiedad == PropiedadesRegistro[3])
                {
                    var data = registro.SignosSintomas.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                if (propiedad == PropiedadesRegistro[4])
                {
                    var data = registro.SegmentoAnterior.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                if (propiedad == PropiedadesRegistro[5])
                {
                    var data = registro.Anexos.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                if (propiedad == PropiedadesRegistro[6])
                {
                    var data = registro.Medios.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                if (propiedad == PropiedadesRegistro[7])
                {
                    var data = registro.FondoOjo.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
                if (propiedad == PropiedadesRegistro[8])
                {
                    var data = registro.Tratamiento.ToArray();
                    File.AppendAllLines(filePathRegistro + "/" + propiedad + ".out", data);
                }
            }

            if (!File.Exists(filePathRegistro + "/ojoIzquierdo.out"))
            {
                string[] header = { "AVI,AVF,Esfera,Cilindro,Eje,Adicion,Presion Ocular,Distancia Pupilar,Tipo de Lente" };
                File.AppendAllLines(filePathRegistro + "/ojoIzquierdo.out", header);
            }

            string[] ojoIzquierdoFile = { ojoIzquierdo.ToFile() };
            File.AppendAllLines(filePathRegistro + "/ojoIzquierdo.out", ojoIzquierdoFile);



            if (!File.Exists(filePathRegistro + "/ojoDerecho.out"))
            {
                string[] header = { "AVI,AVF,Esfera,Cilindro,Eje,Adicion,Presion Ocular,Distancia Pupilar,Tipo de Lente" };
                File.AppendAllLines(filePathRegistro + "/ojoDerecho.out", header);
            }

            string[] ojoDerechoFile = { ojoDerecho.ToFile() };
            File.AppendAllLines(filePathRegistro + "/ojoDerecho.out", ojoDerechoFile);

            File.WriteAllText(filePathRegistro + "/diagnostico.out", diagnostico);

            File.WriteAllText(filePathRegistro + "/notas.out", notas);

            paciente.Registros.Add(registro);

        }

        public void AgregarListaRegistros(List<string> lista, string text, RegistrosPropiedades propiedad)
        {
            string[] data = { text };

            if (propiedad == RegistrosPropiedades.AntecedentesPersonales)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.AntecedentesFamiliares)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.MotivoConsulta)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.SignosSintomas)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.SegmentoAnterior)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.Anexos)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.Medios)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.FondoOjo)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }
            if (propiedad == RegistrosPropiedades.Tratamiento)
            {
                lista.Add(text);
                File.AppendAllLines(DataDirectory + "/" + propiedad + ".data", data);
            }

        }

        public void AgregarPaciente(ObservableCollection<Paciente> pacientes, Paciente paciente)
        {
            if (!File.Exists(FilePathPacientes))
            {
                string[] header = { "ID,Nombre,Apellidos,Telefono,Correo,Edad" };
                File.AppendAllLines(FilePathPacientes, header);
            }

            pacientes.Add(paciente);
            string[] pacienteFile = { paciente.ToFile() };
            File.AppendAllLines(FilePathPacientes, pacienteFile);

        }

        public FileData()
        {
            if (!Directory.Exists("data"))
                Directory.CreateDirectory("data");

            if (!Directory.Exists("data/Paciente"))
                Directory.CreateDirectory("data/Paciente");
        }

    }
}
