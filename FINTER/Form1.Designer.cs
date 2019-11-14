namespace FINTER
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
            this.button1 = new System.Windows.Forms.Button();
            this.punto_y = new System.Windows.Forms.TextBox();
            this.punto_x = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb_pasos = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txt_k = new System.Windows.Forms.TextBox();
            this.lb_polinomio = new System.Windows.Forms.Label();
            this.lb_k = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.radio_lagrange = new System.Windows.Forms.RadioButton();
            this.radio_newgrepro = new System.Windows.Forms.RadioButton();
            this.radio_newgrereg = new System.Windows.Forms.RadioButton();
            this.button7 = new System.Windows.Forms.Button();
            this.lb_orden = new System.Windows.Forms.Label();
            this.lb_i = new System.Windows.Forms.Label();
            this.txt_i = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Agregar Punto";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // punto_y
            // 
            this.punto_y.Location = new System.Drawing.Point(207, 14);
            this.punto_y.Name = "punto_y";
            this.punto_y.Size = new System.Drawing.Size(100, 20);
            this.punto_y.TabIndex = 1;
            this.punto_y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.punto_y_KeyPress);
            // 
            // punto_x
            // 
            this.punto_x.Location = new System.Drawing.Point(53, 14);
            this.punto_x.Name = "punto_x";
            this.punto_x.Size = new System.Drawing.Size(100, 20);
            this.punto_x.TabIndex = 2;
            this.punto_x.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.punto_x_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Imagen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Punto";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(15, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1066, 291);
            this.dataGridView1.TabIndex = 6;
            // 
            // lb_pasos
            // 
            this.lb_pasos.AutoSize = true;
            this.lb_pasos.Location = new System.Drawing.Point(207, 351);
            this.lb_pasos.Name = "lb_pasos";
            this.lb_pasos.Size = new System.Drawing.Size(0, 13);
            this.lb_pasos.TabIndex = 10;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(101, 503);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Calcular K";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txt_k
            // 
            this.txt_k.Enabled = false;
            this.txt_k.Location = new System.Drawing.Point(16, 505);
            this.txt_k.Name = "txt_k";
            this.txt_k.Size = new System.Drawing.Size(79, 20);
            this.txt_k.TabIndex = 12;
            // 
            // lb_polinomio
            // 
            this.lb_polinomio.AutoSize = true;
            this.lb_polinomio.Location = new System.Drawing.Point(13, 539);
            this.lb_polinomio.Name = "lb_polinomio";
            this.lb_polinomio.Size = new System.Drawing.Size(0, 13);
            this.lb_polinomio.TabIndex = 13;
            // 
            // lb_k
            // 
            this.lb_k.AutoSize = true;
            this.lb_k.Location = new System.Drawing.Point(12, 602);
            this.lb_k.Name = "lb_k";
            this.lb_k.Size = new System.Drawing.Size(0, 13);
            this.lb_k.TabIndex = 14;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(16, 351);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "Limpiar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // radio_lagrange
            // 
            this.radio_lagrange.AutoSize = true;
            this.radio_lagrange.Enabled = false;
            this.radio_lagrange.Location = new System.Drawing.Point(16, 387);
            this.radio_lagrange.Name = "radio_lagrange";
            this.radio_lagrange.Size = new System.Drawing.Size(70, 17);
            this.radio_lagrange.TabIndex = 16;
            this.radio_lagrange.TabStop = true;
            this.radio_lagrange.Text = "Lagrange";
            this.radio_lagrange.UseVisualStyleBackColor = true;
            this.radio_lagrange.CheckedChanged += new System.EventHandler(this.radio_lagrange_CheckedChanged);
            // 
            // radio_newgrepro
            // 
            this.radio_newgrepro.AutoSize = true;
            this.radio_newgrepro.Enabled = false;
            this.radio_newgrepro.Location = new System.Drawing.Point(16, 416);
            this.radio_newgrepro.Name = "radio_newgrepro";
            this.radio_newgrepro.Size = new System.Drawing.Size(155, 17);
            this.radio_newgrepro.TabIndex = 17;
            this.radio_newgrepro.TabStop = true;
            this.radio_newgrepro.Text = "Newton Gregory Progresivo";
            this.radio_newgrepro.UseVisualStyleBackColor = true;
            this.radio_newgrepro.CheckedChanged += new System.EventHandler(this.radio_newgrepro_CheckedChanged);
            // 
            // radio_newgrereg
            // 
            this.radio_newgrereg.AutoSize = true;
            this.radio_newgrereg.Enabled = false;
            this.radio_newgrereg.Location = new System.Drawing.Point(16, 445);
            this.radio_newgrereg.Name = "radio_newgrereg";
            this.radio_newgrereg.Size = new System.Drawing.Size(153, 17);
            this.radio_newgrereg.TabIndex = 18;
            this.radio_newgrereg.TabStop = true;
            this.radio_newgrereg.Text = "Newton Gregory Regresivo";
            this.radio_newgrereg.UseVisualStyleBackColor = true;
            this.radio_newgrereg.CheckedChanged += new System.EventHandler(this.radio_newgrereg_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(16, 471);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(185, 23);
            this.button7.TabIndex = 19;
            this.button7.Text = "Calcular";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // lb_orden
            // 
            this.lb_orden.AutoSize = true;
            this.lb_orden.Location = new System.Drawing.Point(13, 571);
            this.lb_orden.Name = "lb_orden";
            this.lb_orden.Size = new System.Drawing.Size(0, 13);
            this.lb_orden.TabIndex = 20;
            // 
            // lb_i
            // 
            this.lb_i.AutoSize = true;
            this.lb_i.Location = new System.Drawing.Point(324, 17);
            this.lb_i.Name = "lb_i";
            this.lb_i.Size = new System.Drawing.Size(9, 13);
            this.lb_i.TabIndex = 22;
            this.lb_i.Text = "i";
            this.lb_i.Visible = false;
            this.lb_i.Click += new System.EventHandler(this.lb_i_Click);
            // 
            // txt_i
            // 
            this.txt_i.Location = new System.Drawing.Point(339, 14);
            this.txt_i.Name = "txt_i";
            this.txt_i.Size = new System.Drawing.Size(100, 20);
            this.txt_i.TabIndex = 21;
            this.txt_i.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 635);
            this.Controls.Add(this.lb_i);
            this.Controls.Add(this.txt_i);
            this.Controls.Add(this.lb_orden);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.radio_newgrereg);
            this.Controls.Add(this.radio_newgrepro);
            this.Controls.Add(this.radio_lagrange);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.lb_k);
            this.Controls.Add(this.lb_polinomio);
            this.Controls.Add(this.txt_k);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.lb_pasos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.punto_x);
            this.Controls.Add(this.punto_y);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "FINTER";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox punto_y;
        private System.Windows.Forms.TextBox punto_x;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb_pasos;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txt_k;
        private System.Windows.Forms.Label lb_polinomio;
        private System.Windows.Forms.Label lb_k;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RadioButton radio_lagrange;
        private System.Windows.Forms.RadioButton radio_newgrepro;
        private System.Windows.Forms.RadioButton radio_newgrereg;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label lb_orden;
        private System.Windows.Forms.Label lb_i;
        private System.Windows.Forms.TextBox txt_i;
    }
}

