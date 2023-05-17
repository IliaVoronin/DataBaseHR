namespace DataBaseHR
{
    partial class MakeRequestForm
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
            this.requestGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.requestBox = new System.Windows.Forms.ComboBox();
            this.requestTypeTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet4 = new DataBaseHR.DataSet4();
            this.requestButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dataSet1 = new DataBaseHR.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requestTypeTableTableAdapter = new DataBaseHR.DataSet4TableAdapters.requestTypeTableTableAdapter();
            this.requestTypeDataSet = new DataBaseHR.requestTypeDataSet();
            this.requestTypeTableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.requestTypeTableTableAdapter1 = new DataBaseHR.requestTypeDataSetTableAdapters.requestTypeTableTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestTypeTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestTypeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestTypeTableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // requestGridView
            // 
            this.requestGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.requestGridView.Location = new System.Drawing.Point(12, 12);
            this.requestGridView.Name = "requestGridView";
            this.requestGridView.Size = new System.Drawing.Size(451, 150);
            this.requestGridView.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Date";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Approval";
            this.Column4.Name = "Column4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Request:";
            // 
            // requestBox
            // 
            this.requestBox.DataSource = this.requestTypeTableBindingSource1;
            this.requestBox.DisplayMember = "requestTypeName";
            this.requestBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.requestBox.FormattingEnabled = true;
            this.requestBox.Location = new System.Drawing.Point(78, 185);
            this.requestBox.Name = "requestBox";
            this.requestBox.Size = new System.Drawing.Size(121, 21);
            this.requestBox.TabIndex = 2;
            this.requestBox.ValueMember = "requestTypeId";
            // 
            // requestTypeTableBindingSource
            // 
            this.requestTypeTableBindingSource.DataMember = "requestTypeTable";
            this.requestTypeTableBindingSource.DataSource = this.dataSet4;
            // 
            // dataSet4
            // 
            this.dataSet4.DataSetName = "DataSet4";
            this.dataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requestButton
            // 
            this.requestButton.Location = new System.Drawing.Point(331, 183);
            this.requestButton.Name = "requestButton";
            this.requestButton.Size = new System.Drawing.Size(100, 23);
            this.requestButton.TabIndex = 3;
            this.requestButton.Text = "Make request";
            this.requestButton.UseVisualStyleBackColor = true;
            this.requestButton.Click += new System.EventHandler(this.requestButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(331, 212);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // requestTypeTableTableAdapter
            // 
            this.requestTypeTableTableAdapter.ClearBeforeFill = true;
            // 
            // requestTypeDataSet
            // 
            this.requestTypeDataSet.DataSetName = "requestTypeDataSet";
            this.requestTypeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // requestTypeTableBindingSource1
            // 
            this.requestTypeTableBindingSource1.DataMember = "requestTypeTable";
            this.requestTypeTableBindingSource1.DataSource = this.requestTypeDataSet;
            // 
            // requestTypeTableTableAdapter1
            // 
            this.requestTypeTableTableAdapter1.ClearBeforeFill = true;
            // 
            // MakeRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 248);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.requestButton);
            this.Controls.Add(this.requestBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.requestGridView);
            this.Name = "MakeRequestForm";
            this.Text = "MakeRequestForm";
            this.Load += new System.EventHandler(this.MakeRequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.requestGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestTypeTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestTypeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestTypeTableBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView requestGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox requestBox;
        private System.Windows.Forms.Button requestButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet4 dataSet4;
        private System.Windows.Forms.BindingSource requestTypeTableBindingSource;
        private DataSet4TableAdapters.requestTypeTableTableAdapter requestTypeTableTableAdapter;
        private requestTypeDataSet requestTypeDataSet;
        private System.Windows.Forms.BindingSource requestTypeTableBindingSource1;
        private requestTypeDataSetTableAdapters.requestTypeTableTableAdapter requestTypeTableTableAdapter1;
    }
}