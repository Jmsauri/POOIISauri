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

namespace ProgramacionOrientadaObjetosII
{
	public partial class Form1 : Form
	{
		private List<Productos> listaproductos = new List<Productos>();
		Productos[] producto = new Productos[3];
		private int rowSelect;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			producto[0] = new Productos(1, "producto 1", 35.00f);
			producto[1] = new Productos(2, "producto 2", 35.02f);
			producto[2] = new Productos(3, "producto 3", 35.08f);
			cargaProducto();

		}

		private void cargaProducto()
		{
			dataGridView1.Columns[2].DefaultCellStyle.Format = "N2";

			try
			{
				int counter = 0;
				string line;
				System.IO.StreamReader file =
				new System.IO.StreamReader(@"C:\Users\JmSaurii\source\repos\NewRepo2\ProgramacionOrientadaObjetosII\ProgramacionOrientadaObjetosII\bin\Debug\productos.csv");
				while ((line = file.ReadLine()) != null)
				{
					dataGridView1.Text += line + Environment.NewLine;
					dataGridView1.Rows.Add(line.Split(','));
					dataGridView1.Rows[counter].HeaderCell.Value = (counter + 1).ToString();
					counter++;
				}
				file.Close();
			}
			catch (Exception error)
			{
				MessageBox.Show("No sale" + error);
			}
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			bool esta = false;
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				if (dataGridView1[0, i].Value.ToString() == IdProducto.Text)
				{
					esta = true;
				}
				
			}

			if (!esta)
			{
				dataGridView1.Rows.Add(IdProducto.Text, NProducto.Text, Precio.Text);
				dataGridView1_Numerar();
			}

			else
			{
				MessageBox.Show("Producto Ya Existe");
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Desea Eliminar" + dataGridView1[1, rowSelect].Value.ToString() + "Precio:" + dataGridView1[2, rowSelect].Value.ToString(), "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				dataGridView1.Rows.RemoveAt(rowSelect);
			}
			limpiar();
		}

		private void limpiar()
		{
			IdProducto.Clear();
			NProducto.Clear();
			Precio.Clear();
			IdProducto.Focus();
		}

		private void dataGridView1_Numerar()
		{
			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
			}
        }

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				rowSelect = e.RowIndex;
				IdProducto.Text = dataGridView1[0, rowSelect].Value.ToString();
				NProducto.Text = dataGridView1[1, rowSelect].Value.ToString();
				Precio.Text = dataGridView1[2, rowSelect].Value.ToString();
				rowSelect = e.RowIndex;
				IdProducto.Enabled = false;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Desea Modificar" + dataGridView1[1, rowSelect].Value.ToString() + "Precio:" + dataGridView1[2, rowSelect].Value.ToString(), "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				dataGridView1[1, rowSelect].Value = NProducto.Text;
				dataGridView1[2, rowSelect].Value = Precio.Text;
			}
			limpiar();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			MessageBox.Show("Verificar que se guardo");

			dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataObject dataObject = dataGridView1.GetClipboardContent();
			File.WriteAllText("practica.csv", dataObject.GetText(TextDataFormat.CommaSeparatedValue));
		}
	}
	class Productos
	{
		//Propiedades
		public long pCodigo = 0;
		public String pNombre = "";
		public float pPrecio = 0.00f;

		public Productos()
		{
			MessageBox.Show("Me llamaron sin parametros");
		}
		public Productos(long pCodigo, String pNombre, float pPrecio)
		{
			this.pCodigo = pCodigo;
			this.pNombre = pNombre;
			this.pPrecio = pPrecio;
		}
	}

}	
