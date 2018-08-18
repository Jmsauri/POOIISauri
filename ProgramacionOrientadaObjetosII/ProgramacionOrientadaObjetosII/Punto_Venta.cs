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
using LibPrintTicket;

namespace ProgramacionOrientadaObjetosII
{
	public partial class Punto_Venta : Form
	{
		private double AcTotal = 0;
		int total;
		string[] CantidadProducto;
		//private bool codigoencontrado = false;
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

			dataGridView1.Columns[0].Width = Convert.ToInt32(this.Width * 0.15 + "");
			dataGridView1.Columns[1].Width = Convert.ToInt32(this.Width * 0.44 + "");
			dataGridView1.Columns[2].Width = Convert.ToInt32(this.Width * 0.20 + "");
			dataGridView1.Columns[3].Width = Convert.ToInt32(this.Width * 0.20 + "");

			textBox1.Focus();
			upDateFont();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 22);
			timer1.Enabled = true;
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.ToString() == "p")
			{
				e.Handled = true;
				pagar();
				
			}

			
				if (e.KeyChar == 13)
			{
				if (textBox1.Text.IndexOf('*') == -1)
				{
					buscarProducto(1, textBox1.Text);
				}
				else
				{
					CantidadProducto = textBox1.Text.Split('*');
					buscarProducto(int.Parse(CantidadProducto[0]), CantidadProducto[1]);
				}			
				textBox1.Clear();
				textBox1.Focus();				
			}
			if (e.KeyChar == 27)
			{
				EliminarProducto();
				
			}
			if (e.KeyChar == 9)
			{
				DubplicarUltimoProducto();
				ActTotal();
			}

		}
		private void buscarProducto(int cantidad , string idProducto)
		{
			string[] infoProducto;
			string line;
			StreamReader file = new StreamReader("Productos.csv");


			while ((line = file.ReadLine()) != null)
			{
				//MessageBox.Show(codigo);
				infoProducto = line.Split(',');
				if (idProducto == infoProducto[0])
				{
					dataGridView1.Rows.Add(cantidad, infoProducto[1], infoProducto[2], cantidad*float.Parse(infoProducto[2]));
					//codigoencontrado = false;

					//AcTotal = total + cantidad * Convert.ToDouble(infoProducto[2]);
					ActTotal();
				}
			}			
			file.Close();
		}

		private void upDateFont()
		{
			foreach (DataGridViewColumn c in dataGridView1.Columns)
			{
				c.HeaderCell.Style.Font = new Font("Arial", 20, GraphicsUnit.Pixel);
			}

			dataGridView1.Columns[0].Width = Convert.ToInt32(this.Width * 0.15 + "");
			dataGridView1.Columns[1].Width = Convert.ToInt32(this.Width * 0.445 + "");
			dataGridView1.Columns[2].Width = Convert.ToInt32(this.Width * 0.20 + "");
			dataGridView1.Columns[3].Width = Convert.ToInt32(this.Width * 0.20 + "");
		}

		private void actualizartotal()
		{
			label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);
		}

		private void EliminarProducto()
		{
			if (dataGridView1.Rows.Count > 0)
			{
				dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
			}
			ActTotalmenos();			
		}

		private void ActTotal()
		{
			AcTotal = 0;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				AcTotal += Convert.ToDouble(dataGridView1[3, i].Value.ToString());
			}
			label4.Text = "Total: $ " + AcTotal.ToString("n");
			label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);
		}

		private void DubplicarUltimoProducto()
		{
			if (dataGridView1.Rows.Count > 0) 
			{
				dataGridView1.Rows.Add(dataGridView1[0, dataGridView1.Rows.Count - 1].Value.ToString(),
					dataGridView1[1, dataGridView1.Rows.Count - 1].Value.ToString(),
					dataGridView1[2, dataGridView1.Rows.Count - 1].Value.ToString(),
					dataGridView1[3, dataGridView1.Rows.Count - 1].Value.ToString());
			}
			ActTotal();
		}

		private void pagar()
		{
			//this.AcTotal = Convert.ToDouble(textBox1.Text) - this.AcTotal;
			//label4.Text = "Cambio: $" + AcTotal.ToString("n");

			label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);

			imprimirTicket();
			textBox1.Clear();
			dataGridView1.Rows.Clear();
		}

		private void ActTotalmenos()
		{
			AcTotal = 0;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				AcTotal += Convert.ToDouble(dataGridView1[3, i].Value.ToString());
			}
			label4.Text = "Total: $ " + AcTotal.ToString("n");
			label4.Location = new Point(this.Width - label4.Width + 2, this.Height - textBox1.Height - label4.Height);

		}

		private void imprimirTicket()
		{
			try
			{
				Ticket ticket = new Ticket();
				ticket.HeaderImage = Image.FromFile(@"C:\Users\JmSaurii\source\repos\NewRepo2\ProgramacionOrientadaObjetosII\ProgramacionOrientadaObjetosII\img\caldiabl(1).jpg");
				ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString());
				ticket.AddSubHeaderLine(DateTime.Now.ToShortTimeString());

				double Cambio = 0;
				Cambio = double.Parse(textBox1.Text) - AcTotal;

				for (int i = 0; i < dataGridView1.RowCount-1; i++)
				{
					ticket.AddItem(dataGridView1[0, i].Value.ToString(),
						dataGridView1[1, i].Value.ToString(),
						dataGridView1[3, i].Value.ToString());
				}
				ticket.AddFooterLine("Total: $" + (AcTotal < 10 ? AcTotal.ToString("0.00") : (AcTotal < 100 ? AcTotal.ToString("00.00") : AcTotal.ToString("000.00"))));
				ticket.AddFooterLine("Cambio: $" + (Cambio < 10 ? Cambio.ToString("0.00") : (Cambio < 100 ? Cambio.ToString("00.00") : Cambio.ToString("000.00"))));


				ticket.AddFooterLine("Gracias por su Compra");
				ticket.AddFooterLine("Vuelva Pronto");
				ticket.AddFooterLine("Visita nuestro sitio web: www.xxx.com.mx");

				//ticket.PrintTicket("EC-PM-5890X");
				//ticket.PrintTicket("EC-PM-5890X");
				if (ticket.PrinterExists("PDFCreator"))
				{
					ticket.PrintTicket("PDFCreator");
				}

			}
			catch (Exception error)
			{
				MessageBox.Show(error.ToString());
			}
		}
	}
	
}
