namespace Database
{
    partial class EditForm
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
            this.title_Label = new System.Windows.Forms.Label();
            this.create_Button = new System.Windows.Forms.RadioButton();
            this.read_Button = new System.Windows.Forms.RadioButton();
            this.update_Button = new System.Windows.Forms.RadioButton();
            this.delete_Button = new System.Windows.Forms.RadioButton();
            this.table_ListBox = new System.Windows.Forms.ListBox();
            this.option1_TextBox = new System.Windows.Forms.TextBox();
            this.option2_TextBox = new System.Windows.Forms.TextBox();
            this.option3_TextBox = new System.Windows.Forms.TextBox();
            this.option4_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.option1_Label = new System.Windows.Forms.Label();
            this.option2_Label = new System.Windows.Forms.Label();
            this.option3_Label = new System.Windows.Forms.Label();
            this.option4_Label = new System.Windows.Forms.Label();
            this.tableContent_ListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // title_Label
            // 
            this.title_Label.AutoSize = true;
            this.title_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_Label.Location = new System.Drawing.Point(231, 9);
            this.title_Label.Name = "title_Label";
            this.title_Label.Size = new System.Drawing.Size(321, 37);
            this.title_Label.TabIndex = 2;
            this.title_Label.Text = "Database Edit Form";
            // 
            // create_Button
            // 
            this.create_Button.AutoSize = true;
            this.create_Button.Location = new System.Drawing.Point(38, 61);
            this.create_Button.Name = "create_Button";
            this.create_Button.Size = new System.Drawing.Size(56, 17);
            this.create_Button.TabIndex = 3;
            this.create_Button.TabStop = true;
            this.create_Button.Text = "Create";
            this.create_Button.UseVisualStyleBackColor = true;
            this.create_Button.Click += new System.EventHandler(this.create_Button_Selected);
            // 
            // read_Button
            // 
            this.read_Button.AutoSize = true;
            this.read_Button.Location = new System.Drawing.Point(38, 84);
            this.read_Button.Name = "read_Button";
            this.read_Button.Size = new System.Drawing.Size(51, 17);
            this.read_Button.TabIndex = 4;
            this.read_Button.TabStop = true;
            this.read_Button.Text = "Read";
            this.read_Button.UseVisualStyleBackColor = true;
            this.read_Button.Click += new System.EventHandler(this.read_Button_Selected);
            // 
            // update_Button
            // 
            this.update_Button.AutoSize = true;
            this.update_Button.Location = new System.Drawing.Point(38, 107);
            this.update_Button.Name = "update_Button";
            this.update_Button.Size = new System.Drawing.Size(60, 17);
            this.update_Button.TabIndex = 5;
            this.update_Button.TabStop = true;
            this.update_Button.Text = "Update";
            this.update_Button.UseVisualStyleBackColor = true;
            // 
            // delete_Button
            // 
            this.delete_Button.AutoSize = true;
            this.delete_Button.Location = new System.Drawing.Point(38, 130);
            this.delete_Button.Name = "delete_Button";
            this.delete_Button.Size = new System.Drawing.Size(56, 17);
            this.delete_Button.TabIndex = 6;
            this.delete_Button.TabStop = true;
            this.delete_Button.Text = "Delete";
            this.delete_Button.UseVisualStyleBackColor = true;
            // 
            // table_ListBox
            // 
            this.table_ListBox.FormattingEnabled = true;
            this.table_ListBox.Location = new System.Drawing.Point(163, 61);
            this.table_ListBox.Name = "table_ListBox";
            this.table_ListBox.Size = new System.Drawing.Size(120, 95);
            this.table_ListBox.TabIndex = 7;
            this.table_ListBox.SelectedValueChanged += new System.EventHandler(this.Table_Selected);
            // 
            // option1_TextBox
            // 
            this.option1_TextBox.Location = new System.Drawing.Point(452, 81);
            this.option1_TextBox.Name = "option1_TextBox";
            this.option1_TextBox.Size = new System.Drawing.Size(100, 20);
            this.option1_TextBox.TabIndex = 8;
            // 
            // option2_TextBox
            // 
            this.option2_TextBox.Location = new System.Drawing.Point(452, 117);
            this.option2_TextBox.Name = "option2_TextBox";
            this.option2_TextBox.Size = new System.Drawing.Size(100, 20);
            this.option2_TextBox.TabIndex = 9;
            // 
            // option3_TextBox
            // 
            this.option3_TextBox.Location = new System.Drawing.Point(452, 153);
            this.option3_TextBox.Name = "option3_TextBox";
            this.option3_TextBox.Size = new System.Drawing.Size(100, 20);
            this.option3_TextBox.TabIndex = 10;
            // 
            // option4_TextBox
            // 
            this.option4_TextBox.Location = new System.Drawing.Point(452, 189);
            this.option4_TextBox.Name = "option4_TextBox";
            this.option4_TextBox.Size = new System.Drawing.Size(100, 20);
            this.option4_TextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Operation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Table:";
            // 
            // option1_Label
            // 
            this.option1_Label.AutoSize = true;
            this.option1_Label.Location = new System.Drawing.Point(387, 84);
            this.option1_Label.Name = "option1_Label";
            this.option1_Label.Size = new System.Drawing.Size(59, 13);
            this.option1_Label.TabIndex = 14;
            this.option1_Label.Text = "<Option 1>";
            // 
            // option2_Label
            // 
            this.option2_Label.AutoSize = true;
            this.option2_Label.Location = new System.Drawing.Point(387, 120);
            this.option2_Label.Name = "option2_Label";
            this.option2_Label.Size = new System.Drawing.Size(59, 13);
            this.option2_Label.TabIndex = 15;
            this.option2_Label.Text = "<Option 2>";
            // 
            // option3_Label
            // 
            this.option3_Label.AutoSize = true;
            this.option3_Label.Location = new System.Drawing.Point(387, 157);
            this.option3_Label.Name = "option3_Label";
            this.option3_Label.Size = new System.Drawing.Size(59, 13);
            this.option3_Label.TabIndex = 16;
            this.option3_Label.Text = "<Option 3>";
            // 
            // option4_Label
            // 
            this.option4_Label.AutoSize = true;
            this.option4_Label.Location = new System.Drawing.Point(387, 192);
            this.option4_Label.Name = "option4_Label";
            this.option4_Label.Size = new System.Drawing.Size(59, 13);
            this.option4_Label.TabIndex = 17;
            this.option4_Label.Text = "<Option 4>";
            // 
            // tableContent_ListBox
            // 
            this.tableContent_ListBox.FormattingEnabled = true;
            this.tableContent_ListBox.Location = new System.Drawing.Point(38, 242);
            this.tableContent_ListBox.Name = "tableContent_ListBox";
            this.tableContent_ListBox.Size = new System.Drawing.Size(710, 199);
            this.tableContent_ListBox.TabIndex = 18;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableContent_ListBox);
            this.Controls.Add(this.option4_Label);
            this.Controls.Add(this.option3_Label);
            this.Controls.Add(this.option2_Label);
            this.Controls.Add(this.option1_Label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.option4_TextBox);
            this.Controls.Add(this.option3_TextBox);
            this.Controls.Add(this.option2_TextBox);
            this.Controls.Add(this.option1_TextBox);
            this.Controls.Add(this.table_ListBox);
            this.Controls.Add(this.delete_Button);
            this.Controls.Add(this.update_Button);
            this.Controls.Add(this.read_Button);
            this.Controls.Add(this.create_Button);
            this.Controls.Add(this.title_Label);
            this.Name = "EditForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title_Label;
        private System.Windows.Forms.RadioButton create_Button;
        private System.Windows.Forms.RadioButton read_Button;
        private System.Windows.Forms.RadioButton update_Button;
        private System.Windows.Forms.RadioButton delete_Button;
        private System.Windows.Forms.ListBox table_ListBox;
        private System.Windows.Forms.TextBox option1_TextBox;
        private System.Windows.Forms.TextBox option2_TextBox;
        private System.Windows.Forms.TextBox option3_TextBox;
        private System.Windows.Forms.TextBox option4_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label option1_Label;
        private System.Windows.Forms.Label option2_Label;
        private System.Windows.Forms.Label option3_Label;
        private System.Windows.Forms.Label option4_Label;
        private System.Windows.Forms.ListBox tableContent_ListBox;
    }
}