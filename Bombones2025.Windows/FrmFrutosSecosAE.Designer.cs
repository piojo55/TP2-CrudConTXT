namespace Bombones2025.Windows
{
    partial class FrmFrutosSecosAE
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
            components = new System.ComponentModel.Container();
            BtnCancelar = new Button();
            BtnOK = new Button();
            TxtFrutoSeco = new TextBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // BtnCancelar
            // 
            BtnCancelar.Location = new Point(298, 90);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(75, 52);
            BtnCancelar.TabIndex = 5;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click_1;
            // 
            // BtnOK
            // 
            BtnOK.Location = new Point(153, 90);
            BtnOK.Name = "BtnOK";
            BtnOK.Size = new Size(75, 52);
            BtnOK.TabIndex = 6;
            BtnOK.Text = "OK";
            BtnOK.UseVisualStyleBackColor = true;
            BtnOK.Click += BtnOK_Click_1;
            // 
            // TxtFrutoSeco
            // 
            TxtFrutoSeco.Location = new Point(90, 33);
            TxtFrutoSeco.MaxLength = 200;
            TxtFrutoSeco.Name = "TxtFrutoSeco";
            TxtFrutoSeco.Size = new Size(377, 23);
            TxtFrutoSeco.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 33);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "Fruto:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmFrutosSecosAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 183);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnOK);
            Controls.Add(TxtFrutoSeco);
            Controls.Add(label1);
            Name = "FrmFrutosSecosAE";
            Text = "FrmFrutosSecosAE";
            Load += FrmFrutosSecosAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnCancelar;
        private Button BtnOK;
        private TextBox TxtFrutoSeco;
        private Label label1;
        private ErrorProvider errorProvider1;
    }
}