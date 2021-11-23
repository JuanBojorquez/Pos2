using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoS
{
    public partial class Form1 : Form
    {
        public static String nombre;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text=="")
            {
               label3.Text= "Capture el usuario";
                textBox1.Focus();
            }
            else if(textBox2.Text == ""){
                label3.Text = "Capture la contraseña";
                textBox1.Focus();
            }
            else
            {
                label3.Text = "";
                try
                {
                    MySqlConnection mySqlConnection = new MySqlConnection("server=127.0.0.1; user=root; database=verificador_productos; SSL mode=none");
                    mySqlConnection.Open();
                    String query = "SELECT * FROM usuarios WHERE numero_de_empleado ='" + textBox1.Text + "' and apellido1 = '" + textBox2.Text+"'";
                    MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                    MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                    if (mySqlDataReader.Read())
                    {
                        nombre = mySqlDataReader.GetString(1);
                        //MessageBox.Show(nombre);
                        PuntoDeVenta principal = new PuntoDeVenta();
                        principal.Show();
                        this.Hide();
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                button1_Click(sender,e);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";
        }
    }
}
