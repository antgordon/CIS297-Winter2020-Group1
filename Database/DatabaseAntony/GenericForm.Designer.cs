namespace DatabaseAntony
{
    partial class GenericForm
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
            this.generalListBox = new System.Windows.Forms.ListBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteRadioBut = new System.Windows.Forms.RadioButton();
            this.updateRadioBut = new System.Windows.Forms.RadioButton();
            this.addRadioBut = new System.Windows.Forms.RadioButton();
            this.submitButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalListBox
            // 
            this.generalListBox.FormattingEnabled = true;
            this.generalListBox.Location = new System.Drawing.Point(101, 107);
            this.generalListBox.Name = "generalListBox";
            this.generalListBox.Size = new System.Drawing.Size(120, 95);
            this.generalListBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(451, 87);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteRadioBut);
            this.groupBox1.Controls.Add(this.updateRadioBut);
            this.groupBox1.Controls.Add(this.addRadioBut);
            this.groupBox1.Location = new System.Drawing.Point(588, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 144);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // deleteRadioBut
            // 
            this.deleteRadioBut.AutoSize = true;
            this.deleteRadioBut.Location = new System.Drawing.Point(7, 90);
            this.deleteRadioBut.Name = "deleteRadioBut";
            this.deleteRadioBut.Size = new System.Drawing.Size(84, 17);
            this.deleteRadioBut.TabIndex = 2;
            this.deleteRadioBut.TabStop = true;
            this.deleteRadioBut.Text = "DeleteRadio";
            this.deleteRadioBut.UseVisualStyleBackColor = true;
            // 
            // updateRadioBut
            // 
            this.updateRadioBut.AutoSize = true;
            this.updateRadioBut.Location = new System.Drawing.Point(7, 53);
            this.updateRadioBut.Name = "updateRadioBut";
            this.updateRadioBut.Size = new System.Drawing.Size(91, 17);
            this.updateRadioBut.TabIndex = 1;
            this.updateRadioBut.TabStop = true;
            this.updateRadioBut.Text = "Update Radio";
            this.updateRadioBut.UseVisualStyleBackColor = true;
            // 
            // addRadioBut
            // 
            this.addRadioBut.AutoSize = true;
            this.addRadioBut.Checked = true;
            this.addRadioBut.Location = new System.Drawing.Point(6, 19);
            this.addRadioBut.Name = "addRadioBut";
            this.addRadioBut.Size = new System.Drawing.Size(75, 17);
            this.addRadioBut.TabIndex = 0;
            this.addRadioBut.TabStop = true;
            this.addRadioBut.Text = "Add Radio";
            this.addRadioBut.UseVisualStyleBackColor = true;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(461, 234);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            // 
            // GenericForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.generalListBox);
            this.Name = "GenericForm";
            this.Text = "DepartmentForm2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox generalListBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton addRadioBut;
        private System.Windows.Forms.RadioButton deleteRadioBut;
        private System.Windows.Forms.RadioButton updateRadioBut;
        private System.Windows.Forms.Button submitButton;
    }
}