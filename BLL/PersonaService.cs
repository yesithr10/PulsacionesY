using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using Infraestructura;

namespace BLL
{
    public class PersonaService
    {
        Email email = new Email();
        string mensajeEmail = String.Empty;
        PersonaRepository personaRepository;
        public decimal CalcularPulsaciones(Persona persona)
        {
            decimal divisor = 10;
            if (persona.Genero.Equals("M"))
            {
                persona.Pulsacion = (210 - persona.Edad) / divisor;
                return persona.Pulsacion;
            }
            else
            {
                persona.Pulsacion = (220 - persona.Edad) / divisor;
                return persona.Pulsacion;
            }
        }
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }

        public string Guardar(Persona persona)
        {
            
            try
            {
                personaRepository.Guardar(persona);
                mensajeEmail = email.EnviarEmail(persona);
                return ($"los datos de la {persona.Nombre} se han guardado satisfactoriamente " + mensajeEmail);
            }
            catch(Exception e)
            {
                return ($"Eror de datos: {e.Message}");
            }
        }
        public List<Persona> Leer()
        {
            return personaRepository.Leer();
        }
        public void Eliminar(string identificacion)
        {
            personaRepository.Eliminar(identificacion);
        }
        public void Modificar(string identificacion,Persona persona)
        {
            personaRepository.Modificar(identificacion,persona);
        }
        public string GenerarPdf(List<Persona> personas, string filename)
        {
            ArchivoPdf archivoPdf = new ArchivoPdf();
            try
            {
                Persona persona = new Persona();
                archivoPdf.GuardarPdf(personas, filename);
                mensajeEmail = email.EnviarEmailPDF();
                return "Archivo generado con exito " + mensajeEmail;
            }
            catch (Exception e)
            {

                return "Error al crear docuemnto" + e.Message;
            }
        }

    }
}
