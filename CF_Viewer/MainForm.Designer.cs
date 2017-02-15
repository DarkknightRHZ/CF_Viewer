/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 2/14/2017
 * Time: 12:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CF_Viewer
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox ReqTextBox;
		private System.Windows.Forms.Button SearchButton;
		private System.Windows.Forms.RichTextBox InfoTextBox;
		private System.Windows.Forms.PictureBox ProPic;
		private System.Windows.Forms.Label MainLevel;
		private System.Windows.Forms.Label InstructionLevel;
		private System.Windows.Forms.LinkLabel LinkLabel;
		private System.Windows.Forms.ProgressBar LoadingBar;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.ReqTextBox = new System.Windows.Forms.TextBox();
			this.SearchButton = new System.Windows.Forms.Button();
			this.InfoTextBox = new System.Windows.Forms.RichTextBox();
			this.ProPic = new System.Windows.Forms.PictureBox();
			this.MainLevel = new System.Windows.Forms.Label();
			this.InstructionLevel = new System.Windows.Forms.Label();
			this.LinkLabel = new System.Windows.Forms.LinkLabel();
			this.LoadingBar = new System.Windows.Forms.ProgressBar();
			((System.ComponentModel.ISupportInitialize)(this.ProPic)).BeginInit();
			this.SuspendLayout();
			// 
			// ReqTextBox
			// 
			this.ReqTextBox.Location = new System.Drawing.Point(98, 72);
			this.ReqTextBox.Name = "ReqTextBox";
			this.ReqTextBox.Size = new System.Drawing.Size(193, 20);
			this.ReqTextBox.TabIndex = 0;
			this.ReqTextBox.TextChanged += new System.EventHandler(this.ReqTextBoxTextChanged);
			// 
			// SearchButton
			// 
			this.SearchButton.Location = new System.Drawing.Point(297, 72);
			this.SearchButton.Name = "SearchButton";
			this.SearchButton.Size = new System.Drawing.Size(78, 20);
			this.SearchButton.TabIndex = 1;
			this.SearchButton.Text = "Search";
			this.SearchButton.UseVisualStyleBackColor = true;
			this.SearchButton.Click += new System.EventHandler(this.SearchButtonClick);
			// 
			// InfoTextBox
			// 
			this.InfoTextBox.Location = new System.Drawing.Point(12, 123);
			this.InfoTextBox.Name = "InfoTextBox";
			this.InfoTextBox.Size = new System.Drawing.Size(363, 183);
			this.InfoTextBox.TabIndex = 2;
			this.InfoTextBox.Text = "";
			this.InfoTextBox.TextChanged += new System.EventHandler(this.InfoTextBoxTextChanged);
			// 
			// ProPic
			// 
			this.ProPic.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ProPic.Location = new System.Drawing.Point(12, 12);
			this.ProPic.Name = "ProPic";
			this.ProPic.Size = new System.Drawing.Size(80, 80);
			this.ProPic.TabIndex = 3;
			this.ProPic.TabStop = false;
			this.ProPic.Click += new System.EventHandler(this.ProPicClick);
			// 
			// MainLevel
			// 
			this.MainLevel.Location = new System.Drawing.Point(112, 12);
			this.MainLevel.Name = "MainLevel";
			this.MainLevel.Size = new System.Drawing.Size(252, 23);
			this.MainLevel.TabIndex = 4;
			this.MainLevel.Text = "Codeforces User Details Viewer!";
			this.MainLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// InstructionLevel
			// 
			this.InstructionLevel.Location = new System.Drawing.Point(112, 35);
			this.InstructionLevel.Name = "InstructionLevel";
			this.InstructionLevel.Size = new System.Drawing.Size(263, 34);
			this.InstructionLevel.TabIndex = 5;
			this.InstructionLevel.Text = "Type Below The Required Codeforces Handle and Click \'Search\'";
			this.InstructionLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// LinkLabel
			// 
			this.LinkLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.LinkLabel.Location = new System.Drawing.Point(0, 310);
			this.LinkLabel.Name = "LinkLabel";
			this.LinkLabel.Size = new System.Drawing.Size(387, 23);
			this.LinkLabel.TabIndex = 6;
			this.LinkLabel.TabStop = true;
			this.LinkLabel.Text = "rhzinuk@gmail.com";
			this.LinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// LoadingBar
			// 
			this.LoadingBar.Location = new System.Drawing.Point(12, 98);
			this.LoadingBar.Name = "LoadingBar";
			this.LoadingBar.Size = new System.Drawing.Size(363, 19);
			this.LoadingBar.TabIndex = 7;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(387, 333);
			this.Controls.Add(this.LoadingBar);
			this.Controls.Add(this.LinkLabel);
			this.Controls.Add(this.InstructionLevel);
			this.Controls.Add(this.MainLevel);
			this.Controls.Add(this.ProPic);
			this.Controls.Add(this.InfoTextBox);
			this.Controls.Add(this.SearchButton);
			this.Controls.Add(this.ReqTextBox);
			this.Name = "MainForm";
			this.Text = "CF_Viewer";
			((System.ComponentModel.ISupportInitialize)(this.ProPic)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
