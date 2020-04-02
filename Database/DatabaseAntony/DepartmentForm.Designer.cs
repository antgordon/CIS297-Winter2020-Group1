namespace DatabaseAntony
{
    partial class DepartmentForm
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
            this.AddButton = new System.Windows.Forms.Button();
            this.DepNameTextbox = new System.Windows.Forms.TextBox();
            this.departmentGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.departmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(579, 91);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DepNameTextbox
            // 
            this.DepNameTextbox.Location = new System.Drawing.Point(554, 65);
            this.DepNameTextbox.Name = "DepNameTextbox";
            this.DepNameTextbox.Size = new System.Drawing.Size(100, 20);
            this.DepNameTextbox.TabIndex = 1;
            // 
            // departmentGrid
            // 
            this.departmentGrid.AllowUserToAddRows = false;
            this.departmentGrid.AllowUserToDeleteRows = false;
            this.departmentGrid.AllowUserToResizeColumns = false;
            this.departmentGrid.AllowUserToResizeRows = false;
            this.departmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.departmentGrid.Location = new System.Drawing.Point(106, 49);
            this.departmentGrid.Name = "departmentGrid";
            this.departmentGrid.Size = new System.Drawing.Size(240, 150);
            this.departmentGrid.TabIndex = 2;
            this.departmentGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.departmentGrid_CellContentDoubleClick);
            this.departmentGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.departmentGrid_CellEndEdit);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "RemoveButton";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // DepartmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.departmentGrid);
            this.Controls.Add(this.DepNameTextbox);
            this.Controls.Add(this.AddButton);
            this.Name = "DepartmentForm";
            this.Text = "DepartmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.departmentGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox DepNameTextbox;
        private System.Windows.Forms.DataGridView departmentGrid;
        private System.Windows.Forms.Button button1;
    }
}