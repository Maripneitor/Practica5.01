using System;
using System.IO;
using System.Windows.Forms;

namespace Practica5._01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();
            string apellidos = textBox2.Text.Trim();
            string estatura = textBox3.Text.Trim();
            string telefono = textBox4.Text.Trim();
            string genero = radioButton1.Checked ? "Masculino" : radioButton2.Checked ? "Femenino" : "";

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellidos) ||
                string.IsNullOrWhiteSpace(estatura) || string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(genero))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsAlpha(nombre) || !IsAlpha(apellidos))
            {
                MessageBox.Show("El nombre y los apellidos deben contener solo letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsNumeric(estatura) || !IsNumeric(telefono))
            {
                MessageBox.Show("La estatura y el teléfono deben ser valores numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string datosCompletos = $"Nombre: {nombre} {apellidos} ({estatura} cm) - Teléfono: {telefono} - Género: {genero}";
            GuardarEnArchivo(datosCompletos);
            MostrarDatosVentana(datosCompletos);
        }

        private bool IsAlpha(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsNumeric(string input)
        {
            return decimal.TryParse(input, out _);
        }

        private void GuardarEnArchivo(string datos)
        {
            string carpeta = @"C:\Visual";
            string archivo = Path.Combine(carpeta, "datos_usuario.txt");

            try
            {
                Directory.CreateDirectory(carpeta);
                File.AppendAllText(archivo, datos + Environment.NewLine);
                MessageBox.Show($"Datos guardados en {archivo}", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosVentana(string datos)
        {
            Form ventanaDatos = new Form();
            ventanaDatos.Text = "Datos Ingresados";
            ventanaDatos.Size = new System.Drawing.Size(400, 200);

            Label lblMostrarDatos = new Label
            {
                Text = datos,
                AutoSize = false,
                Width = 380,
                Height = 100,
                Location = new System.Drawing.Point(10, 10)
            };
            ventanaDatos.Controls.Add(lblMostrarDatos);

            Button btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new System.Drawing.Point(150, 120)
            };
            btnCerrar.Click += (s, args) => ventanaDatos.Close();
            ventanaDatos.Controls.Add(btnCerrar);

            ventanaDatos.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
    }
}
