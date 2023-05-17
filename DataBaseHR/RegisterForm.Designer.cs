namespace DataBaseHR
{
    partial class RegisterForm
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
            this.loginRegisterTextBox = new System.Windows.Forms.TextBox();
            this.passwordRegisterTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.registerButton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginRegisterTextBox
            // 
            this.loginRegisterTextBox.Location = new System.Drawing.Point(83, 30);
            this.loginRegisterTextBox.Name = "loginRegisterTextBox";
            this.loginRegisterTextBox.Size = new System.Drawing.Size(236, 20);
            this.loginRegisterTextBox.TabIndex = 2;
            // 
            // passwordRegisterTextBox
            // 
            this.passwordRegisterTextBox.Location = new System.Drawing.Point(83, 56);
            this.passwordRegisterTextBox.Name = "passwordRegisterTextBox";
            this.passwordRegisterTextBox.Size = new System.Drawing.Size(236, 20);
            this.passwordRegisterTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password:";
            // 
            // registerButton2
            // 
            this.registerButton2.Location = new System.Drawing.Point(163, 101);
            this.registerButton2.Name = "registerButton2";
            this.registerButton2.Size = new System.Drawing.Size(75, 23);
            this.registerButton2.TabIndex = 8;
            this.registerButton2.Text = "Register";
            this.registerButton2.UseVisualStyleBackColor = true;
            this.registerButton2.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 177);
            this.Controls.Add(this.registerButton2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordRegisterTextBox);
            this.Controls.Add(this.loginRegisterTextBox);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox loginRegisterTextBox;
        private System.Windows.Forms.TextBox passwordRegisterTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button registerButton2;
    }
}