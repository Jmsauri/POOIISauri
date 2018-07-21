using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramacionOrientadaObjetosII
{
	public partial class Punto_Venta : Form
	{
		public Punto_Venta()
		{
			InitializeComponent();
		}

		private void Punto_Venta_Load(object sender, EventArgs e)
		{
			label1.Location = new Point(this.Width / 2 - label1.Width / 2, 10);
			label2.Location = new Point(this.Width / 2 - label2.Width / 2, label1.Height + 11);
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 21);

			label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);

			dataGridView1.Width = this.Width - 2;
			dataGridView1.Height = int.Parse(this.Height * 0.75f + "");
			dataGridView1.Location = new Point(1, label1.Height + label2.Height + label3.Height + 21);

			
			textBox1.Location = new Point(0, this.Height - textBox1.Height);
			textBox1.Width = this.Width - 2;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 22);
			timer1.Enabled = true;
		}
	}
	
}
