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
	public partial class MenuPuntodeVenta : Form
	{
		public MenuPuntodeVenta()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			label1.Location = new Point(this.Width / 2 - label1.Width / 2, 10);
			label2.Location = new Point(this.Width / 2 - label2.Width / 2, label1.Height + 11);
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 21);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 22);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (var cuadromagico = new ProgramacionOrientadaObjetosII.Form1())
			{
				cuadromagico.ShowDialog();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			using (var cuadromagico = new ProgramacionOrientadaObjetosII.Punto_Venta())
			{
				cuadromagico.ShowDialog();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			using (var cuadromagico = new ProgramacionOrientadaObjetosII.Verificador())
			{
				cuadromagico.ShowDialog();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			using (var cuadromagico = new ProgramacionOrientadaObjetosII.Checador_Personal())
			{
				cuadromagico.ShowDialog();
			}
		}
	}
}
