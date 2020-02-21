namespace PROJE
{
    partial class girispaneli
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(girispaneli));
            this.btnyoneticigiris = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btpersonelgiris = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnyoneticigiris
            // 
            this.btnyoneticigiris.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnyoneticigiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyoneticigiris.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnyoneticigiris.ImageKey = "icons8-businessman-80.png";
            this.btnyoneticigiris.ImageList = this.ımageList1;
            this.btnyoneticigiris.Location = new System.Drawing.Point(12, 80);
            this.btnyoneticigiris.Name = "btnyoneticigiris";
            this.btnyoneticigiris.Size = new System.Drawing.Size(190, 153);
            this.btnyoneticigiris.TabIndex = 0;
            this.btnyoneticigiris.Text = "Yönetici Girişi";
            this.btnyoneticigiris.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnyoneticigiris.UseVisualStyleBackColor = false;
            this.btnyoneticigiris.Click += new System.EventHandler(this.btnyoneticigiris_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "icons8-businessman-80.png");
            this.ımageList1.Images.SetKeyName(1, "icons8-user-account-80.png");
            this.ımageList1.Images.SetKeyName(2, "icons8-delete-button-80.png");
            // 
            // btpersonelgiris
            // 
            this.btpersonelgiris.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btpersonelgiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btpersonelgiris.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btpersonelgiris.ImageKey = "icons8-user-account-80.png";
            this.btpersonelgiris.ImageList = this.ımageList1;
            this.btpersonelgiris.Location = new System.Drawing.Point(237, 80);
            this.btpersonelgiris.Name = "btpersonelgiris";
            this.btpersonelgiris.Size = new System.Drawing.Size(190, 153);
            this.btpersonelgiris.TabIndex = 1;
            this.btpersonelgiris.Text = "Personel Girişi";
            this.btpersonelgiris.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btpersonelgiris.UseVisualStyleBackColor = false;
            this.btpersonelgiris.Click += new System.EventHandler(this.btpersonelgiris_Click);
            // 
            // cikis
            // 
            this.cikis.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cikis.ImageKey = "icons8-delete-button-80.png";
            this.cikis.ImageList = this.ımageList1;
            this.cikis.Location = new System.Drawing.Point(398, 306);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(54, 36);
            this.cikis.TabIndex = 2;
            this.cikis.UseVisualStyleBackColor = false;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // girispaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROJE.Properties.Resources._1__1_1;
            this.ClientSize = new System.Drawing.Size(464, 354);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.btpersonelgiris);
            this.Controls.Add(this.btnyoneticigiris);
            this.Name = "girispaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş Paneli";
            this.Load += new System.EventHandler(this.girispaneli_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnyoneticigiris;
        private System.Windows.Forms.Button btpersonelgiris;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button cikis;
    }
}