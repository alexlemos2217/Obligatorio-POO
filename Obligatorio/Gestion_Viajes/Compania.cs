using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gestion_Viajes
{
    public class Compania
    {
        // Atributos de instancia
        private string nombre;
        private string direccion;
        private string telefono;

        // Propiedades
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El nombre no puede estar vacío");
                }

                nombre = value;
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("La dirección no puede estar vacía");
                }

                direccion = value;
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set
            {

                if (value.ToString().Trim() == "")
                {
                    throw new Exception("El teléfono no puede estar vacío");
                }
                if (!Regex.IsMatch(value, "^[0-9]{8,9}$"))
                {
                    throw new Exception("El teléfono debe tener 8 o 9 números");
                }

                telefono = value;
            }
        }

        // Constructor
        public Compania(string cNombre, string cDireccion, string cTelefono)
        {
            Nombre = cNombre;
            Direccion = cDireccion;
            Telefono = cTelefono;
        }
        public override string ToString()
        {
            return("Nombre: " + Nombre + "\nDrección: " + Direccion + "\nTeléfono: " + Telefono);
        }
    }
}
