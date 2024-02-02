using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Viajes
{
    public class Viaje
    {
        // Atributo de clase - static - (identificador de los viajes)
        private static long idViaje = 1;

        // Atributos de instancia
        private long codigoViaje;
        private DateTime fechaHoraSalida;
        private DateTime fechaHoraLlegada;
        private int maxPasajeros;
        private double precioBoleto;
        private int anden;

        // Atributo de asociación
        private Terminal viajeTerm;
        private Compania viajeComp;

        // Propiedades
        public long CodigoViaje
        {
            // Solo va a tener get porque no interesa que le seteen valor
            get { return codigoViaje; }
        }

        #region Validacion de fechas

        public DateTime FechaHoraSalida
        {
            get { return fechaHoraSalida; }
            set
            {
                // Obtengo la fecha de hoy
                DateTime fechaActual = DateTime.Now;

                // Rango de fechas permitido
                DateTime fechaMinima = fechaActual.AddYears(-3);
                DateTime fechaMaxima = fechaActual.AddMonths(3);

                // Validar que la fecha esté en el rango
                if (value >= fechaMinima && value <= fechaMaxima)
                {
                    fechaHoraSalida = value;
                }
                else
                {
                    throw new Exception("La fecha y hora de salida deben estar en un rango de 3 años anteriores al día de hoy y tres meses posteriores");
                }
            }
        }

        public DateTime FechaHoraLlegada
        {
            get { return fechaHoraLlegada; }
            set
            {
                // Obtengo la fecha de hoy
                DateTime fechaActual = DateTime.Now;
                DateTime fechaAproxLlegada = FechaHoraSalida.AddDays(5);

                if (value > FechaHoraSalida && value <= fechaAproxLlegada)
                {
                    fechaHoraLlegada = value;
                }
                else
                {
                    throw new Exception("La fecha y hora de llegada deben ser posteriores al horario de salida y no deberán superar los 5 días");
                }
            }
        }

        #endregion

        public int MaxPasajeros
        {
            get { return maxPasajeros; }
            set
            {
                if (value > 0 && value <= 50)
                {
                    maxPasajeros = value;
                }
                else
                {
                    throw new Exception("La cantidad de pasajeros deber estar entre 1 y 50");
                }
            }
        }

        public double PrecioBoleto
        {
            get { return precioBoleto; }
            set
            {
                if (value >= 0)
                {
                    precioBoleto = value;
                }
                else
                {
                    throw new Exception("El precio del boleto no puede ser negativo");
                }
            }
        }

        public int Anden
        {
            get { return anden; }
            set
            {
                if (value > 0 && value <= 35)
                {
                    anden = value;
                }
                else
                {
                    throw new Exception("El anden debe estar entre 1 y 35");
                }
            }
        }

        public Terminal ViajeTerm
        {
            get { return viajeTerm; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un valor");

                viajeTerm = value;
            }
        }

        public Compania ViajeComp
        {
            get { return viajeComp; }
            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar un valor");

                viajeComp = value;
            }
        }

        // Constructor (no va a ser completo porque al código se lo ingreso)
        public Viaje(DateTime vFechaHoraSalida, DateTime vFechaHoraLlegada, int vMaxPasajeros, double vPrecioBoleto, int vAnden, Terminal vTerminal, Compania vCompanias)
        {
            codigoViaje = idViaje;
            FechaHoraSalida = vFechaHoraSalida;
            FechaHoraLlegada = vFechaHoraLlegada;
            MaxPasajeros = vMaxPasajeros;
            PrecioBoleto = vPrecioBoleto;
            Anden = vAnden;
            ViajeTerm = vTerminal;
            ViajeComp = vCompanias;
            idViaje++;
        }

        // Operaciones
        public override string ToString()
        {
            return ("Código de viaje: " + codigoViaje + "\nFecha y hora de salida: " + FechaHoraSalida + "\nFecha y hora de llegada: " + FechaHoraLlegada + "\nCantidad de pasajeros: " + MaxPasajeros + "\nPrecio del boleto: " + PrecioBoleto + "\nAnden: " + Anden + "\nTerminal de destino: " + ViajeTerm.Ciudad + "\nCompañía: " + ViajeComp.Nombre + "\n");
        }
    }
}
