
namespace Font_Gen_Rename
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
            this.OutputLabel = new System.Windows.Forms.Label();
            this.OutputPathBox = new System.Windows.Forms.TextBox();
            this.FormOKButton = new System.Windows.Forms.Button();
            this.FormCancelButton = new System.Windows.Forms.Button();
            this.UndoRenameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(12, 7);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(55, 15);
            this.OutputLabel.TabIndex = 2;
            this.OutputLabel.Text = "出力先：";
            // 
            // OutputPathBox
            // 
            this.OutputPathBox.Location = new System.Drawing.Point(11, 25);
            this.OutputPathBox.Name = "OutputPathBox";
            this.OutputPathBox.Size = new System.Drawing.Size(363, 23);
            this.OutputPathBox.TabIndex = 1;
            // 
            // FormOKButton
            // 
            this.FormOKButton.Location = new System.Drawing.Point(206, 54);
            this.FormOKButton.Name = "FormOKButton";
            this.FormOKButton.Size = new System.Drawing.Size(87, 23);
            this.FormOKButton.TabIndex = 3;
            this.FormOKButton.Text = "実行";
            this.FormOKButton.UseVisualStyleBackColor = true;
            this.FormOKButton.Click += new System.EventHandler(this.FormOKButton_Click);
            // 
            // FormCancelButton
            // 
            this.FormCancelButton.Location = new System.Drawing.Point(13, 54);
            this.FormCancelButton.Name = "FormCancelButton";
            this.FormCancelButton.Size = new System.Drawing.Size(187, 23);
            this.FormCancelButton.TabIndex = 2;
            this.FormCancelButton.Text = "キャンセル";
            this.FormCancelButton.UseVisualStyleBackColor = true;
            this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButton_Click);
            // 
            // UndoRenameButton
            // 
            this.UndoRenameButton.Location = new System.Drawing.Point(299, 54);
            this.UndoRenameButton.Name = "UndoRenameButton";
            this.UndoRenameButton.Size = new System.Drawing.Size(75, 23);
            this.UndoRenameButton.TabIndex = 4;
            this.UndoRenameButton.Text = "元に戻す";
            this.UndoRenameButton.UseVisualStyleBackColor = true;
            this.UndoRenameButton.Click += new System.EventHandler(this.UndoRenameButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.FormCancelButton;
            this.ClientSize = new System.Drawing.Size(386, 91);
            this.Controls.Add(this.UndoRenameButton);
            this.Controls.Add(this.FormCancelButton);
            this.Controls.Add(this.FormOKButton);
            this.Controls.Add(this.OutputPathBox);
            this.Controls.Add(this.OutputLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(402, 130);
            this.MinimumSize = new System.Drawing.Size(402, 130);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Font Gen Renamer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.TextBox OutputPathBox;
        private System.Windows.Forms.Button FormOKButton;
        private System.Windows.Forms.Button FormCancelButton;
        private System.Windows.Forms.Button UndoRenameButton;
    }
}

