namespace PhanMemQuanLiVanBan
{
    partial class frm_KetNoiDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_KetNoiDatabase));
            this.connectDatabase1 = new MyTools.ConnectDatabase();
            this.SuspendLayout();
            // 
            // connectDatabase1
            // 
            this.connectDatabase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectDatabase1.Location = new System.Drawing.Point(0, 0);
            this.connectDatabase1.Name = "connectDatabase1";
            this.connectDatabase1.Size = new System.Drawing.Size(298, 322);
            this.connectDatabase1.TabIndex = 0;
            // 
            // frm_KetNoiDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(298, 322);
            this.Controls.Add(this.connectDatabase1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_KetNoiDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết nối dữ liệu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_KetNoiDatabase_FormClosing);
            this.Load += new System.EventHandler(this.frm_KetNoiDatabase_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyTools.ConnectDatabase connectDatabase1;



    }
}