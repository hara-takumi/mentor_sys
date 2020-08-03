namespace Menter
{
    partial class MH0041
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
            this.btnToroku = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "差戻理由を入力してください";
            // 
            // btnToroku
            // 
            this.btnToroku.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnToroku.Location = new System.Drawing.Point(305, 172);
            this.btnToroku.Name = "btnToroku";
            this.btnToroku.Size = new System.Drawing.Size(102, 32);
            this.btnToroku.TabIndex = 3;
            this.btnToroku.Text = "登録";
            this.btnToroku.UseVisualStyleBackColor = true;
            this.btnToroku.Click += new System.EventHandler(this.btnToroku_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.btnReturn.Location = new System.Drawing.Point(58, 172);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(102, 32);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "戻る";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(60, 54);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(347, 106);
            this.txtReason.TabIndex = 1;
            this.txtReason.Text = "";
            // 
            // MH0041
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 231);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnToroku);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 16F);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "MH0041";
            this.Text = "MH0041";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToroku;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.RichTextBox txtReason;
    }
}