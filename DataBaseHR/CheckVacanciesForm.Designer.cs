namespace DataBaseHR
{
    partial class CheckVacanciesForm
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
            this.vacanciesGridView = new System.Windows.Forms.DataGridView();
            this.Post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vacanciesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // vacanciesGridView
            // 
            this.vacanciesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vacanciesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Post,
            this.Column1,
            this.Column2});
            this.vacanciesGridView.Location = new System.Drawing.Point(12, 12);
            this.vacanciesGridView.Name = "vacanciesGridView";
            this.vacanciesGridView.Size = new System.Drawing.Size(356, 208);
            this.vacanciesGridView.TabIndex = 0;
            // 
            // Post
            // 
            this.Post.HeaderText = "Post";
            this.Post.Name = "Post";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Salary";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Amount";
            this.Column2.Name = "Column2";
            // 
            // CheckVacanciesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 232);
            this.Controls.Add(this.vacanciesGridView);
            this.Name = "CheckVacanciesForm";
            this.Text = "CheckVacanciesForm";
            this.Load += new System.EventHandler(this.CheckVacanciesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vacanciesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView vacanciesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}