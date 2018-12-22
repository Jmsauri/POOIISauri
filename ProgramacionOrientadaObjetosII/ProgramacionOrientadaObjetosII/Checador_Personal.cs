using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ProgramacionOrientadaObjetosII
{
	public partial class Checador_Personal : Form
	{
		string ruta = Application.StartupPath;
		bool empleadoReg;
		string empleado = "";
		int contador = 0;
		private object deliverynotificationoptions;
		private object MessageBoxbuttons;

		public object MessageBoxicon { get; private set; }
		public object MessageBoxdefaultbutton { get; private set; }

		public Checador_Personal()
		{
			InitializeComponent();
		}

		private void Checador_Personal_Load(object sender, EventArgs e)
		{
			label1.Location = new Point(this.Width / 2 - label1.Width / 2, 10);
			label2.Location = new Point(this.Width / 2 - label2.Width / 2, label1.Height + 29);
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 50);
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			label3.Text = DateTime.Now.ToString();
			label3.Location = new Point(this.Width / 2 - label3.Width / 2, label2.Height + label2.Height + 50);
		}

		private void Checador_Personal_KeyPress(object sender, KeyPressEventArgs e)
		{
			empleado += e.KeyChar;
			if (e.KeyChar == 13)
			{
				//MessageBox.Show(empleado);
				buscaempleados(empleado);
				empleado = "";
				contador = 0;
			}
		}

		private void buscaempleados(string empleado)
		{
			String[] InfoEmpleado;
			string line;

			System.IO.StreamReader file = new System.IO.StreamReader("Empleados.csv");
			while ((line = file.ReadLine()) != null)
			{
				InfoEmpleado = line.Split(',');
				if (empleado.Trim() == InfoEmpleado[0])
				{
					ruta = ruta.Replace("bin\\Debug", "");

					label4.Text = (InfoEmpleado[0] + "\n" + InfoEmpleado[1] + "\n Hora de Entrada: " + DateTime.Now.ToString() + InfoEmpleado[4] + "\n " + label4.Text);

					pictureBox1.Image = Image.FromFile(InfoEmpleado[2]);
					file.Close();

					if (InfoEmpleado[4] == "Salida")
					{
						lineChanger(InfoEmpleado[0] + "," + InfoEmpleado[1] + "," + InfoEmpleado[2] + "," + InfoEmpleado[3] + ",Entrada", contador);
					}
					else
					{
						lineChanger(InfoEmpleado[0] + "," + InfoEmpleado[1] + "," + InfoEmpleado[2] + "," + InfoEmpleado[3] + ",Salida", contador);
					}
					mandarcorreo(label4.Text, InfoEmpleado[3]);
					label4.Update();
					Application.DoEvents();
					System.Threading.Thread.Sleep(1500);
					label4.Text = "Bienvenido, Ingresar Numero Empleado.";
					empleadoReg = true;
					pictureBox1.Image = Properties.Resources.user_13230;
					break;
				}
				contador++;
			}
			if (empleadoReg == false)
			{

			}
			file.Close();
		}

		static void lineChanger(string newText, int line_to_edit)
		{
			string[] arrLine = File.ReadAllLines("Empleados.csv");
			arrLine[line_to_edit] = newText;
			File.WriteAllLines("Empleados.csv", arrLine);
		}
		
		private void mandarcorreo(string mensaje, string correo)
		{
			System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
			try
			{
				msg.To.Add(correo);
				msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
				msg.Priority = MailPriority.High;
				msg.From = new MailAddress("productosfaf@hotmail.com", "Jmsaurii1", System.Text.Encoding.UTF8);
				msg.Subject = "Checador";
				msg.SubjectEncoding = System.Text.Encoding.UTF8;
				msg.Body = mensaje;
				msg.BodyEncoding = System.Text.Encoding.UTF8;
				msg.IsBodyHtml = false;
				SmtpClient client = new SmtpClient();
				client.Host = "smtp.live.com";
				client.Port = 587;
				client.UseDefaultCredentials = false;
				client.EnableSsl = true;
				client.Credentials = new
				System.Net.NetworkCredential("productosfaf@hotmail.com", "Jmsaurii1");
				client.Send(msg);
			}
			catch (System.Net.Mail.SmtpException ex)
			{
				MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
				MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			catch (FormatException ex)
			{
				MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK,
				MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			
		}



	}
}

