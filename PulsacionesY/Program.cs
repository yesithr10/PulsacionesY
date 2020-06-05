using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;

namespace PulsacionesY
{
    class Program
    {

        static Persona persona;
        static PersonaService personaService = new PersonaService();
        static List<Persona> lPersona = new List<Persona>();
    static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
           
            int respuesta;
            do
            {
            Console.WriteLine("*** MENU ***");
            Console.WriteLine("1. Registrar");
            Console.WriteLine("2. Consultar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. SALIR");
            respuesta = Convert.ToInt32(Console.ReadLine());
                switch (respuesta)
                {
                case 1: Registrar();
                break;
                case 2: Consultar();
                break;
                case 3: Eliminar();
                break;
                case 4: Console.WriteLine("Gracias por usarnos ");
                break;
                default: Console.WriteLine("Opcion incorrecta, intente una opcion valida");
                break;
                }
            }while (respuesta != 4);
        }
        public static void Registrar()
        {
            Console.Clear();
            persona = new Persona();
            Console.WriteLine("Digite su cedula");
            persona.Identificacion = Console.ReadLine();
            Console.WriteLine("Digite su nombre");
            persona.Nombre = Console.ReadLine();
            Console.WriteLine("Digite su edad");
            persona.Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite su sexo M/F");
            persona.Genero = Console.ReadLine().ToUpper();
            Console.WriteLine($"Sus pulsaciones son: {personaService.CalcularPulsaciones(persona)}");
            personaService.Guardar(persona);
        }
        public static void Consultar()
        {
            lPersona = personaService.Leer();
            foreach (Persona persona in lPersona)
            {
                Console.WriteLine($"********************");
                Console.WriteLine($"Idenficacion es: {persona.Identificacion}");
                Console.WriteLine($"Nombre es: {persona.Nombre}");
                Console.WriteLine($"Edad es: {persona.Edad}");
                Console.WriteLine($"Genero es: {persona.Genero}");
                Console.WriteLine($"Pulsaciones es: {persona.Pulsacion}");
            }
            Console.ReadKey();
        }
        public static void Eliminar()
        {
            string identificacion;
            int z=0;
            Console.WriteLine("Digite la identificacion del que desea eliminar");
            identificacion = Console.ReadLine();
            foreach (Persona persona in lPersona)
            {
                if (persona.Identificacion.Equals(identificacion))
                {
                    personaService.Eliminar(identificacion);
                    z = 1;
                }
            }
            if (z == 0)
            {
                Console.WriteLine("Esta persona no existe");
            }
            else
            {
                Console.WriteLine("Persona eliminada correctamente");
            }
        }
        public static void Modificar()
        {
            string identificacion;
            Console.Clear();
            Console.WriteLine(".: MODIFICAR :.");
            Console.WriteLine("Digite la identificación de la persona que desea modificar");
            identificacion = Console.ReadLine();

            lPersona = personaService.Leer();
            foreach (Persona persona in lPersona)
            {
                if (persona.Identificacion.Equals(identificacion))
                {
                    Console.WriteLine($"Identificación: {persona.Identificacion}");
                    Console.WriteLine($"Nombre: {persona.Nombre}");
                    Console.WriteLine($"Edad: {persona.Edad}");
                    Console.WriteLine($"Sexo: {persona.Genero}");
                    Console.WriteLine($"Pulsación: {persona.Pulsacion}");

                    Console.WriteLine("Nombre: ");
                    persona.Nombre = Console.ReadLine();
                    Console.WriteLine("Edad: ");
                    persona.Edad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Sexo: M|F");
                    persona.Genero = Console.ReadLine().ToUpper();


                    Console.WriteLine(personaService.CalcularPulsaciones(persona));

                    personaService.Modificar(identificacion, persona);

                    Console.ReadKey();

                    break;
                }
            }

            Consultar();
        }

    }
        
}
    
