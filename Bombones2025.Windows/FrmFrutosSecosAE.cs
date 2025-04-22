using Bombones2025.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones2025.Windows
{
    public partial class FrmFrutosSecosAE : Form

    {
        private FrutoSeco? frutoSeco;
        public FrmFrutosSecosAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (frutoSeco is not null)
            {
                TxtFrutoSeco.Text = frutoSeco.Descripcion;
            }
        }
        public FrutoSeco? GetList()
        {
            return frutoSeco;
        }






        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtFrutoSeco.Text))
            {
                valido = false;
                errorProvider1.SetError(TxtFrutoSeco, "El nombre es requerido");

            }
            return valido;
        }

        public void SetFruto(FrutoSeco frutoSeco)
        {
            this.frutoSeco = frutoSeco;
        }



        private void FrmFrutosSecosAE_Load(object sender, EventArgs e)
        {

        }

        private void BtnOK_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (frutoSeco is null)
                {
                    frutoSeco = new FrutoSeco();

                }
                frutoSeco.Descripcion = TxtFrutoSeco.Text;

                DialogResult = DialogResult.OK;
            }
        }

        //private bool ValidarDatos()
        //{
        //    bool valido = true;
        //    errorProvider1.Clear();
        //    if (string.IsNullOrEmpty(TxtFrutoSeco.Text))
        //    {
        //        valido = false;
        //        errorProvider1.SetError(TxtFrutoSeco, "El fruto es requerido");

        //    }
        //    return valido;
        //}

        public void SetFrusoSeco(FrutoSeco frutoSeco)
        {
            this.frutoSeco = frutoSeco;
        }

        private void BtnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
