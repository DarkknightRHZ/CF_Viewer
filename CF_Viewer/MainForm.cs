/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 2/14/2017
 * Time: 12:44 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Linq;
using CF_Viewer;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CF_Viewer
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public Build Bld;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Bld = new Build();
			Bld.UpdateProgress += UpdateProgress;
			LoadingBar.Maximum = 100;
			ProPic.Image = Image.FromFile(Bld.DefaultImagePath);
			ProPic.SizeMode = PictureBoxSizeMode.StretchImage;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void SearchButtonClick(object sender, EventArgs e)
		{
			string ID = ReqTextBox.Text;
			ProPic.Image = Image.FromFile(Bld.DefaultImagePath);
			InfoTextBox.Text = "Collecting Information, Please Wait......";
			System.Threading.Thread.Sleep(100);
			UpdateProgress(10);
			try
			{
				Bld.Process(ID);
			}
			catch (Exception err)
			{
				MessageBox.Show("Sorry, something went wrong! Check your internet connection and please try later.","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			ShowInfo(Bld.User);
			System.Threading.Thread.Sleep(100);
			UpdateProgress(0);
		}
		private void ShowInfo(UserInfo User)
		{
			InfoTextBox.Text = "Thank you for your request! " + User.ID + " has the following informations available.\n\n";
			InfoTextBox.Text = InfoTextBox.Text + "Full Name = " + Bld.User.Name + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Organization = " + Bld.User.Institute + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "City = " + Bld.User.City + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Country = " + Bld.User.Country + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Rating = " + Bld.User.Rating + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Rank = " + Bld.User.Status + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Max. Rank = " + Bld.User.MaxRank + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Contribution Count = " + Bld.User.Contribution + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Submission Count = " + Bld.User.Sub + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Accepted Count = " + Bld.User.AC + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Wrong Answer Count  = " + Bld.User.WA + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Time Limit Exceeded Count  = " + Bld.User.TLE + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Runtime Error Count  = " + Bld.User.RE + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Compilation Error Count  = " + Bld.User.CE + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Memory Limit Exceeded Count  = " + Bld.User.MLE + "\n";
			InfoTextBox.Text = InfoTextBox.Text + "Skipped Count  = " + Bld.User.Skpd + "\n";
			System.Threading.Thread.Sleep(100);
			UpdateProgress(90);
			SetImage(User.ProPicPath);
			System.Threading.Thread.Sleep(100);
			UpdateProgress(100);
		}
		private void SetImage(string pth)
		{
			if (pth == Bld.DefaultImagePath)
			{
				try
				{
					ProPic.Image = Image.FromFile(pth);
				}
				catch (Exception err) 
				{
					MessageBox.Show(pth + " does not exist!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
			else
			{
				try
				{
					WebRequest RetUrl = WebRequest.Create(pth);
					Stream RetStream = RetUrl.GetResponse().GetResponseStream();
					ProPic.Image = Image.FromStream(RetStream);
				}
				catch(Exception err)
				{
					MessageBox.Show(pth + " does not exist!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
		}
		void ProPicClick(object sender, EventArgs e)
		{
	
		}
		void ReqTextBoxTextChanged(object sender, EventArgs e)
		{
	
		}
		void InfoTextBoxTextChanged(object sender, EventArgs e)
		{
	
		}
		private void UpdateProgress(int ProgressPercentage)  
		{
			LoadingBar.Value = ProgressPercentage;
    	}
	}
}
