using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicPLUS.classes
{
    public class Paciente
    {
        static int Counter = 1001;
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }

        public List<Registro> Registros { get; set; } = new List<Registro>();

        public Paciente()
        {
            ID = "PC" + Convert.ToString(Counter++);
        }

        public string ToFile()
        {
            return ID + "," + Nombre + "," + Apellidos + "," + Telefono + "," + Correo + "," + Edad;
        }

    }

    public class Registro {

        public DateTime Fecha { get; set; }
        public List<string> AntecedentesPersonales { get; set; } = new List<string>();
        public List<string> AntecedentesFamiliares { get; set; } = new List<string>();
        public List<string> MotivoConsulta { get; set; } = new List<string>();
        public List<string> SignosSintomas { get; set; } = new List<string>();
        public List<string> SegmentoAnterior { get; set; } = new List<string>();
        public List<string> Anexos { get; set; } = new List<string>();
        public List<string> Medios { get; set; } = new List<string>();
        public List<string> FondoOjo { get; set; } = new List<string>();
        public OjoDerecho OjoDerecho { get; set; } = new OjoDerecho();
        public OjoIzquierdo OjoIzquierdo { get; set; } = new OjoIzquierdo();
        public string Diagnostico { get; set; }
        public string Notas { get; set; }
        
    }
}
