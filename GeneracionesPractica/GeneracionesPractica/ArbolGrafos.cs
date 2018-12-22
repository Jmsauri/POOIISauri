using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace GeneracionesPractica
{
	public partial class ArbolGrafos : Form
	{
		public ArbolGrafos()
		{
			InitializeComponent();
		}
	}
	class Nodo_Arbol
	{
		public int info;
		public Nodo_Arbol Izquierdo;
		public Nodo_Arbol Derecho;
		public Nodo_Arbol Padre;
		public int altura;
		public int nivel;
		public int suma = 0;
		public Rectangle nodo;
		private Arbol_Binario arbol;
		public Nodo_Arbol();
		
		
	}
       

	internal class Arbol_Binario
	{
	}

	public Arbol_Binario arbol
	{
		get { return arbol }
		set { arbol = value; }
	}
	public Nodo_Arbol Insertar(int x, Nodo_Arbol t, ref int Level1)
	{
		if (t == null)
		{
			t = new Nodo_Arbol(x, null, null, null);
			t.nivel = Level1;
			t.altura = Alturas(t);
		}
		else if (x < 1 t.info)
		{
			Level1++;
			t.Izquierdo = Insertar(x, t.Izquierdo, ref Level1);
		}
		else
	    {
			MessageBox.Show("Numero ya existe");
		}
		return t;
	}
	private static int Alturas(Nodo_Arbol t)
	{
		return t == null ? -1 : t.altura;
	}

	public void Eliminar (int x, ref Nodo_Arbol t)
	{
		if (t != null)
		{
			if (x < t.info)
			{
				Eliminar(x, ref t.Izquierdo);
			}
			else
			{
				if (x > t.info)
				{
					Eliminar(x, ref t.Derecho);
				}
				else
				{
					Nodo_Arbol NodoEliminar = t;
					if (NodoEliminar.Derecho == null)
					{
						t = NodoEliminar.Izquierdo;
					}
					else
					{
						if ((Alturas(t.Izquierdo) - Alturas(t.Derecho)) > 0)
						{
							Nodo_Arbol AuxiliarNodo = null;
							Nodo_Arbol Auxiliar = t.Izquierdo;
							bool Bandera = false;
							while (Auxiliar.Derecho != null)
							{
								AuxiliarNodo = Auxiliar;
								Auxiliar = Auxiliar.Derecho;
								Bandera = true;
							}
							t.info = Auxiliar.info;
							NodoEliminar = Auxiliar;
							if (Bandera == true)
							{
								AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
							}
							else
							{
								t.Izquierdo = Auxiliar.Izquierdo;
							}
						}
						else
						{
							if ((Alturas(t.Derecho) - Alturas(t.Izquierdo)) > 0)
							{
								Nodo_Arbol AuxiliarNodo = null;
								Nodo_Arbol Auxiliar = t.Derecho;
								bool Bandera = false;
								while (Auxiliar.Izquierdo != null)
								{
									AuxiliarNodo = Auxiliar;
									Auxiliar = Auxiliar.Izquierdo;
									Bandera = true;
								}
								t.info = Auxiliar.info;
								NodoEliminar = Auxiliar;
								if (Bandera == true)
								{
									AuxiliarNodo.Izquierdo = Auxiliar.Derecho;
								}
								else
								{
									t.Derecho = Auxiliar.Derecho;
								}
							}
							else
							{
								if (Alturas(t.Derecho) - Alturas(t.Izquierdo) == 0)
								{
									Nodo_Arbol AuxiliarNodo = null;
									Nodo_Arbol Auxiliar = t.Izquierdo;
									bool Bandera = false;
									while (Auxiliar.Derecho != null)
								}
							}
						
							}
						
						}
					}

				}
			}
		}
	}
}


