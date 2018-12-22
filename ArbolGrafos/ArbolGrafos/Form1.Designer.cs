namespace ArbolGrafos
{
	partial class Form1
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblx = new System.Windows.Forms.Label();
			this.lbly = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblx
			// 
			this.lblx.AutoSize = true;
			this.lblx.Location = new System.Drawing.Point(13, 35);
			this.lblx.Name = "lblx";
			this.lblx.Size = new System.Drawing.Size(35, 13);
			this.lblx.TabIndex = 0;
			this.lblx.Text = "label1";
			// 
			// lbly
			// 
			this.lbly.AutoSize = true;
			this.lbly.Location = new System.Drawing.Point(54, 35);
			this.lbly.Name = "lbly";
			this.lbly.Size = new System.Drawing.Size(35, 13);
			this.lbly.TabIndex = 1;
			this.lbly.Text = "label2";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.label1.Location = new System.Drawing.Point(375, 201);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Prueba";
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
			this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
			this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lbly);
			this.Controls.Add(this.lblx);
			this.Name = "Form1";
			this.Text = "Form1";
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblx;
		private System.Windows.Forms.Label lbly;
		private System.Windows.Forms.Label label1;
	}
}

