using Bombones2025.Servicios;

namespace Bombones2025.Windows
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void BtnPaises_Click(object sender, EventArgs e)
        {
            PaisServicio servicio = new PaisServicio("Paises.Txt");
            FrmPaises frm = new FrmPaises(servicio) { Text = "Listado de Paises" };
            frm.ShowDialog(this);
        }

        private void btnFrutosSecos_Click(object sender, EventArgs e)
        {
            FrutoSecoServicio servicio = new FrutoSecoServicio("FrutosSecos.txt");
            FrmFrutosSecos frm = new FrmFrutosSecos(servicio) { Text = "Listado de Frutos Secosss" };
            frm.ShowDialog(this);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnChocolates_Click(object sender, EventArgs e)
        {
            ChocolateServicio servicio = new ChocolateServicio("TipoDeChocolate.txt");
            FrmChocolates frm = new FrmChocolates(servicio) { Text = "Listado Tipos de Chocolate" };
            frm.ShowDialog(this);
        }
    }
}
