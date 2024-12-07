namespace AdminApp
{
    partial class Form2
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
            this.bt1 = new System.Windows.Forms.Button();
            this.TxbLogin = new System.Windows.Forms.TextBox();
            this.TxbPaswd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bt1
            // 
            this.bt1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.bt1.Location = new System.Drawing.Point(21, 146);
            this.bt1.Name = "bt1";
            this.bt1.Size = new System.Drawing.Size(84, 29);
            this.bt1.TabIndex = 0;
            this.bt1.Text = "Войти";
            this.bt1.UseVisualStyleBackColor = false;
            this.bt1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxbLogin
            // 
            this.TxbLogin.Location = new System.Drawing.Point(18, 33);
            this.TxbLogin.Name = "TxbLogin";
            this.TxbLogin.Size = new System.Drawing.Size(100, 20);
            this.TxbLogin.TabIndex = 1;
            this.TxbLogin.Enter += new System.EventHandler(this.TxbLogin_Enter);
            this.TxbLogin.Leave += new System.EventHandler(this.TxbLogin_Leave);
            // 
            // TxbPaswd
            // 
            this.TxbPaswd.Location = new System.Drawing.Point(18, 96);
            this.TxbPaswd.Name = "TxbPaswd";
            this.TxbPaswd.Size = new System.Drawing.Size(100, 20);
            this.TxbPaswd.TabIndex = 1;
            this.TxbPaswd.Enter += new System.EventHandler(this.TxbPaswd_Enter);
            this.TxbPaswd.Leave += new System.EventHandler(this.TxbPaswd_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(251, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxbPaswd);
            this.Controls.Add(this.TxbLogin);
            this.Controls.Add(this.bt1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt1;
        private System.Windows.Forms.TextBox TxbLogin;
        private System.Windows.Forms.TextBox TxbPaswd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}