using Bombones2025.Entidades;
using Bombones2025.Servicios;

namespace Bombones2025.Windows
{
    public partial class FrmChocolates : Form
    {
        private readonly ChocolateServicio _chocolateServicio;

        private List<Chocolate> _chocolates = new();
        public FrmChocolates(ChocolateServicio chocolateServicio)
        {
            InitializeComponent();
            _chocolateServicio = chocolateServicio;
        }
        private void FrmChocolates_Load(object sender, EventArgs e)
        {
            _chocolates = _chocolateServicio.GetChocolates();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (Chocolate chocolate in _chocolates)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, chocolate);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Chocolate chocolate)
        {
            r.Cells[0].Value = chocolate.ChocolateId;
            r.Cells[1].Value = chocolate.NombreChocolate;

            r.Tag = chocolate;
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Nuevo Chocolate" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Chocolate? chocolate = frm.GetChocolate();
            if (chocolate == null) return;
            if (!_chocolateServicio.Existe(chocolate))
            {
                _chocolateServicio.Guardar(chocolate);
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, chocolate);
                AgregarFila(r);
                MessageBox.Show("Chocolate agregado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Chocolate ya existe", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Chocolate chocolateBorrar = (Chocolate)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el chocolate {chocolateBorrar}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            _chocolateServicio.Borrar(chocolateBorrar);
            dgvDatos.Rows.Remove(r);
            MessageBox.Show("Chocolate eliminado");
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            Chocolate? chocolate = (Chocolate)r.Tag!;
            FrmChocolatesAE frm = new FrmChocolatesAE() { Text = "Editar Chocolate" };
            frm.SetChocolate(chocolate);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            chocolate = frm.GetChocolate();
            if (chocolate == null) return;
            if (!_chocolateServicio.Existe(chocolate))
            {
                _chocolateServicio.Guardar(chocolate);
                SetearFila(r, chocolate);

                MessageBox.Show("Chocolate editado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Chocolate existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
