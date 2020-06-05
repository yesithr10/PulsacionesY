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
            try
            {
                persona = new Persona();
                persona.Identificacion = TxtIdentificacion.Text.Trim();
                persona.Nombre = TxtNombre.Text.Trim();
                persona.Edad = Convert.ToInt32(TxtEdad.Text.Trim());
                persona.Genero = cmbSexo.SelectedItem.ToString();
                persona.Email = txtCorreo.Text.Trim();
            }
            catch (Exception)
            {
                MessageBox.Show("Los datos son incorrectos", "Datos erroneos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            crearPersona();
            TxtPulsacion.Text = Convert.ToString(personaService.CalcularPulsaciones(persona));
            try
            {
                personaService.Guardar(persona);
                MessageBox.Show("Persona guardada satisfactoriamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo guardar esta persona", "Guardado incorectamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Guardar Informe";
            saveFileDialog.InitialDirectory = @"c:/document";
            saveFileDialog.DefaultExt = "pdf";
            string filename = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;
                if (filename != "" && personaService.Leer().Count > 0)
                {
                    string mensaje = personaService.GenerarPdf(personaService.Leer(), filename);

                    MessageBox.Show(mensaje, "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("No se especifico una ruta o No hay datos para generar el reporte", "Generar Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
