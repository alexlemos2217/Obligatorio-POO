using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Viajes
{
    class Program
    {
        // Main
        public static void Main(string[] args)
        {
            // Objeto de lógica
            Logica logica = new Logica();

            int opcion = -1;
            
            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║                 MENÚ                 ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Mantenimiento");
                    Console.WriteLine("\t\t2. Agregar Viaje");
                    Console.WriteLine("\t\t3. Listados");
                    Console.WriteLine("\t\t0. Salir de la Aplicación");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 3);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            MostrarMenuMantenimiento(logica);
                            break;

                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                            Console.WriteLine("\t\t║           Agregar viaje              ║");
                            Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.WriteLine();

                            AgregarViaje(logica);
                            break;

                        case 3:
                            MostrarMenuListados(logica);
                            break;

                        case 0:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                            Console.WriteLine("\t\t║        HA OPTADO POR SALIR           ║");
                            Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.ReadLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        #region Operaciones auxiliares

        // Pedir un double
        public static double PidoNumero()
        {
            double numero;

            while (true)
            {
                try
                {
                    numero = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Número incorrecto: " + ex.Message);
                    Console.Write("Vuelva a ingresarlo: ");
                    Console.ResetColor();
                }
            }
            return numero;
        }

        // Pedir un entero
        public static int PidoNumero(string mensaje, int minimo, int maximo)
        {
            int numero;

            while (true)
            {
                try
                {
                    Console.Write(mensaje);
                    numero = Convert.ToInt32(Console.ReadLine());

                    if (numero < minimo || numero > maximo)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Debe ingresar un valor entre " + minimo + " y " + maximo);
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else
                        break;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            return numero;
        }

        // Operación para pedir un texto
        public static string PidoPalabra(string mensaje)
        {
            string palabra;

            while (true)
            {
                Console.Write(mensaje);
                palabra = Console.ReadLine().Trim();

                if (palabra == "")
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Debe ingresar una palabra");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                    break;
            }
            return palabra;
        }

        // Operación para dar la opción de salir del menú donde se encuentra
        public static bool SalirDeLaOpcion()
        {
            Console.Write("Ingrese la letra S si desea salir de la opción en la que se encuentra: ");
            return ("S" == Console.ReadLine().Trim().ToUpper());
        }

        // Operación que pide una fecha
        public static DateTime IngresoFecha(string mensaje)
        {
            DateTime fecha = DateTime.MinValue;
            bool fechaCorrecta = false;

            while (!fechaCorrecta)
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();

                if (EsFormatoFechaValido(entrada))
                {
                    fecha = Convert.ToDateTime(entrada);
                    fechaCorrecta = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Formato de fecha incorrecto. Inténtelo de nuevo.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }

            return fecha;
        }

        // Operación para verificar el formato de la fecha
        public static bool EsFormatoFechaValido(string entrada)
        {
            try
            {
                Convert.ToDateTime(entrada);
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error " + ex.Message);
                Console.ResetColor();
                return false;
            }
        }

        // Ingresar una fecha en el formato "dd/MM/yyyy"
        public static DateTime PidoFecha(string mensaje)
        {
            DateTime fecha;

            while (true)
            {
                Console.Write(mensaje);
                string fechaStr = Console.ReadLine();

                try
                {
                    fecha = Convert.ToDateTime(fechaStr);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de fecha incorrecto. Inténtelo de nuevo.");
                }
            }

            return fecha;
        }

        #endregion

        #region Menú

        // Mostrar menú mantenimiento
        public static void MostrarMenuMantenimiento(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║            MANTENIMIENTO             ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Compañías");
                    Console.WriteLine("\t\t2. Terminales");
                    Console.WriteLine("\t\t0. Volver al Menú Principal");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 2);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            MostrarMenuCompanias(logica);
                            break;

                        case 2:
                            MostrarMenuTerminales(logica);
                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        // Mostrar menú compañías
        public static void MostrarMenuCompanias(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║              COMPAÑÍAS               ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Buscar compañías por nombre");
                    Console.WriteLine("\t\t0. Volver al Menú de Mantenimiento");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 1);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                            Console.WriteLine("\t\t║    Buscar compañías por nombre       ║");
                            Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                            Console.ResetColor();

                            string nombreCompania = PidoPalabra("Ingrese el nombre de la compañía a buscar: ");
                            Compania compania =  logica.BuscarCompania(nombreCompania);

                            if (compania == null)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("\t\t║      No se encontró la compañia nacional en el sistema     ║");
                                Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════╝");
                                Console.ResetColor();
                                Console.WriteLine("\t\t Opciones disponibles:");
                                Console.WriteLine("\t\t 1. Agregar nueva compañía");
                                Console.WriteLine("\t\t 0. Volver al Menú de Compañías");
                                Console.WriteLine();

                                int opcionCompania = PidoNumero("Ingrese la opción deseada: ", 0, 1);
                                Console.Clear();

                                switch (opcionCompania)
                                {
                                    case 1:
                                        AgregarCompania(logica);
                                        Console.ReadLine();
                                        break;
                                    case 0:
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\t\t╔══════════════════════════════╗");
                                Console.WriteLine("\t\t║      Compañía encontrada     ║");
                                Console.WriteLine("\t\t╚══════════════════════════════╝");
                                Console.ResetColor();
                                Console.WriteLine(compania.ToString());
                                Console.ReadLine();

                                Console.WriteLine("\tOpciones disponibles:");
                                Console.WriteLine("\t1. Modificar compañía");
                                Console.WriteLine("\t2. Eliminar compañía");
                                Console.WriteLine("\t0. Volver al Menú de Compañías");
                                Console.WriteLine();

                                int opcionCompania = PidoNumero("Ingrese la opción deseada: ", 0, 2);
                                Console.Clear();

                                switch (opcionCompania)
                                {
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("\t\t╔══════════════════════════════╗");
                                        Console.WriteLine("\t\t║      Modificar compañía      ║");
                                        Console.WriteLine("\t\t╚══════════════════════════════╝");
                                        Console.ResetColor();
                                        Console.WriteLine();
                                        ModificarCompania(logica, compania);
                                        break;

                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                                        Console.WriteLine("\t\t╔══════════════════════════════╗");
                                        Console.WriteLine("\t\t║      Eliminar compañía       ║");
                                        Console.WriteLine("\t\t╚══════════════════════════════╝");
                                        Console.ResetColor();
                                        Console.WriteLine();

                                        EliminarCompania(logica, compania);

                                        break;
                                    case 0:
                                        break;

                                    default:
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                                        Console.ResetColor();
                                        Console.ReadLine();
                                        break;
                                }
                            }
                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        // Mostrar menú terminales
        public static void MostrarMenuTerminales(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║            TERMINALES                ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Terminales Nacionales");
                    Console.WriteLine("\t\t2. Terminales Internacionales");
                    Console.WriteLine("\t\t0. Volver al Menú de Mantenimiento");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 2);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            MostrarMenuTerminalesNacionales(logica);
                            break;

                        case 2:
                            MostrarMenuTerminalesInternacionales(logica);
                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        // Mostrar menú terminales nacionales
        public static void MostrarMenuTerminalesNacionales(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║        TERMINALES NACIONALES         ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Buscar terminal nacional por código");
                    Console.WriteLine("\t\t0. Volver al Menú de Terminales");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 1);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t║    Buscar terminal nacional por código     ║");
                            Console.WriteLine("\t\t╚════════════════════════════════════════════╝");
                            Console.ResetColor();

                            string codigoTerminal = PidoPalabra("Ingrese el código de la terminal nacional: ");
                            Terminal terminal = logica.BuscarTerminal(codigoTerminal);

                            if (terminal != null && terminal is Terminal_Nacional)
                            {
                                Terminal_Nacional terminalNacional = (Terminal_Nacional)terminal;

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\t\t╔═══════════════════════╗");
                                Console.WriteLine("\t\t║  Terminal encontrada  ║");
                                Console.WriteLine("\t\t╚═══════════════════════╝");
                                Console.ResetColor();
                                Console.WriteLine(terminalNacional.ToString());
                                Console.ReadLine();
                                Console.WriteLine("Opciones disponibles:");
                                Console.WriteLine("\t1. Modificar terminal");
                                Console.WriteLine("\t2. Eliminar terminal");
                                Console.WriteLine("\t0. Volver al Menú de Terminales");
                                Console.WriteLine();

                                int opcionTerminal = PidoNumero("Ingrese la opción deseada: ", 0, 2);

                                switch (opcionTerminal)
                                {
                                    case 1:
                                        Console.Clear();
                                        ModificarTerminalNacional(logica, terminalNacional);
                                        break;
                                    case 2:
                                        EliminarTerminal(logica, terminalNacional);
                                        break;
                                    case 0:
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("\t\t║      No se encontró la terminal nacional en el sistema     ║");
                                Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════╝");
                                Console.ResetColor();
                                Console.WriteLine("Opciones disponibles:");
                                Console.WriteLine("\t1. Agregar nueva terminal nacional");
                                Console.WriteLine("\t0. Volver al Menú de Terminales");
                                Console.WriteLine();

                                int opcionTerminal = PidoNumero("Ingrese la opción deseada: ", 0, 1);

                                switch (opcionTerminal)
                                {
                                    case 1:
                                        AgregarTerminal(logica);
                                        break;
                                    case 0:
                                        break;
                                }
                            }

                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        // Mostrar menú terminales Internacionales
        public static void MostrarMenuTerminalesInternacionales(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║    TERMINALES INTERNACIONALES        ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Buscar terminal internacional por código");
                    Console.WriteLine("\t\t0. Volver al Menú de Terminales");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 1);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t║  Buscar terminal internacional por código  ║");
                            Console.WriteLine("\t\t╚════════════════════════════════════════════╝");
                            Console.ResetColor();
                            string codigoTerminal = PidoPalabra("Ingrese el código de la terminal internacional: ");
                            Terminal terminal = logica.BuscarTerminal(codigoTerminal);

                            if (terminal != null && terminal is Terminal_Internacional)
                            {
                                Terminal_Internacional terminalInternacional = (Terminal_Internacional)terminal;

                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("\t\t╔═══════════════════════╗");
                                Console.WriteLine("\t\t║  Terminal encontrada  ║");
                                Console.WriteLine("\t\t╚═══════════════════════╝");
                                Console.ResetColor();
                                Console.WriteLine(terminalInternacional.ToString());
                                Console.ReadLine();
                                Console.WriteLine("Opciones disponibles:");
                                Console.WriteLine("\t1. Modificar terminal");
                                Console.WriteLine("\t2. Eliminar terminal");
                                Console.WriteLine("\t0. Volver al Menú de Terminales");
                                Console.WriteLine();

                                int opcionTerminal = PidoNumero("Ingrese la opción deseada: ", 0, 2);

                                switch (opcionTerminal)
                                {
                                    case 1:
                                        Console.Clear();
                                        ModificarTerminalInternacional(logica, terminalInternacional);
                                        break;
                                    case 2:
                                        EliminarTerminal(logica, terminalInternacional);
                                        break;
                                    case 0:
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("\t\t║   No se encontró la terminal internacional en el sistema   ║");
                                Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════╝");
                                Console.ResetColor();
                                Console.WriteLine("Opciones disponibles:");
                                Console.WriteLine("\t1. Agregar nueva terminal internacional");
                                Console.WriteLine("\t0. Volver al Menú de Terminales");
                                Console.WriteLine();

                                int opcionTerminal = PidoNumero("Ingrese la opción deseada: ", 0, 1);

                                switch (opcionTerminal)
                                {
                                    case 1:
                                        AgregarTerminalInt(logica);
                                        break;
                                    case 0:
                                        break;
                                }
                            }

                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }


        //Mostrar menú listados
        public static void MostrarMenuListados(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║               LISTADOS               ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Todas las Compañías");
                    Console.WriteLine("\t\t2. Terminales");
                    Console.WriteLine("\t\t3. Viajes");
                    Console.WriteLine("\t\t0. Volver al Menú Principal");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 3);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔═════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t║               Mostrar todas las compañías del sistema               ║");
                            Console.WriteLine("\t\t╚═════════════════════════════════════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.WriteLine();

                            List<Compania> companiasV;

                            if (logica.ContarCompanias() > 0)
                            {
                                Console.WriteLine("Listado de compañias");

                                companiasV = logica.OrdenarPorNombre();
                                Console.WriteLine();

                                foreach (var variable in companiasV)
                                {
                                    Console.WriteLine(variable.ToString());
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\tNo hay compañias registradas en el sistema");
                                Console.ResetColor();
                            }

                            Console.ReadLine();
                            break;

                        case 2:
                            MostrarMenuListadoTerminales(logica);
                            break;

                        case 3:
                            MostrarMenuListadoViajes(logica);
                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        // Mostrar menú listado terminales
        public static void MostrarMenuListadoTerminales(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║             TERMINALES               ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Terminales Nacionales");
                    Console.WriteLine("\t\t2. Terminales Internacionales");
                    Console.WriteLine("\t\t0. Volver al Menú de Listados");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 2);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔══════════════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t║    Mostrar todas las terminales nacionales y la cantidad de viajes asociados     ║");
                            Console.WriteLine("\t\t╚══════════════════════════════════════════════════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.WriteLine();

                            List<Terminal_Nacional> terminalesNacionales = logica.ListarTerminalesNacionales();

                            if (terminalesNacionales.Count > 0)
                            {
                                Console.WriteLine("Listado de terminales nacionales:");
                                Console.WriteLine();

                                foreach (Terminal_Nacional terminal in terminalesNacionales)
                                {
                                    Console.WriteLine(terminal.ToString());
                                    Console.WriteLine("Cantidad de viajes asociados: " + logica.ObtenerViajesPorTerminal(terminal).Count);
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\tNo hay terminales nacionales registradas en el sistema");
                                Console.ResetColor();
                            }

                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t║    Mostrar todas las terminales internacionales y la cantidad de viajes asociados     ║");
                            Console.WriteLine("\t\t╚═══════════════════════════════════════════════════════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.WriteLine();

                            List<Terminal_Internacional> terminalesInternacionales = logica.ListarTerminalesInternacionales();

                            if (terminalesInternacionales.Count > 0)
                            {
                                Console.WriteLine("Listado de terminales internacionales:");
                                Console.WriteLine();

                                foreach (Terminal_Internacional terminal in terminalesInternacionales)
                                {
                                    Console.WriteLine(terminal.ToString());
                                    Console.WriteLine("Cantidad de viajes asociados: " + logica.ObtenerViajesPorTerminal(terminal).Count);
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("\tNo hay terminales internacionales registradas en el sistema");
                                Console.ResetColor();
                            }
                            Console.ReadLine();
                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        // Mostrar menú listado viajes
        public static void MostrarMenuListadoViajes(Logica logica)
        {
            int opcion = -1;

            while (opcion != 0)
            {
                try
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                    Console.WriteLine("\t\t║               VIAJES                 ║");
                    Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                    Console.ResetColor();
                    Console.WriteLine("\t\t1. Por Fecha");
                    Console.WriteLine("\t\t2. Por Terminal, Mes y Año");
                    Console.WriteLine("\t\t0. Volver al Menú de Listados");
                    Console.WriteLine();

                    opcion = PidoNumero("Ingrese la opción deseada: ", 0, 2);
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t║      Mostrar todos los viajes dentro de un rango de fechas     ║");
                            Console.WriteLine("\t\t╚════════════════════════════════════════════════════════════════╝");
                            Console.ResetColor();
                            Console.WriteLine();

                            DateTime fechaInicio = PidoFecha("Ingrese la fecha de inicio (dd/MM/yyyy): ");
                            DateTime fechaFin = PidoFecha("Ingrese la fecha de fin (dd/MM/yyyy): ");

                            // Obtener los viajes en el rango de fechas desde la capa lógica
                            List<Viaje> viajesEnRango = logica.ObtenerViajesPorFecha(fechaInicio, fechaFin);
                            
                            // Mostrar los viajes
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔══════════════════════════════════════╗");
                            Console.WriteLine("\t\t║      Listado de viajes por fecha     ║");
                            Console.WriteLine("\t\t╚══════════════════════════════════════╝");
                            Console.ResetColor();
                
                            if (viajesEnRango.Count > 0)
                            {
                                foreach (Viaje viaje in viajesEnRango)
                                {
                                    Console.WriteLine(viaje.ToString());
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("No se encontraron viajes dentro del rango de fechas especificado.");
                                Console.ResetColor();
                            }

                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\t\t╔═══════════════════════════════════════════════════════════╗");
                            Console.WriteLine("\t\t║      Mostrar todos los viajes por terminal, mes y año     ║");
                            Console.WriteLine("\t\t╚═══════════════════════════════════════════════════════════╝");
                            Console.ResetColor();

                            ListadoViajesTerminalMesAnioMenu(logica);
                            break;

                        case 0:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opción incorrecta. " + ex.Message);
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
        }

        #endregion

        #region Compañías

        // Agregar compañia
        public static void AgregarCompania(Logica logica)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\tIngrese los datos de la compañía: ");
                    string nombre = PidoPalabra("Nombre: ");
                    string direccion = PidoPalabra("Direccion: ");
                    string telefono = PidoPalabra("Teléfono: ");

                    Compania compania = new Compania(nombre, direccion, telefono);

                    if (logica.AgregarCompania(compania))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\tCompañía agregada correctamente.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tLa compañía ya existe en el sistema.");
                        Console.ResetColor();
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();

                    if (SalirDeLaOpcion())
                    {
                        break;
                    }
                }
            }
        }

        // Buscar compañía
        public static void BuscarCompania(Logica logica)
        {
            while (true)
            {
                try
                {
                    string nombre = PidoPalabra("Ingrese el nombre de la compañia a buscar: ");

                    Compania compania = logica.BuscarCompania(nombre);

                    if (compania == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No se encontró la compañía en el sistema.");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Compañía encontrada:");
                        Console.WriteLine("Nombre: " + compania.Nombre);
                        Console.WriteLine("Dirección: " + compania.Direccion);
                        Console.WriteLine("Teléfono: " + compania.Telefono);
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();

                    if (SalirDeLaOpcion())
                    {
                        break;
                    }
                }

            }
        }

        // Modificar compañía
        public static void ModificarCompania(Logica logica, Compania compania)
        {
            bool modificar;

            while (true)
            {
                try
                {
                    // Dirección
                    Console.Write("Ingrese la letra S si desea modificar la dirección: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        compania.Direccion = PidoPalabra("Ingrese la nueva dirección: ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("La dirección se modificó con éxito.");
                        Console.ResetColor();
                    }

                    // Teléfono
                    Console.Write("Ingrese la letra S si desea modificar el teléfono: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        compania.Telefono = PidoPalabra("Teléfono: ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("El teléfono se modificó con éxito.");
                        Console.ResetColor();
                    }

                    Console.WriteLine("\nDatos actuales de la compañía:");
                    Console.WriteLine("\n" + compania.ToString());
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        // Eliminar compañía
        public static void EliminarCompania(Logica logica, Compania compania)
        {
            try
            {
                if (logica.Eliminar(compania))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Eliminación correcta");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error - En Eliminar - Logica");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        #endregion

        #region Viajes

        // Agregar viaje
        public static void AgregarViaje(Logica logica)
        {
            while (true)
            {
                try
                {
                    string compania = PidoPalabra("Ingrese el nombre de la compañia que lo realiza: ");
                    Compania unaComp = logica.BuscarCompania(compania);
                    if (unaComp == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tNo se encontró la compañía en el sistema.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    }

                    string codigoTerminal = PidoPalabra("Ingrese el código de la terminal: ");
                    Terminal unaTerm = logica.BuscarTerminal(codigoTerminal);
                    if (unaTerm == null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tNo se encontró la terminal en el sistema.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    }

                    Console.WriteLine("Ingrese los datos del viaje: ");

                    DateTime fechaHoraSalida;
                    DateTime fechaHoraLlegada;
                    int pasajeros;
                    double precioBoleto;
                    int anden;

                    // Bucle para asegurarse de que el usuario ingrese fechas y horas válidas
                    while (true)
                    {
                        try
                        {
                            fechaHoraSalida = IngresoFecha("Ingrese la fecha y hora de salida dd/MM/yyyy HH:mm:ss: ");
                            fechaHoraLlegada = IngresoFecha("Ingrese la fecha y hora de llegada dd/MM/yyyy HH:mm:ss: ");

                            // Obtener la fecha actual
                            DateTime hoy = DateTime.Today;

                            // Calcular tres años antes de hoy
                            DateTime tresAniosAtras = hoy.AddYears(-3);

                            // Calcular tres meses a partir del día de hoy
                            DateTime tresMesesDespues = hoy.AddMonths(3);

                            // Verificar el rango de las fechas
                            if (fechaHoraSalida >= tresAniosAtras && fechaHoraSalida <= tresMesesDespues &&
                                fechaHoraLlegada >= tresAniosAtras && fechaHoraLlegada <= tresMesesDespues)
                            {
                                // Verificar si la diferencia entre fecha de salida y fecha de llegada es menor o igual a 5 días
                                if ((fechaHoraLlegada - fechaHoraSalida).TotalDays <= 5)
                                {
                                    break; // Si las fechas son válidas, sale del bucle
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("La diferencia entre la fecha de salida y la fecha de llegada no debe superar los 5 días. Intente nuevamente.");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Las fechas deben estar dentro de tres años antes de hoy y tres meses después de hoy. Intente nuevamente.");
                                Console.ResetColor();
                            }
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Fecha y/u hora inválida. Intente nuevamente.");
                            Console.ResetColor();
                        }
                    }

                    pasajeros = PidoNumero("Ingrese la cantidad de pasajeros: ", 0, 50);

                    // Bucle para asegurarse de que el usuario ingrese un precio válido
                    while (true)
                    {
                        try
                        {
                            Console.Write("Ingrese el precio del boleto: ");
                            precioBoleto = PidoNumero();
                            break;
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Precio inválido. Intente nuevamente.");
                            Console.ResetColor();
                        }
                    }

                    anden = PidoNumero("Ingrese el número de Anden: ", 0, 35);

                    Viaje viaje = new Viaje(fechaHoraSalida, fechaHoraLlegada, pasajeros, precioBoleto, anden, unaTerm, unaComp);

                    if (logica.AgregarViaje(viaje, compania, codigoTerminal))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\tViaje agregado con éxito.");
                        Console.ResetColor();
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\nNo se realizó el alta");
                        Console.ResetColor();
                        Console.ReadLine();
                        if (SalirDeLaOpcion())
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();
                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        // Listado de viajes por rango de fechas
        public static void ListadoViajesPorFecha(List<Viaje> listaViajes, DateTime fechaInicio, DateTime fechaFin)
        {
            Console.Clear();
            Console.WriteLine("Listado de viajes por fecha:");

            bool seEncontraronViajes = false;

            foreach (Viaje viaje in listaViajes)
            {
                if (viaje.FechaHoraSalida >= fechaInicio && viaje.FechaHoraSalida <= fechaFin)
                {
                    Console.WriteLine(viaje.ToString());
                    seEncontraronViajes = true;
                }
            }

            if (!seEncontraronViajes)
            {
                Console.WriteLine();
                Console.WriteLine("No se encontraron viajes dentro del rango de fechas especificado.");
            }
        }

        // Buscar terminales - mes - año
        public static void ListadoViajesTerminalMesAnioMenu(Logica logica)
        {
            string codigoTerminal = "";
            bool codigoValido = false;

            while (!codigoValido)
	        {
	            codigoTerminal = PidoPalabra("Ingrese el código de la terminal: ");

                if (codigoTerminal.Length == 6)
                {
                    codigoValido = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("El código debe tener 6 caracteres, intente nuevamente");
                    Console.ResetColor();
                    Console.ReadLine();
                }
	        }

            int mes = 0;
            bool mesValido = false;

            while (!mesValido)
            {
                mes = PidoNumero("Ingrese el mes: ", 1, 12);

                if (mes >= 1 && mes <= 12)
                {
                    mesValido = true;
                }
            }

            int anio = 0;
            bool anioValido = false;

            while (!anioValido)
            {
                anio = PidoNumero("Ingrese el año: ", 2000, 2023);
                anioValido = true;
            }
            

            List<Viaje> viajes = logica.ObtenerViajesTerminalMesAnio(codigoTerminal, mes, anio);

            if (viajes.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Listado de viajes para la terminal " + codigoTerminal + " - " + mes + "/" + anio + ":");
                Console.WriteLine();

                foreach (Viaje viaje in viajes)
                {
                    Console.WriteLine(viaje.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No se encontraron viajes para la terminal " + codigoTerminal + " en el mes " + mes + "/" + anio + ".");
            }

            Console.ReadLine();
        }

        #endregion

        #region Terminales

        // Agregar terminal nacional
        public static void AgregarTerminal(Logica logica)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los datos de la terminal: ");

                    string codigo = "";
                    while (true)
                    {
                        codigo = PidoPalabra("Codigo: ");
                        if (codigo.Length == 6)
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("El código debe tener exactamente 6 caracteres.");
                            Console.ResetColor();
                        }
                    }
                    
                    string ciudad = PidoPalabra("Ciudad de destino: ");

                    bool tieneTaxi = false;
                    while (true)
                    {
                        Console.WriteLine("¿La terminal tiene taxi? (S/N): ");
                        string input = Console.ReadLine();

                        if (input.ToLower() == "s")
                        {
                            tieneTaxi = true; // La terminal tiene taxi
                            break;
                        }
                        else if (input.ToLower() == "n")
                        {
                            tieneTaxi = false; // La terminal no tiene taxi
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\tOpción inválida. Por favor, ingrese 'S' o 'N'.");
                            Console.ResetColor();
                        }
                    }

                    Terminal_Nacional terminal = new Terminal_Nacional(codigo, ciudad, tieneTaxi);
                    bool agregado = logica.Agregar(terminal); // Agregar la terminal a la colección en la clase Logica

                    if (agregado)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\tTerminal creada con éxito.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tNo se pudo agregar la terminal. Ya existe una terminal con el mismo código.");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                    Console.ReadLine();
                    break;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();

                    if (SalirDeLaOpcion())
                    {
                        break;
                    }
                }
            }
        }

        // Agregar terminal internacional
        public static void AgregarTerminalInt(Logica logica)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los datos de la terminal: ");
                    string codigo = "";
                    while (true)
                    {
                        codigo = PidoPalabra("Codigo: ");
                        if (codigo.Length == 6)
                        {
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("El código debe tener exactamente 6 caracteres.");
                            Console.ResetColor();
                        }
                    }

                    string ciudad = PidoPalabra("Ciudad de destino: ");
                    string pais = PidoPalabra("País: ");

                    Terminal_Internacional terminal = new Terminal_Internacional(codigo, ciudad, pais);
                    bool agregado = logica.Agregar(terminal);

                    if (agregado)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\tTerminal creada con éxito.");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\tNo se pudo agregar la terminal. Ya existe una terminal con el mismo código.");
                        Console.ResetColor();
                        Console.ReadLine();
                    }
                    Console.WriteLine();

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine();

                    if (SalirDeLaOpcion())
                    {
                        break;
                    }
                }
            }
        }

        // Buscar terminal
        public static void BuscarTerminal(Logica logica)
        {
            Console.WriteLine("Ingrese el código de la terminal: ");
            string codigoTerminal = Console.ReadLine();

            Terminal terminal = logica.BuscarTerminal(codigoTerminal);

            if (terminal != null)
            {
                Console.WriteLine("Terminal encontrada:");
                Console.WriteLine("Código: " + terminal.Codigo);
                Console.WriteLine("Ciudad de destino: " + terminal.Ciudad);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No se encontró la terminal en el sistema.");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        // Eliminar terminal
        public static void EliminarTerminal(Logica logica, Terminal terminal)
        {
            try
            {
                if (logica.Eliminar(terminal))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Eliminación correcta");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else
                {
                    throw new Exception("Error al elminar terminal");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        // Modificar terminal internacional
        public static void ModificarTerminalInternacional(Logica logica, Terminal_Internacional terminal)
        {
            bool modificar;

            while (true)
            {
                try
                {
                    // Ciudad
                    Console.Write("Ingrese la letra S si desea modificar la ciudad: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        terminal.Ciudad = PidoPalabra("Ingrese la nueva ciudad: ");
                    }

                    // País
                    Console.Write("Ingrese la letra S si desea modificar el país: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        terminal.Pais = PidoPalabra("Ingrese el nuevo país: ");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\tLa terminal se modificó con éxito.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("\tDatos actuales de la terminal:");
                    Console.WriteLine("\n" + terminal.ToString());
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        // Modificar terminal nacional
        public static void ModificarTerminalNacional(Logica logica, Terminal_Nacional terminal)
        {
            bool modificar;

            while (true)
            {
                try
                {
                    // Ciudad
                    Console.Clear();
                    Console.Write("Ingrese la letra S si desea modificar la ciudad: ");
                    modificar = ("S" == Console.ReadLine().Trim().ToUpper());

                    if (modificar)
                    {
                        Console.Clear();
                        terminal.Ciudad = PidoPalabra("Ingrese la nueva ciudad: ");
                    }

                    // Taxi
                    Console.Clear();
                    Console.Write("Ingrese la letra S si la terminal tiene taxis (S/N): ");
                    string respuesta = Console.ReadLine().Trim().ToUpper();

                    if (respuesta == "S")
                    {
                        Console.Clear();
                        terminal.Taxi = true;
                    }
                    else if (respuesta == "N")
                    {
                        Console.Clear();
                        terminal.Taxi = false;
                    }
                    else
                    {
                        throw new Exception("Respuesta inválida. Debe ingresar S o N.");
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\tLa terminal se modificó con éxito.");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("\tDatos actuales de la terminal:");
                    Console.WriteLine("\n" + terminal.ToString());
                    Console.ReadLine();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();

                    if (SalirDeLaOpcion())
                        break;
                }
            }
        }

        #endregion
    }
}
