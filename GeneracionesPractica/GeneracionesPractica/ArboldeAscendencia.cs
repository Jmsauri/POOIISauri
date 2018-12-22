using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneracionesPractica
{
	public partial class ArboldeAscendencia : Form
	{
		int contador = 0;
		public ArboldeAscendencia()
		{
			InitializeComponent();
		}

		private void ArboldeAscendencia_Load(object sender, EventArgs e)
		{

		}
		private TreeNode[] arrNodo(int factorial)
		{
			TreeNode[] array = new TreeNode[] { };

			if (factorial > 1)
			{
				contador++;
				TreeNode papa = new TreeNode("Papa" + contador, arrNodo(factorial - 1));
				contador++;
				TreeNode mama = new TreeNode("Mama" + contador, arrNodo(factorial - 1));

				array = new TreeNode[] { papa, mama };


			}
			return array;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (numericUpDown1.Value > 0)
			{
				var ee = (Math.Pow(2, int.Parse(numericUpDown1.Value.ToString())) - 1);
				contador = 0;
				TreeNode nodo = new TreeNode("Yo Mero", arrNodo(int.Parse(numericUpDown1.Value.ToString())));
				treeView1.Nodes.Clear();
				treeView1.Nodes.Add(nodo);
			}
		}
	}

}
