using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicPLUS.classes
{
    public class Ojo
    {
        public string AgudezaVisualInicial { get; set; }
        public string AgudezaVisualFinal { get; set; }
        public string Esfera { get; set; }
        public string Cilindro { get; set; }
        public string Eje { get; set; }
        public string Adicion { get; set; }
        public string PresionOcular { get; set; }
        public string DistanciaPupilar { get; set; }
        public string TipoLente { get; set; }

        public string ToFile()
        {
            return AgudezaVisualInicial + "," + AgudezaVisualFinal + "," + Esfera + "," + Cilindro + "," + Eje + "," + Adicion + "," + PresionOcular + "," + DistanciaPupilar + "," + TipoLente;
        }

    }

    public class OjoDerecho : Ojo { }
    public class OjoIzquierdo : Ojo { }
}
