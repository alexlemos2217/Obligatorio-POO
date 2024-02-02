using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Viajes
{
    public class Terminal_Internacional : Terminal
    {
        // Atributos
        private string pais;

        // Propiedades
        public string Pais
        {
            get { return pais; }
            set
            {
                if (value == "")
                {
                    throw new Exception("El nombre de la ciudad no puede estar vacío.");
                }
                if (value.Trim().Length > 50)
                {
                    throw new Exception("El nombre de la ciudad no puede superar los 50 caracteres.");
                }

                pais = value;
            }
        }

        // Constructor
        public Terminal_Internacional(string tCodigo, string tCiudad, string tiPais)
            : base(tCodigo, tCiudad)
        {
            Pais = tiPais;
        }

        // Operaciones
        public override string ToString()
        {
            return base.ToString() + "\nPais: " + Pais;
        }
    }
}
