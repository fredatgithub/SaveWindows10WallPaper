using System.ComponentModel;
using System.Windows.Forms;

namespace SaveWindows10WallPaper
{
  partial class FormOptions
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
      checkBoxOption1 = new CheckBox();
      checkBoxOption2 = new CheckBox();
      buttonOptionsOK = new Button();
      buttonOptionsCancel = new Button();
      SuspendLayout();
      // 
      // checkBoxOption1
      // 
      this.checkBoxOption1.AutoSize = true;
      this.checkBoxOption1.Location = new System.Drawing.Point(41, 55);
      this.checkBoxOption1.Margin = new System.Windows.Forms.Padding(4);
      this.checkBoxOption1.Name = "checkBoxOption1";
      this.checkBoxOption1.Size = new System.Drawing.Size(80, 21);
      this.checkBoxOption1.TabIndex = 0;
      this.checkBoxOption1.Text = "Option1";
      this.checkBoxOption1.UseVisualStyleBackColor = true;
      // 
      // checkBoxOption2
      // 
      this.checkBoxOption2.AutoSize = true;
      this.checkBoxOption2.Location = new System.Drawing.Point(41, 87);
      this.checkBoxOption2.Margin = new System.Windows.Forms.Padding(4);
      this.checkBoxOption2.Name = "checkBoxOption2";
      this.checkBoxOption2.Size = new System.Drawing.Size(80, 21);
      this.checkBoxOption2.TabIndex = 1;
      this.checkBoxOption2.Text = "Option2";
      this.checkBoxOption2.UseVisualStyleBackColor = true;
      // 
      // buttonOptionsOK
      // 
      this.buttonOptionsOK.Location = new System.Drawing.Point(155, 144);
      this.buttonOptionsOK.Margin = new System.Windows.Forms.Padding(4);
      this.buttonOptionsOK.Name = "buttonOptionsOK";
      this.buttonOptionsOK.Size = new System.Drawing.Size(100, 28);
      this.buttonOptionsOK.TabIndex = 2;
      this.buttonOptionsOK.Text = "OK";
      this.buttonOptionsOK.UseVisualStyleBackColor = true;
      this.buttonOptionsOK.Click += new System.EventHandler(this.buttonOptionsOK_Click);
      // 
      // buttonOptionsCancel
      // 
      this.buttonOptionsCancel.Location = new System.Drawing.Point(263, 144);
      this.buttonOptionsCancel.Margin = new System.Windows.Forms.Padding(4);
      this.buttonOptionsCancel.Name = "buttonOptionsCancel";
      this.buttonOptionsCancel.Size = new System.Drawing.Size(100, 28);
      this.buttonOptionsCancel.TabIndex = 3;
      this.buttonOptionsCancel.Text = "Cancel";
      this.buttonOptionsCancel.UseVisualStyleBackColor = true;
      this.buttonOptionsCancel.Click += new System.EventHandler(this.buttonOptionsCancel_Click);
      // 
      // FormOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(379, 195);
      this.Controls.Add(this.buttonOptionsCancel);
      this.Controls.Add(this.buttonOptionsOK);
      this.Controls.Add(this.checkBoxOption2);
      this.Controls.Add(this.checkBoxOption1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormOptions";
      this.ShowIcon = false;
      this.Text = "Options";
      this.Load += new System.EventHandler(this.FormOptions_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckBox checkBoxOption1;
    private System.Windows.Forms.CheckBox checkBoxOption2;
    private System.Windows.Forms.Button buttonOptionsOK;
    private System.Windows.Forms.Button buttonOptionsCancel;
  }
}