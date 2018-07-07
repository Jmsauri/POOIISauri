using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramacionOrientadaObjetosII
{
	public partial class Form1 : Form
	{
		private List<Productos> listaproductos = new List<Productos>();
		Productos[] producto = new Productos[3];
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			/*Productos productos = new Productos();
			productos.producto_codigo = 12345698764;
			productos.producto_nombre = "MILLER";
			productos.producto_precio = 36.00f;

			richTextBox1.Text += productos.producto_codigo + productos.producto_nombre + productos.producto_precio;*/


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
				for (int i = 0; i < producto.Length; i++)
				{
					dataGridView1.Rows.Add(producto[i].pCodigo, producto[i].pNombre, producto[i].pPrecio);
				}
			}
			catch (Exception err)
			{

				MessageBox.Show("ERROR:" + Environment.NewLine + err);
			}
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
