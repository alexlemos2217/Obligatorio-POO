using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gestion_Viajes
{
    public abstract class Terminal
    {
        // Atributos
        private string codigo;
        private string ciudad;

        // Propiedades
        public string Codigo
        {
            get { return codigo; }
            set
            {
                // Expresión regular que controla que el texto sea de exactamente 6 letras (mayúsculas o minúsculas) o 6 números
                if (!Regex.IsMatch(value, "^[a-zA-Z0-9]{6}$"))
                    throw new Exception("El código debe estar compuesto por seis dígitos");

                codigo = value;
            }
        }

        public string Ciudad
        {
            get { return ciudad; }
            set
            {
                if (value == "")
                {
                    throw new Exception("El nombre de la ciudad no puede estar vacío.");
                }
                else if (value.Trim().Length > 50)
                {
                    throw new Exception("El nombre de la ciudad no puede superar los 50 caracteres.");
                }

                ciudad = value;
            }

        }

        // Constructores
        public Terminal(string tCodigo, string tCiudad)
        {
            Codigo = tCodigo;
            Ciudad = tCiudad;
        }

        public override string ToString()
        {
            return ("Código: " + Codigo + "\nCiudad: " + Ciudad);
        }
    }
}