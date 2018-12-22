using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolGrafos
{
	public partial class Form1 : Form
	{
		int x, y;
		bool arrastrando = false;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			
		}
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			lblx.Text = e.Location.X.ToString();
			lbly.Text = e.Location.Y.ToString();
		}

		private void MouseMove(object sender, MouseEventArgs e)
		{
			if (arrastrando)
			{
				var label = sender as Label;
				label.Top += e.Y - y;
				label.Left += e.X - x;
			}
		}
		private void MouseDown(object sender, MouseEventArgs e)
		{
			arrastrando = true;
			x = e.X;
			y = e.Y;
		}				
		private void MouseUp(object sender, MouseEventArgs e)
		{
			arrastrando = false;
		}
	}
}
