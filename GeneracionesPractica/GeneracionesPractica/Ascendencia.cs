	using System;
using System.Windows.Forms;

namespace GeneracionesPractica
{
	public partial class Ascendencia : Form
	{
		public Ascendencia()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int numero, cont, inicial;
			numero = int.Parse(textBox1.Text);
			textBox2.Text = (Math.Pow(2, numero)-1).ToString("N0");
			cont = 1;
			String espacio=null, asterisco=null;
			String[] esp = new string[numero];
			richTextBox1.Clear();
			inicial = 1;
			int a, b, c;
			
			for (int i = 0; i < numero; i++)
			{
				asterisco += "*";
				esp[i] = asterisco;
							
				for (int j = 0; j < inicial; j++)
				{
					richTextBox1.Text += cont;
					cont++;
					richTextBox1.Text += " ";
				}
				inicial = (inicial * 2);
				richTextBox1.Text += Environment.NewLine;				
			}
			

		}
	}
}
