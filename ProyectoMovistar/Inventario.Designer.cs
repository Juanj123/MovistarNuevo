namespace ProyectoMovistar
{
    partial class Inventario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.rbnTipo = new System.Windows.Forms.RadioButton();
            this.rbnNombre = new System.Windows.Forms.RadioButton();
            this.rbnClave = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.txtProovedor = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEmpleado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clave,
            this.Nombre,
            this.Precio,
            this.Existencia,
            this.Modificar,
            this.Eliminar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 276);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 175);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Clave
            // 
            this.Clave.HeaderText = "Clave";
            this.Clave.Name = "Clave";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // Existencia
            // 
            this.Existencia.HeaderText = "Existencia";
            this.Existencia.Name = "Existencia";
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Modificar.Text = "Modificar";
            this.Modificar.ToolTipText = "Modificar";
            this.Modificar.UseColumnTextForButtonValue = true;
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseColumnTextForButtonValue = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(566, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(87, 33);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(215, 65);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(314, 20);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // rbnTipo
            // 
            this.rbnTipo.AutoSize = true;
            this.rbnTipo.Location = new System.Drawing.Point(548, 7);
            this.rbnTipo.Name = "rbnTipo";
            this.rbnTipo.Size = new System.Drawing.Size(46, 17);
            this.rbnTipo.TabIndex = 2;
            this.rbnTipo.TabStop = true;
            this.rbnTipo.Text = "Tipo";
            this.rbnTipo.UseVisualStyleBackColor = true;
            // 
            // rbnNombre
            // 
            this.rbnNombre.AutoSize = true;
            this.rbnNombre.Location = new System.Drawing.Point(278, 7);
            this.rbnNombre.Name = "rbnNombre";
            this.rbnNombre.Size = new System.Drawing.Size(62, 17);
            this.rbnNombre.TabIndex = 1;
            this.rbnNombre.TabStop = true;
            this.rbnNombre.Text = "Nombre";
            this.rbnNombre.UseVisualStyleBackColor = true;
            // 
            // rbnClave
            // 
            this.rbnClave.AutoSize = true;
            this.rbnClave.Location = new System.Drawing.Point(69, 7);
            this.rbnClave.Name = "rbnClave";
            this.rbnClave.Size = new System.Drawing.Size(52, 17);
            this.rbnClave.TabIndex = 0;
            this.rbnClave.TabStop = true;
            this.rbnClave.Text = "Clave";
            this.rbnClave.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbnTipo);
            this.panel1.Controls.Add(this.rbnNombre);
            this.panel1.Controls.Add(this.rbnClave);
            this.panel1.Location = new System.Drawing.Point(18, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(742, 30);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscar);
            this.groupBox2.Controls.Add(this.txtBuscar);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 101);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Producto";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Introduce Busqueda:";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(529, 104);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(108, 33);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(652, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(108, 33);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(550, 46);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(195, 50);
            this.txtDescripcion.TabIndex = 12;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // txtExistencia
            // 
            this.txtExistencia.Location = new System.Drawing.Point(550, 20);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(195, 20);
            this.txtExistencia.TabIndex = 11;
            this.txtExistencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExistencia_KeyPress);
            // 
            // txtProovedor
            // 
            this.txtProovedor.Location = new System.Drawing.Point(245, 103);
            this.txtProovedor.Name = "txtProovedor";
            this.txtProovedor.Size = new System.Drawing.Size(220, 20);
            this.txtProovedor.TabIndex = 10;
            this.txtProovedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProovedor_KeyPress);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(245, 76);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(220, 20);
            this.txtPrecio.TabIndex = 9;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(245, 47);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 20);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(245, 20);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(220, 20);
            this.txtClave.TabIndex = 7;
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            this.txtClave.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtClave_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Proovedor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Precio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clave:";
            // 
            // pbProducto
            // 
            this.pbProducto.Location = new System.Drawing.Point(18, 15);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(121, 108);
            this.pbProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProducto.TabIndex = 0;
            this.pbProducto.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtExistencia);
            this.groupBox1.Controls.Add(this.txtProovedor);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtClave);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pbProducto);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 143);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(49, 128);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(50, 13);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Examinar";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(529, 103);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(108, 33);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(484, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Descripcion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(484, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Existencia:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(637, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cerrar ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Location = new System.Drawing.Point(560, 8);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(71, 13);
            this.lblEmpleado.TabIndex = 8;
            this.lblEmpleado.Text = "Ramon Perez";
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 456);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblEmpleado);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.RadioButton rbnTipo;
        private System.Windows.Forms.RadioButton rbnNombre;
        private System.Windows.Forms.RadioButton rbnClave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.TextBox txtProovedor;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Existencia;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}