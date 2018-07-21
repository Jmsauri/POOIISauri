using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProgramacionOrientadaObjetosII
{
	public partial class Verificador : Form
	{
		private string codigo = "";
		private bool codigoencontrado = false;
		public Verificador()
		{
			InitializeComponent();
		}

		private void Verificador_Load(object sender, EventArgs e)
		{
			label1.Location = new Point(this.Width / 2 - label1.Width / 2, 10);
			label2.Location = new Point(this.Width / 2 - label2.Width / 2, label1.Height+11);
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 21);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 22);
		}
		/*private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				//MessageBox.Show(textBox1.Text);
				buscar(textBox1.Text);
				textBox1.Clear();
			}

		}*/


		private void buscar(string texto)
		{
			string[] infoProducto;
			string line;
			StreamReader file = new StreamReader("productos.csv");

			while ((line = file.ReadLine()) != null)
			{
				//MessageBox.Show(codigo);
				infoProducto = line.Split(',');
				if (texto == infoProducto[0])
				{
					label4.ForeColor = Color.Red;
					label4.Text = " Nombre: " + infoProducto[1] + " Precio: $ " + infoProducto[2];
					codigoencontrado = true;
					label4.Location = new Point(this.Width / 2 - label4.Width / 2, label2.Height + label2.Height + 40);
				}
			}

			if (!codigoencontrado)
			{
				label4.Text = " Codigo No Encontrado ";
				label4.Location = new Point(this.Width / 2 - label4.Width / 2, label2.Height + label2.Height + 40);
			}

			codigoencontrado = false;

			file.Close();
		}

		private void Verificador_KeyPress(object sender, KeyPressEventArgs e)
		{
			codigo += e.KeyChar;
			if (e.KeyChar == 13)
			{				
				buscar(codigo.Trim());
				codigo = "";
			}
		}
	}
}
