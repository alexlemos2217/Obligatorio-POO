using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Viajes
{
    public class Terminal_Nacional : Terminal
    {
        //Atributos
        private bool taxi;

        //Propiedades
        public bool Taxi
        {
            get { return taxi; }
            set
            {
                taxi = value;
            }
        }

        // Constructor
        public Terminal_Nacional(string tCodigo, string tCiudad, bool tnTaxi)
            : base(tCodigo, tCiudad)
        {

            Taxi = tnTaxi;
        }

        // Operaciones
        public override string ToString()
        {
            string tieneTaxis = Taxi ? "Tiene servicio de taxis" : "No tiene servicio de taxis";
            return base.ToString() + "\n" + tieneTaxis;
        }
    }
}