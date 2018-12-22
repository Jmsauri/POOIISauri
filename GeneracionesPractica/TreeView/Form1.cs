using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			treeView1.Nodes.Add(textBox1.Text);
			textBox1.Text = "";
		}		

		private void button2_Click(object sender, EventArgs e)
		{
			treeView1.SelectedNode.Nodes.Add(textBox2.Text);
			textBox2.Text = "";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			treeView1.Nodes.Clear();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			treeView1.Nodes.Remove(treeView1.SelectedNode);
		}
	}
}
