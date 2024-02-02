using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Viajes
{
    public class Logica
    {
        // Atributos de asociación
        private List<Terminal> colTerminales;
        private List<Compania> colCompanias;
        private List<Viaje> colViajes;

        public Logica()
        { 
            colTerminales = new List<Terminal>();
            colCompanias = new List<Compania>();
            colViajes = new List<Viaje>();
        }

        #region Terminales
        
        // Devuelve la cantidad de terminales
        public int ContarTerminales()
        {
            return colCompanias.Count;
        }

        //Dada el código de la terminal, busca la terminal
        public Terminal BuscarTerminal(string pCodigo)
        {
            foreach (Terminal terminal in colTerminales)
            {
                if (terminal.Codigo == pCodigo)
                {
                    return terminal;
                }
            }
            return null;
        }

        // Permite agregar una terminal
        public bool Agregar(Terminal pTer)
        {
            if (BuscarTerminal(pTer.Codigo) == null)
            {
                colTerminales.Add(pTer);
                return true;
            }
            return false;
        }

        // Ejemplo para comprobar si un elemento se puede eliminar o no
        private bool EstaEnUso(Terminal pTer)
        {
            foreach (Viaje viaje in colViajes)
            {
                if (viaje.ViajeTerm == pTer)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Eliminar(Terminal pTer)
        {
            if (EstaEnUso(pTer))
                throw new Exception("La terminal está en uso. No se puede eliminar");

            for (int indice = 0; indice < colTerminales.Count; indice++)
            {
                if (colTerminales[indice].Codigo == pTer.Codigo)
                {
                    colTerminales.RemoveAt(indice);
                    return true;
                }
            }
            return false;
        }

        // Listar terminales nacionales
        public List<Terminal_Nacional> ListarTerminalesNacionales()
        {
            List<Terminal_Nacional> terminalesNacionales = new List<Terminal_Nacional>();

            foreach (Terminal terminal in colTerminales)
            {
                if (terminal is Terminal_Nacional)
                {
                    terminalesNacionales.Add((Terminal_Nacional)terminal);
                }
            }

            return terminalesNacionales;
        }

        // Listar terminales internacionales
        public List<Terminal_Internacional> ListarTerminalesInternacionales()
        {
            List<Terminal_Internacional> terminalesInternacionales = new List<Terminal_Internacional>();

            foreach (Terminal terminal in colTerminales)
            {
                if (terminal is Terminal_Internacional)
                {
                    terminalesInternacionales.Add((Terminal_Internacional)terminal);
                }
            }

            return terminalesInternacionales;
        }

        // Obtener viajes por terminal
        public List<Viaje> ObtenerViajesPorTerminal(Terminal terminal)
        {
            List<Viaje> viajesPorTerminal = new List<Viaje>();

            foreach (Viaje viaje in colViajes)
            {
                if (viaje.ViajeTerm == terminal)
                {
                    viajesPorTerminal.Add(viaje);
                }
            }

            return viajesPorTerminal;
        }



        #endregion

        #region Compañías

        // Contar compañías
        public int ContarCompanias()
        {
            return colCompanias.Count;
        }

        // Buscar compañía por su nombre
        public Compania BuscarCompania(string pNombre)
        {
            foreach (Compania compania in colCompanias)
            {
                if (compania.Nombre == pNombre)
                {
                    return compania;
                }
            }
            return null;
        }

        // Agregar compañía
        public bool AgregarCompania(Compania pCom)
        {
            if (BuscarCompania(pCom.Nombre) == null)
            {
                colCompanias.Add(pCom);
                return true;
            }
            return false;
        }

        // Ejemplo para comprobar si un elemento se puede eliminar o no
        private bool EstaEnUso(Compania pCom)
        {
            foreach (Viaje viaje in colViajes)
            {
                if (viaje.ViajeComp.Nombre == pCom.Nombre)
                {
                    return true;
                }
            }
            return false;
        }

        // Permite eliminar una compañía (si no está en uso por los viajes) (sobrecarga)
        public bool Eliminar(Compania pCom)
        {
            if (EstaEnUso(pCom))
                throw new Exception("La compañía está en uso. No se puede eliminar");

            for (int indice = 0; indice < colCompanias.Count; indice++)
            {
                if (colCompanias[indice].Nombre == pCom.Nombre)
                {
                    colCompanias.RemoveAt(indice);
                    return true;
                }
            }
            return false;
        }

        //Ordenar compañías por nombre
        public List<Compania> OrdenarPorNombre()
        {
            Compania swap;

            for (int i = 0; i < colCompanias.Count; i++)
            {
                for (int j = colCompanias.Count - 1; j > i; j--)
                {
                    if (colCompanias[j].Nombre.CompareTo(colCompanias[j - 1].Nombre) < 0)
                    {
                        swap = colCompanias[j];
                        colCompanias[j] = colCompanias[j - 1];
                        colCompanias[j - 1] = swap;
                    }
                }
            }

            return colCompanias;
        }


        //// Listar compañías por nombre
        //public List<Compania> ListarPorNombre(string pNombre)
        //{
        //    List<Compania> coleccion = new List<Compania>();

        //    foreach (Compania companias in colCompanias)
        //    {
        //        if (companias.Nombre == pNombre)
        //        {
        //            coleccion.Add(companias);
        //        }                
        //    }
        //    return coleccion;
        //}

        #endregion 

        #region Viajes

        // Agregar viaje
        public bool AgregarViaje(Viaje pViaje, string nombreCompania, string codTerminal)
        {
            Compania unaComp = BuscarCompania(nombreCompania);
            Terminal unaTerm = BuscarTerminal(codTerminal);

            if (unaComp == null || unaTerm == null)
            {
                return false; // No se puede agregar el viaje si no existe la compañía o la terminal
            }

            pViaje.ViajeComp = unaComp;
            pViaje.ViajeTerm = unaTerm;

            try
            {
                // Validar la fecha de salida
                pViaje.FechaHoraSalida = pViaje.FechaHoraSalida;

                // Validar la fecha de llegada
                pViaje.FechaHoraLlegada = pViaje.FechaHoraLlegada;

                // Si se llega a este punto, ambas fechas son válidas
                colViajes.Add(pViaje);
                return true; // Viaje agregado exitosamente
            }
            catch
            {
                return false; // Error al agregar el viaje
            }
        }

        // Obtener viajes por  rango de fecha
        public List<Viaje> ObtenerViajesPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            fechaInicio = fechaInicio.Date; // Establecer la hora a las 00:00:00
            fechaFin = fechaFin.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            List<Viaje> viajesEnRango = new List<Viaje>();

            foreach (Viaje viaje in colViajes)
            {
                if (viaje.FechaHoraSalida >= fechaInicio && viaje.FechaHoraSalida <= fechaFin)
                {
                    viajesEnRango.Add(viaje);
                }
            }

            return viajesEnRango;
        }

        // Listar viajes por mes - año
        public List<Viaje> ObtenerViajesTerminalMesAnio(string codigoTerminal, int mes, int anio)
        {
            Terminal terminal = BuscarTerminal(codigoTerminal);

            if (terminal == null)
            {
                throw new Exception("La terminal no existe.");
            }

            List<Viaje> viajesEncontrados = new List<Viaje>();

            foreach (Viaje viaje in colViajes)
            {
                if (viaje.ViajeTerm == terminal && viaje.FechaHoraSalida.Month == mes && viaje.FechaHoraSalida.Year == anio)
                {
                    viajesEncontrados.Add(viaje);
                }
            }

            return viajesEncontrados;
        }


        #endregion
    }
}
