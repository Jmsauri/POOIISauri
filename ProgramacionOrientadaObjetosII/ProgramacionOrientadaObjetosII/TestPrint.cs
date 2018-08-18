using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibPrintTicket;

namespace ProgramacionOrientadaObjetosII
{
	public partial class TestPrint : Form
	{
		public TestPrint()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{

			try
			{
				Ticket ticket = new Ticket();
				ticket.HeaderImage = Image.FromFile(@"C:\Users\JmSaurii\source\repos\NewRepo2\ProgramacionOrientadaObjetosII\ProgramacionOrientadaObjetosII\img\caldiabl.jpg");
				ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString());
				ticket.AddSubHeaderLine(DateTime.Now.ToShortTimeString());

				

				ticket.AddSubHeaderLine("Gracias por su Compra");
				ticket.AddSubHeaderLine("Vuelva Pronto");
				ticket.AddSubHeaderLine("Visita nuestro sitio web: www.xxx.com.mx");

				//ticket.PrintTicket("EC-PM-5890X");
				if(ticket.PrinterExists("PDFCreator"))
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
