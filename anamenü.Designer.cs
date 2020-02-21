namespace PROJE
{
    partial class anamenü
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(anamenü));
            this.btnkitapislemleri = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnteslimver = new System.Windows.Forms.Button();
            this.btnteslimal = new System.Windows.Forms.Button();
            this.btnlistele = new System.Windows.Forms.Button();
            this.btnyayinevleri = new System.Windows.Forms.Button();
            this.btnuyeislemi = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cikis = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnkitapislemleri
            // 
            this.btnkitapislemleri.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnkitapislemleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkitapislemleri.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnkitapislemleri.ImageKey = "icons8-course-80.png";
            this.btnkitapislemleri.ImageList = this.ımageList1;
            this.btnkitapislemleri.Location = new System.Drawing.Point(12, 64);
            this.btnkitapislemleri.Name = "btnkitapislemleri";
            this.btnkitapislemleri.Size = new System.Drawing.Size(415, 85);
            this.btnkitapislemleri.TabIndex = 0;
            this.btnkitapislemleri.Text = "Kitap İşlemleri";
            this.btnkitapislemleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnkitapislemleri.UseVisualStyleBackColor = false;
            this.btnkitapislemleri.Click += new System.EventHandler(this.btnkitapislemleri_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "icons8-course-80.png");
            this.ımageList1.Images.SetKeyName(1, "icons8-add-user-group-woman-man-80.png");
            this.ımageList1.Images.SetKeyName(2, "icons8-return-book-80.png");
            this.ımageList1.Images.SetKeyName(3, "icons8-borrow-book-80.png");
            this.ımageList1.Images.SetKeyName(4, "icons8-todo-list-80.png");
            this.ımageList1.Images.SetKeyName(5, "icons8-quill-with-ink-80.png");
            this.ımageList1.Images.SetKeyName(6, "icons8-delete-button-80.png");
            // 
            // btnteslimver
            // 
            this.btnteslimver.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnteslimver.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnteslimver.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnteslimver.ImageKey = "icons8-return-book-80.png";
            this.btnteslimver.ImageList = this.ımageList1;
            this.btnteslimver.Location = new System.Drawing.Point(12, 265);
            this.btnteslimver.Name = "btnteslimver";
            this.btnteslimver.Size = new System.Drawing.Size(415, 85);
            this.btnteslimver.TabIndex = 1;
            this.btnteslimver.Text = "Emanet Teslim Ver";
            this.btnteslimver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnteslimver.UseVisualStyleBackColor = false;
            this.btnteslimver.Click += new System.EventHandler(this.btnteslimver_Click);
            // 
            // btnteslimal
            // 
            this.btnteslimal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnteslimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnteslimal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnteslimal.ImageKey = "icons8-borrow-book-80.png";
            this.btnteslimal.ImageList = this.ımageList1;
            this.btnteslimal.Location = new System.Drawing.Point(12, 376);
            this.btnteslimal.Name = "btnteslimal";
            this.btnteslimal.Size = new System.Drawing.Size(415, 85);
            this.btnteslimal.TabIndex = 2;
            this.btnteslimal.Text = "Emanet Teslim Al";
            this.btnteslimal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnteslimal.UseVisualStyleBackColor = false;
            this.btnteslimal.Click += new System.EventHandler(this.btnteslimal_Click);
            // 
            // btnlistele
            // 
            this.btnlistele.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnlistele.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnlistele.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlistele.ImageKey = "icons8-todo-list-80.png";
            this.btnlistele.ImageList = this.ımageList1;
            this.btnlistele.Location = new System.Drawing.Point(12, 478);
            this.btnlistele.Name = "btnlistele";
            this.btnlistele.Size = new System.Drawing.Size(415, 85);
            this.btnlistele.TabIndex = 4;
            this.btnlistele.Text = "Emanet Listele";
            this.btnlistele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlistele.UseVisualStyleBackColor = false;
            this.btnlistele.Click += new System.EventHandler(this.btnlistele_Click);
            // 
            // btnyayinevleri
            // 
            this.btnyayinevleri.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnyayinevleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnyayinevleri.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnyayinevleri.ImageKey = "icons8-quill-with-ink-80.png";
            this.btnyayinevleri.ImageList = this.ımageList1;
            this.btnyayinevleri.Location = new System.Drawing.Point(12, 575);
            this.btnyayinevleri.Name = "btnyayinevleri";
            this.btnyayinevleri.Size = new System.Drawing.Size(415, 85);
            this.btnyayinevleri.TabIndex = 5;
            this.btnyayinevleri.Text = "Yayınevleri";
            this.btnyayinevleri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnyayinevleri.UseVisualStyleBackColor = false;
            this.btnyayinevleri.Click += new System.EventHandler(this.btnyayinevleri_Click);
            // 
            // btnuyeislemi
            // 
            this.btnuyeislemi.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnuyeislemi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnuyeislemi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnuyeislemi.ImageKey = "icons8-add-user-group-woman-man-80.png";
            this.btnuyeislemi.ImageList = this.ımageList1;
            this.btnuyeislemi.Location = new System.Drawing.Point(12, 162);
            this.btnuyeislemi.Name = "btnuyeislemi";
            this.btnuyeislemi.Size = new System.Drawing.Size(415, 85);
            this.btnuyeislemi.TabIndex = 6;
            this.btnuyeislemi.Text = "Üye İşlemleri";
            this.btnuyeislemi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnuyeislemi.UseVisualStyleBackColor = false;
            this.btnuyeislemi.Click += new System.EventHandler(this.btnuyeislemi_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(717, 38);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = global::PROJE.Properties.Resources.icons8_schedule_80;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(201, 35);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cikis
            // 
            this.cikis.ImageKey = "icons8-delete-button-80.png";
            this.cikis.ImageList = this.ımageList1;
            this.cikis.Location = new System.Drawing.Point(653, 608);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(52, 52);
            this.cikis.TabIndex = 8;
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // anamenü
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROJE.Properties.Resources._1__1_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(717, 672);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnuyeislemi);
            this.Controls.Add(this.btnyayinevleri);
            this.Controls.Add(this.btnlistele);
            this.Controls.Add(this.btnteslimal);
            this.Controls.Add(this.btnteslimver);
            this.Controls.Add(this.btnkitapislemleri);
            this.Name = "anamenü";
            this.Text = "Ana Menü";
            this.Load += new System.EventHandler(this.anamenü_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnkitapislemleri;
        private System.Windows.Forms.Button btnteslimver;
        private System.Windows.Forms.Button btnteslimal;
        private System.Windows.Forms.Button btnlistele;
        private System.Windows.Forms.Button btnyayinevleri;
        private System.Windows.Forms.Button btnuyeislemi;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Button cikis;
    }
}