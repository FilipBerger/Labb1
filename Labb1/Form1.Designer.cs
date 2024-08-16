namespace Labb1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInput = new TextBox();
            txtOutput = new TextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            lblInput = new Label();
            lblOutput = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(37, 58);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(262, 87);
            txtInput.TabIndex = 0;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(37, 195);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(262, 87);
            txtOutput.TabIndex = 1;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(37, 382);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(77, 27);
            btnEncrypt.TabIndex = 2;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Location = new Point(224, 381);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(75, 28);
            btnDecrypt.TabIndex = 3;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // lblInput
            // 
            lblInput.AutoSize = true;
            lblInput.Location = new Point(37, 35);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(43, 20);
            lblInput.TabIndex = 4;
            lblInput.Text = "Input";
            // 
            // lblOutput
            // 
            lblOutput.AutoSize = true;
            lblOutput.Location = new Point(37, 172);
            lblOutput.Name = "lblOutput";
            lblOutput.Size = new Size(55, 20);
            lblOutput.TabIndex = 5;
            lblOutput.Text = "Output";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(37, 326);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(262, 27);
            txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(37, 303);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 450);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblOutput);
            Controls.Add(lblInput);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(txtOutput);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private TextBox txtOutput;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private Label lblInput;
        private Label lblOutput;
        private TextBox txtPassword;
        private Label lblPassword;
    }
}
