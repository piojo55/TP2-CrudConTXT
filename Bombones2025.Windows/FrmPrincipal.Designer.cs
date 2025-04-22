namespace Bombones2025.Windows
{
    partial class FrmPrincipal
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
            BtnPaises = new Button();
            btnFrutosSecos = new Button();
            btnChocolates = new Button();
            SuspendLayout();
            // 
            // BtnPaises
            // 
            BtnPaises.Location = new Point(40, 46);
            BtnPaises.Name = "BtnPaises";
            BtnPaises.Size = new Size(87, 54);
            BtnPaises.TabIndex = 0;
            BtnPaises.Text = "Países";
            BtnPaises.UseVisualStyleBackColor = true;
            BtnPaises.Click += BtnPaises_Click;
            // 
            // btnFrutosSecos
            // 
            btnFrutosSecos.Location = new Point(179, 46);
            btnFrutosSecos.Name = "btnFrutosSecos";
            btnFrutosSecos.Size = new Size(87, 54);
            btnFrutosSecos.TabIndex = 1;
            btnFrutosSecos.Text = "Frutos Secos";
            btnFrutosSecos.UseVisualStyleBackColor = true;
            btnFrutosSecos.Click += btnFrutosSecos_Click;
            // 
            // btnChocolates
            // 
            btnChocolates.Location = new Point(317, 46);
            btnChocolates.Name = "btnChocolates";
            btnChocolates.Size = new Size(87, 54);
            btnChocolates.TabIndex = 2;
            btnChocolates.Text = "Chocolates";
            btnChocolates.UseVisualStyleBackColor = true;
            btnChocolates.Click += btnChocolates_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 249);
            Controls.Add(btnChocolates);
            Controls.Add(btnFrutosSecos);
            Controls.Add(BtnPaises);
            Name = "FrmPrincipal";
            Text = "FrmPrincipal";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button BtnPaises;
        private Button btnFrutosSecos;
        private Button btnChocolates;
    }
}