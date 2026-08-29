using System.Drawing;
using System.Windows.Forms;

namespace BibliotecaUniversitaria.Forms
{
    partial class frmGestionMultas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvMultas;
        private Button btnMarcarPagada, btnEliminar, btnCerrar;

        private void InitializeComponent()
        {
            this.txtBuscar = new TextBox();
            this.btnBuscar = new Button();
            this.dgvMultas = new DataGridView();
            this.btnMarcarPagada = new Button();
            this.btnEliminar = new Button();
            this.btnCerrar = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).BeginInit();
            this.SuspendLayout();

            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Location = new Point(30, 30);
            this.txtBuscar.Size = new Size(500, 23);

            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new Point(600, 28);
            this.btnBuscar.Size = new Size(100, 26);
            Estilos.AplicarBotonAccion(this.btnBuscar);
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.dgvMultas.Name = "dgvMultas";
            this.dgvMultas.Location = new Point(30, 75);
            this.dgvMultas.Size = new Size(670, 260);
            this.dgvMultas.AllowUserToAddRows = false;
            this.dgvMultas.Columns.Add("Prestamo", "Prestamo");
            this.dgvMultas.Columns.Add("Usuario", "Usuario");
            this.dgvMultas.Columns.Add("Multas", "Multas");
            this.dgvMultas.Columns.Add("Pagadas", "Pagadas");
            this.dgvMultas.Columns.Add("Fecha", "Fecha");

            this.btnMarcarPagada.Name = "btnMarcarPagada";
            this.btnMarcarPagada.Text = "Marcar como pagada";
            this.btnMarcarPagada.Location = new Point(30, 360);
            this.btnMarcarPagada.Size = new Size(180, 34);
            Estilos.AplicarBotonAccion(this.btnMarcarPagada);
            this.btnMarcarPagada.Click += new System.EventHandler(this.btnMarcarPagada_Click);

            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new Point(300, 360);
            this.btnEliminar.Size = new Size(120, 34);
            Estilos.AplicarBotonAccion(this.btnEliminar);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.Location = new Point(500, 360);
            this.btnCerrar.Size = new Size(120, 34);
            Estilos.AplicarBotonAccion(this.btnCerrar);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // frmGestionMultas
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(730, 430);
            this.BackColor = Estilos.FondoFormulario;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "frmGestionMultas";
            this.Text = "Gestion de Multas";

            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvMultas);
            this.Controls.Add(this.btnMarcarPagada);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCerrar);

            ((System.ComponentModel.ISupportInitialize)(this.dgvMultas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
