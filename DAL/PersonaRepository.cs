using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
namespace DAL
{
    public class PersonaRepository
    {
        string ruta = "persona.txt";
        public void Guardar(Persona persona)
        {
            FileStream file = new FileStream(ruta,FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Edad};{persona.Genero};{persona.Pulsacion};{persona.Email}");
            escritor.Close();
            file.Close();
        }
        public List<Persona> Leer()
        {
            List<Persona> lPersonas = new List<Persona>();
            string linea;

            TextReader lector;
            lector = new StreamReader(ruta);

            while ((linea = lector.ReadLine()) != null)
            {
                Persona persona = new Persona();
                char delimitador = ';';
                string[] arrayPersona = linea.Split(delimitador);

                persona.Identificacion = arrayPersona[0];
                persona.Nombre = arrayPersona[1];
                persona.Edad = Convert.ToInt32(arrayPersona[2]);
                persona.Genero = arrayPersona[3];
                persona.Pulsacion = Convert.ToDecimal(arrayPersona[4]);
                persona.Email = arrayPersona[5];
                lPersonas.Add(persona);
            }
            lector.Close();
            return lPersonas;
        }
        public void Eliminar(string identificacion)
        {
            List<Persona> lPersona = new List<Persona>();
            lPersona = Leer();

            FileStream file = new FileStream(ruta, FileMode.Create);
            StreamWriter escritor = new StreamWriter(file);

            foreach (Persona persona in lPersona)
            {
                if (persona.Identificacion.Equals(identificacion))
                {
                    lPersona.Remove(persona);
                    break;
                }
            }

            foreach (Persona persona in lPersona)
            {
                escritor.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Edad};{persona.Genero};{persona.Pulsacion}");
            }

            escritor.Close();
            file.Close();
        }
        public void Modificar(string identificacion, Persona persona)
        {
            Eliminar(identificacion);
            Guardar(persona);
        }
    }
}
