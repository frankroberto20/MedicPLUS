using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Windows;

namespace MedicPLUS.classes
{
    static class DBManager
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["MedicPlusConnectionString"].ConnectionString;
        static public void InsertPaciente(Paciente paciente)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                connection.Open();
                SqlCommand cmd = new SqlCommand("stp_InsertPaciente", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@nombres", paciente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@apellidos", paciente.Apellidos));
                cmd.Parameters.Add(new SqlParameter("@edad", paciente.Edad));
                cmd.Parameters.Add(new SqlParameter("@telefono", paciente.Telefono));
                cmd.Parameters.Add(new SqlParameter("@correo", paciente.Correo));

                cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                }
            }
        }

        static public ObservableCollection<Paciente> GetPacientes()
        {
            var pacientes = new ObservableCollection<Paciente>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("stp_SelectAllPacientes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pacientes.Add(new Paciente{
                        ID = (int)reader["Id"],
                        Nombre = reader["Nombres"].ToString(), 
                        Apellidos = reader["Apellidos"].ToString(), 
                        Edad = (int)reader["Edad"], 
                        Correo = reader["Correo"].ToString(), 
                        Telefono = reader["Telefono"].ToString()
                        });
                }
            }
            return pacientes;
        }

        static public void InsertRegistro(Paciente paciente, Registro registro)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("stp_InsertRegistro", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@idPaciente", paciente.ID));
                cmd.Parameters.Add(new SqlParameter("@antecedentesPersonales", ListToString(registro.AntecedentesPersonales)));
                cmd.Parameters.Add(new SqlParameter("@antecedentesFamiliares", ListToString(registro.AntecedentesFamiliares)));
                cmd.Parameters.Add(new SqlParameter("@motivoConsulta", ListToString(registro.MotivoConsulta)));
                cmd.Parameters.Add(new SqlParameter("@signosSintomas", ListToString(registro.SignosSintomas)));
                cmd.Parameters.Add(new SqlParameter("@segmentoAnterior", ListToString(registro.SegmentoAnterior)));
                cmd.Parameters.Add(new SqlParameter("@anexos", ListToString(registro.Anexos)));
                cmd.Parameters.Add(new SqlParameter("@medios", ListToString(registro.Medios)));
                cmd.Parameters.Add(new SqlParameter("@fondoOjo", ListToString(registro.FondoOjo)));
                cmd.Parameters.Add(new SqlParameter("@tratamiento", ListToString(registro.Tratamiento)));
                cmd.Parameters.Add(new SqlParameter("@od_AgudezaVisualI", registro.OjoDerecho.AgudezaVisualInicial));
                cmd.Parameters.Add(new SqlParameter("@od_AgudezaVisualF", registro.OjoDerecho.AgudezaVisualFinal));
                cmd.Parameters.Add(new SqlParameter("@od_Esfera", registro.OjoDerecho.Esfera));
                cmd.Parameters.Add(new SqlParameter("@od_Cilindro", registro.OjoDerecho.Cilindro));
                cmd.Parameters.Add(new SqlParameter("@od_Eje", registro.OjoDerecho.Eje));
                cmd.Parameters.Add(new SqlParameter("@od_Adicion", registro.OjoDerecho.Adicion));
                cmd.Parameters.Add(new SqlParameter("@od_PresionOcular", registro.OjoDerecho.PresionOcular));
                cmd.Parameters.Add(new SqlParameter("@od_DistanciaPupilar", registro.OjoDerecho.DistanciaPupilar));
                cmd.Parameters.Add(new SqlParameter("@od_TipoLente", registro.OjoIzquierdo.TipoLente));
                cmd.Parameters.Add(new SqlParameter("@oi_AgudezaVisualI", registro.OjoIzquierdo.AgudezaVisualInicial));
                cmd.Parameters.Add(new SqlParameter("@oi_AgudezaVisualF", registro.OjoIzquierdo.AgudezaVisualFinal));
                cmd.Parameters.Add(new SqlParameter("@oi_Esfera", registro.OjoIzquierdo.Esfera));
                cmd.Parameters.Add(new SqlParameter("@oi_Cilindro", registro.OjoIzquierdo.Cilindro));
                cmd.Parameters.Add(new SqlParameter("@oi_Eje", registro.OjoIzquierdo.Eje));
                cmd.Parameters.Add(new SqlParameter("@oi_Adicion", registro.OjoIzquierdo.Adicion));
                cmd.Parameters.Add(new SqlParameter("@oi_PresionOcular", registro.OjoIzquierdo.PresionOcular));
                cmd.Parameters.Add(new SqlParameter("@oi_DistanciaPupilar", registro.OjoIzquierdo.DistanciaPupilar));
                cmd.Parameters.Add(new SqlParameter("@oi_TipoLente", registro.OjoIzquierdo.TipoLente));
                cmd.Parameters.Add(new SqlParameter("@notas", registro.Notas));
                cmd.Parameters.Add(new SqlParameter("@diagnostico", registro.Diagnostico));

                cmd.ExecuteNonQuery();
            }
            paciente.Registros = GetRegistrosPaciente(paciente.ID);
        }

        static public List<Registro> GetRegistrosPaciente(int pacienteID)
        {
            var registros = new List<Registro>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand("stp_SelectRegistrosByPacienteId", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@idPaciente", pacienteID));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OjoDerecho od = new OjoDerecho{
                        AgudezaVisualInicial = reader["OD_AgudezaVisual_I"].ToString(),
                        AgudezaVisualFinal = reader["OD_AgudezaVisual_I"].ToString(),
                        Esfera = reader["OD_Esfera"].ToString(),
                        Cilindro = reader["OD_Cilindro"].ToString(),
                        Eje = reader["OD_Eje"].ToString(),
                        Adicion = reader["OD_Adicion"].ToString(),
                        PresionOcular = reader["OD_PresionOcular"].ToString(),
                        DistanciaPupilar = reader["OD_DistanciaPupilar"].ToString(),
                        TipoLente = reader["OD_TipoLente"].ToString()
                        };

                    OjoIzquierdo oi = new OjoIzquierdo{
                        AgudezaVisualInicial = reader["OI_AgudezaVisual_I"].ToString(),
                        AgudezaVisualFinal = reader["OI_AgudezaVisual_I"].ToString(),
                        Esfera = reader["OI_Esfera"].ToString(),
                        Cilindro = reader["OI_Cilindro"].ToString(),
                        Eje = reader["OI_Eje"].ToString(),
                        Adicion = reader["OI_Adicion"].ToString(),
                        PresionOcular = reader["OI_PresionOcular"].ToString(),
                        DistanciaPupilar = reader["OI_DistanciaPupilar"].ToString(),
                        TipoLente = reader["OI_TipoLente"].ToString()
                        };

                    registros.Add(new Registro{ 
                        ID = (int)reader["Id"],
                        AntecedentesPersonales = GetListOfRegistroAttributes(reader["Antecedentes_Personales"].ToString()),
                        AntecedentesFamiliares = GetListOfRegistroAttributes(reader["Antecedentes_Familiares"].ToString()),
                        MotivoConsulta = GetListOfRegistroAttributes(reader["Motivo_Consulta"].ToString()),
                        SignosSintomas = GetListOfRegistroAttributes(reader["Signos_Sintomas"].ToString()),
                        SegmentoAnterior = GetListOfRegistroAttributes(reader["Segmento_Anterior"].ToString()),
                        Anexos = GetListOfRegistroAttributes(reader["Anexos"].ToString()),
                        Medios = GetListOfRegistroAttributes(reader["Medios"].ToString()),
                        FondoOjo = GetListOfRegistroAttributes(reader["Fondo_Ojo"].ToString()),
                        Tratamiento = GetListOfRegistroAttributes(reader["Tratamiento"].ToString()),
                        OjoDerecho = od,
                        OjoIzquierdo = oi,
                        Notas = reader["Notas"].ToString(),
                        Diagnostico = reader["Diagnostico"].ToString(),
                        Fecha = (DateTime)reader["Fecha"]
                        });
                }
            }
            return registros;
        }

        static List<string> GetListOfRegistroAttributes(string data)
        {
            if (data != null)
                return new List<string>(data.Split(','));
            return null;
        }

        static string ListToString(List<string> list)
        {
            if(list.Count == 0)
                return "";

            string result = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                result += "," + list[i];
            }
            return result;
        }
    }
}
