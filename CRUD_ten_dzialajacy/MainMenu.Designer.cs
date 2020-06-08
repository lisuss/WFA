namespace CRUD_ten_dzialajacy
{
    partial class MainMenu
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
            this.CustomersButton = new System.Windows.Forms.Button();
            this.ArticlesButton = new System.Windows.Forms.Button();
            this.specialIngredientsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustomersButton
            // 
            this.CustomersButton.Location = new System.Drawing.Point(38, 35);
            this.CustomersButton.Name = "CustomersButton";
            this.CustomersButton.Size = new System.Drawing.Size(133, 23);
            this.CustomersButton.TabIndex = 0;
            this.CustomersButton.Text = "Customers Options";
            this.CustomersButton.UseVisualStyleBackColor = true;
            this.CustomersButton.Click += new System.EventHandler(this.CustomersButton_Click);
            // 
            // ArticlesButton
            // 
            this.ArticlesButton.Location = new System.Drawing.Point(38, 102);
            this.ArticlesButton.Name = "ArticlesButton";
            this.ArticlesButton.Size = new System.Drawing.Size(133, 23);
            this.ArticlesButton.TabIndex = 1;
            this.ArticlesButton.Text = "Articles Options";
            this.ArticlesButton.UseMnemonic = false;
            this.ArticlesButton.UseVisualStyleBackColor = true;
            this.ArticlesButton.Click += new System.EventHandler(this.ArticlesButton_Click);
            // 
            // specialIngredientsButton
            // 
            this.specialIngredientsButton.Location = new System.Drawing.Point(38, 167);
            this.specialIngredientsButton.Name = "specialIngredientsButton";
            this.specialIngredientsButton.Size = new System.Drawing.Size(133, 23);
            this.specialIngredientsButton.TabIndex = 2;
            this.specialIngredientsButton.Text = "Special Options";
            this.specialIngredientsButton.UseMnemonic = false;
            this.specialIngredientsButton.UseVisualStyleBackColor = true;
            this.specialIngredientsButton.Click += new System.EventHandler(this.specialIngredientsButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.specialIngredientsButton);
            this.Controls.Add(this.ArticlesButton);
            this.Controls.Add(this.CustomersButton);
            this.Name = "MainMenu";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CustomersButton;
        private System.Windows.Forms.Button ArticlesButton;
        private System.Windows.Forms.Button specialIngredientsButton;
    }
}