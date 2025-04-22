using Bombones2025.Entidades;
using Bombones2025.Servicios;

namespace Bombones2025.Windows
{
    public partial class FrmFrutosSecos : Form
    {
        private readonly FrutoSecoServicio _frutoServicio;
        private List<FrutoSeco> _frutos = new();

        public FrmFrutosSecos(FrutoSecoServicio secoServicio)
        {
            InitializeComponent();
            _frutoServicio = secoServicio;
        }


        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmFrutosSecos_Load(object sender, EventArgs e)
        {
            _frutos = _frutoServicio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (FrutoSeco frutoSeco in _frutos)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, frutoSeco);
                AgregarFila(r);
            }

        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, FrutoSeco frutoSeco)
        {
            r.Cells[0].Value = frutoSeco.FrutoSecoId;
            r.Cells[1].Value = frutoSeco.Descripcion;

            r.Tag = frutoSeco;
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmFrutosSecosAE frm = new FrmFrutosSecosAE() { Text = "Nuevo Fruto" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            FrutoSeco? frutoSeco = frm.GetList();

            if (frutoSeco == null) return;
            if (!_frutoServicio.Existe(frutoSeco))
            {
                _frutoServicio.Guardar(frutoSeco);
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(dgvDatos);
                SetearFila(r, frutoSeco);
                AgregarFila(r);
                MessageBox.Show("Fruto agregado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Fruto existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            FrutoSeco? frutoSeco = (FrutoSeco)r.Tag!;
            FrmFrutosSecosAE frm = new FrmFrutosSecosAE() { Text = "Editar Fruto Seco" };
            frm.SetFruto(frutoSeco);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            frutoSeco = frm.GetList();
            if (frutoSeco == null) return;
            if (!_frutoServicio.Existe(frutoSeco))
            {
                _frutoServicio.Guardar(frutoSeco);
                SetearFila(r, frutoSeco);

                MessageBox.Show("Fruto Seco editado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Pais existente", "Error",
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
            FrutoSeco frutoSecoBorrar = (FrutoSeco)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el fruto seco {frutoSecoBorrar}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            _frutoServicio.Borrar(frutoSecoBorrar);
            dgvDatos.Rows.Remove(r);
            MessageBox.Show("Fruto Seco eliminado");
        }
    }
}
