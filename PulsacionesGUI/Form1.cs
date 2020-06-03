using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace PulsacionesGUI
{
    
    public partial class Form1 : Form
    {
        Persona persona;
        PersonaService personaService = new PersonaService();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            crearPersona();
            TxtPulsacion.Text = Convert.ToString(personaService.CalcularPulsaciones(persona)); 
        }
        private void crearPersona()
        {
            persona = new Persona();
            persona.Identificacion = TxtIdentificacion.Text.Trim();
            persona.Nombre = TxtNombre.Text.Trim();
            persona.Edad = Convert.ToInt32(TxtEdad.Text.Trim());
            persona.Genero = Convert.ToChar(cmbSexo.SelectedItem);
            persona.Email = txtCorreo.Text.Trim();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            crearPersona();
            TxtPulsacion.Text = Convert.ToString(personaService.CalcularPulsaciones(persona));
            personaService.Guardar(persona);
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            personaService.Eliminar(TxtIdentificacion.Text.Trim());
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            crearPersona();
            TxtPulsacion.Text = Convert.ToString(personaService.CalcularPulsaciones(persona));
            personaService.Modificar(TxtIdentificacion.Text.Trim(), persona);
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
