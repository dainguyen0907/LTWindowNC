namespace PhanMemQuanLiVanBan
{
    partial class frm_nguoikyduyet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_nguoiky = new System.Windows.Forms.TextBox();
            this.txt_nguoiduyet = new System.Windows.Forms.TextBox();
            this.txt_nguoigui = new System.Windows.Forms.TextBox();
            this.txt_nguoinhan = new System.Windows.Forms.TextBox();
            this.btn_luu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Người ký";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Người duyệt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Người gửi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Người nhận";
            // 
            // txt_nguoiky
            // 
            this.txt_nguoiky.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nguoiky.Location = new System.Drawing.Point(106, 18);
            this.txt_nguoiky.Name = "txt_nguoiky";
            this.txt_nguoiky.Size = new System.Drawing.Size(197, 26);
            this.txt_nguoiky.TabIndex = 4;
            // 
            // txt_nguoiduyet
            // 
            this.txt_nguoiduyet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nguoiduyet.Location = new System.Drawing.Point(106, 65);
            this.txt_nguoiduyet.Name = "txt_nguoiduyet";
            this.txt_nguoiduyet.Size = new System.Drawing.Size(197, 26);
            this.txt_nguoiduyet.TabIndex = 5;
            // 
            // txt_nguoigui
            // 
            this.txt_nguoigui.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nguoigui.Location = new System.Drawing.Point(106, 114);
            this.txt_nguoigui.Name = "txt_nguoigui";
            this.txt_nguoigui.Size = new System.Drawing.Size(197, 26);
            this.txt_nguoigui.TabIndex = 6;
            // 
            // txt_nguoinhan
            // 
            this.txt_nguoinhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nguoinhan.Location = new System.Drawing.Point(106, 163);
            this.txt_nguoinhan.Name = "txt_nguoinhan";
            this.txt_nguoinhan.Size = new System.Drawing.Size(197, 26);
            this.txt_nguoinhan.TabIndex = 7;
            // 
            // btn_luu
            // 
            this.btn_luu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luu.Location = new System.Drawing.Point(228, 218);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(75, 28);
            this.btn_luu.TabIndex = 8;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // frm_nguoikyduyet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 258);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.txt_nguoinhan);
            this.Controls.Add(this.txt_nguoigui);
            this.Controls.Add(this.txt_nguoiduyet);
            this.Controls.Add(this.txt_nguoiky);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(345, 297);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(345, 297);
            this.Name = "frm_nguoikyduyet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÔNG TIN KÝ DUYỆT";
            this.Load += new System.EventHandler(this.frm_nguoikyduyet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_nguoiky;
        private System.Windows.Forms.TextBox txt_nguoiduyet;
        private System.Windows.Forms.TextBox txt_nguoigui;
        private System.Windows.Forms.TextBox txt_nguoinhan;
        private System.Windows.Forms.Button btn_luu;
    }
}