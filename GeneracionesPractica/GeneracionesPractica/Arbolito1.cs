using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GeneracionesPractica.treeView1;

namespace GeneracionesPractica
{
	public partial class Arbolito1 : Form
	{
		public Arbolito1()
		{
			InitializeComponent();
		}

		private void Arbolito1_Load(object sender, EventArgs e)
		{
			TreeNode treeNode = new TreeNode("Jose Manuel Sauri");
			TreeNode node2 = new TreeNode("Mama");

			TreeNode node3 = new TreeNode("Papa");
		}
	}

	
}

