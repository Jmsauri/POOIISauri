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
	public partial class RecorridodeArbolPreorden : Form
	{
		public RecorridodeArbolPreorden()
		{
			InitializeComponent();
		}
		int contador = 0;
		Random rn = new Random();
		private void RecorridodeArbol_Load(object sender, EventArgs e)
		{

		}
		private TreeNode[] arrNodo(int factorial)
		{
			TreeNode[] array = new TreeNode[] { };

			if (factorial > 1)
			{
				contador++;
				TreeNode papa = new TreeNode( rn.Next(1, 100).ToString(), arrNodo(factorial - 1));
				contador++;
				TreeNode mama = new TreeNode( rn.Next(1,100).ToString(), arrNodo(factorial - 1));

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
				TreeNode nodo = new TreeNode("Raiz", arrNodo(int.Parse(numericUpDown1.Value.ToString())));
				treeView1.Nodes.Clear();
				treeView1.Nodes.Add(nodo);
			}
		}
		private void btnRecorrelo_Click(object sender, EventArgs e)
		{
			label1.Text = string.Empty;
			foreach (TreeNode item in treeView1.Nodes)
			{
				RecorreNodo(item);
			}
		}

		private void RecorreNodo(TreeNode nodo)
		{
			label1.Text += nodo.Text + ",";
			foreach (TreeNode item in nodo.Nodes)
			{
				RecorreNodo(item);
			}

		}

	}

}

