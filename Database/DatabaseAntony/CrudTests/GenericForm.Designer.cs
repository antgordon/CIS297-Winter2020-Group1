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
            this.deptLabel = new System.Windows.Forms.Label();
            this.seasonLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deptRadio = new System.Windows.Forms.RadioButton();
            this.seasonRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // deptLabel
            // 
            this.deptLabel.AutoSize = true;
            this.deptLabel.Location = new System.Drawing.Point(264, 53);
            this.deptLabel.Name = "deptLabel";
            this.deptLabel.Size = new System.Drawing.Size(94, 13);
            this.deptLabel.TabIndex = 4;
            this.deptLabel.Text = "Editing Deparment";
            this.deptLabel.UseWaitCursor = true;
            // 
            // seasonLabel
            // 
            this.seasonLabel.AutoSize = true;
            this.seasonLabel.Location = new System.Drawing.Point(279, 87);
            this.seasonLabel.Name = "seasonLabel";
            this.seasonLabel.Size = new System.Drawing.Size(78, 13);
            this.seasonLabel.TabIndex = 5;
            this.seasonLabel.Text = "Editing Season";
            this.seasonLabel.UseWaitCursor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.seasonRadio);
            this.groupBox2.Controls.Add(this.deptRadio);
            this.groupBox2.Location = new System.Drawing.Point(69, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // deptRadio
            // 
            this.deptRadio.AutoSize = true;
            this.deptRadio.Checked = true;
            this.deptRadio.Location = new System.Drawing.Point(32, 30);
            this.deptRadio.Name = "deptRadio";
            this.deptRadio.Size = new System.Drawing.Size(101, 17);
            this.deptRadio.TabIndex = 0;
            this.deptRadio.TabStop = true;
            this.deptRadio.Text = "Edit Department";
            this.deptRadio.UseVisualStyleBackColor = true;
            this.deptRadio.CheckedChanged += new System.EventHandler(this.deptRadio_CheckedChanged);
            // 
            // seasonRadio
            // 
            this.seasonRadio.AutoSize = true;
            this.seasonRadio.Location = new System.Drawing.Point(32, 64);
            this.seasonRadio.Name = "seasonRadio";
            this.seasonRadio.Size = new System.Drawing.Size(82, 17);
            this.seasonRadio.TabIndex = 1;
            this.seasonRadio.Text = "Edit Season";
            this.seasonRadio.UseVisualStyleBackColor = true;
            this.seasonRadio.CheckedChanged += new System.EventHandler(this.seasonRadio_CheckedChanged);
            // 
            // GenericForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.seasonLabel);
            this.Controls.Add(this.deptLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.generalListBox);
            this.Name = "GenericForm";
            this.Text = "Editing Season";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label deptLabel;
        private System.Windows.Forms.Label seasonLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton seasonRadio;
        private System.Windows.Forms.RadioButton deptRadio;
    }
}