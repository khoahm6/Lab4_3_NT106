namespace Lab4_3
{
    partial class Form1
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
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.addressBar = new System.Windows.Forms.TextBox();
            this.goButton = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.downfilesButton = new System.Windows.Forms.Button();
            this.downRButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(-1, 64);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(801, 384);
            this.webView.Source = new System.Uri("https://uit.edu.vn/", System.UriKind.Absolute);
            this.webView.TabIndex = 1;
            this.webView.ZoomFactor = 1D;
            // 
            // addressBar
            // 
            this.addressBar.Location = new System.Drawing.Point(93, 12);
            this.addressBar.Name = "addressBar";
            this.addressBar.Size = new System.Drawing.Size(584, 22);
            this.addressBar.TabIndex = 2;
            this.addressBar.Text = "https://uit.edu.vn/";
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(12, 11);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 3;
            this.goButton.Text = "Load";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(684, 11);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(90, 23);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // downfilesButton
            // 
            this.downfilesButton.Location = new System.Drawing.Point(515, 40);
            this.downfilesButton.Name = "downfilesButton";
            this.downfilesButton.Size = new System.Drawing.Size(103, 23);
            this.downfilesButton.TabIndex = 5;
            this.downfilesButton.Text = "Down Files";
            this.downfilesButton.UseVisualStyleBackColor = true;
            this.downfilesButton.Click += new System.EventHandler(this.downfilesButton_Click);
            // 
            // downRButton
            // 
            this.downRButton.Location = new System.Drawing.Point(638, 40);
            this.downRButton.Name = "downRButton";
            this.downRButton.Size = new System.Drawing.Size(136, 23);
            this.downRButton.TabIndex = 6;
            this.downRButton.Text = "Down Resources ";
            this.downRButton.UseVisualStyleBackColor = true;
            this.downRButton.Click += new System.EventHandler(this.downRButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.downRButton);
            this.Controls.Add(this.downfilesButton);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.addressBar);
            this.Controls.Add(this.webView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.TextBox addressBar;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button downfilesButton;
        private System.Windows.Forms.Button downRButton;
    }
}

