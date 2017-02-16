/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 2/14/2017
 * Time: 12:58 PM
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace CF_Viewer
{
	/// <summary>
	/// Description of Build.
	/// </summary>
	public class UserInfo
	{
		public string ID, Name, Institute, City, Country, Color, Status, ProPicPath, Contribution, MaxRank;
		public int Rating, Sub, AC, WA, TLE, RE, CE, MLE, Skpd;
		public UserInfo(string DefaultImagePath)
		{
			ID = Name = Institute = City = Country = Color = Status = Contribution = MaxRank = "";
			Rating = Sub = AC = WA = TLE = RE = CE = MLE = Skpd = 0;
			ProPicPath = DefaultImagePath;
		}
	}
	public class Build
	{
		public UserInfo User;
		public string DefaultImagePath;
		private int AC, WA, Skpd, RE, CE, TLE, MLE, Sub, tmp;
		private string s1,s2;
		private string ReqUrl;
		private string RetString;
		private WebRequest RetUrl;
		private Stream RetStream;
		private StreamReader RetReader;
		internal delegate void UpdateProgressDelegate(int ProgressPercentage);
   	 	internal event UpdateProgressDelegate UpdateProgress;
   	 	internal void LoaderValue(int Percentage)
		{
			System.Threading.Thread.Sleep(100);
			UpdateProgress(Percentage);
			Application.DoEvents();
		}
		public Build()
		{	
			try
			{
				DefaultImagePath = Path.GetFullPath(".") + "\\Resource\\default.jpg"; // To obtain path to of the folder containing exe file
			}
			catch (Exception err)
			{
				MessageBox.Show(Path.GetFullPath(".") + "\\Resource\\default.jpg does not exist!", "Error!", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			User = new UserInfo(DefaultImagePath);
		}
		public void Process(string ID) 
		{
			User.ID = ID;
			ProcessRating(ID);
			LoaderValue(20);
			ProcessStatus(ID);
			LoaderValue(60);
			ProcessInfo(ID);
			LoaderValue(80);
		}
		private void ProcessRating(string ID)
		{
			ReqUrl = "http://codeforces.com/api/user.rating?handle=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			JsonUserRatings json = JsonConvert.DeserializeObject <JsonUserRatings> (RetString);
			//User.Color = s1;
			User.Rating = json.result[json.result.Count - 1].newRating;
		}
		private void ProcessStatus(string ID)
		{
			AC = Sub = WA = TLE = RE = CE = MLE = Skpd = 0;
			ReqUrl = "http://codeforces.com/api/user.status?handle=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			JsonUserStatus json = JsonConvert.DeserializeObject <JsonUserStatus> (RetString);
			for (int i = 0; i < json.result.Count; i++)
			{
				s1 = json.result[i].verdict;
				if (s1 == "OK")
				{
					AC++;
				}
				if (s1 == "SKIPPED")
				{
					Skpd++;
				}
				if (s1 == "WRONG_ANSWER")
				{
					WA++;
				}
				if (s1 == "RUNTIME_ERROR")
				{
					RE++;
				}
				if (s1 == "COMPILATION_ERROR")
				{
					CE++;
				}
				if (s1 == "TIME_LIMIT_EXCEEDED")
				{
					TLE++;
				}
				if (s1 == "MEMORY_LIMIT_EXCEEDED")
				{
					MLE++;
				}
			}
			User.Sub = json.result.Count;
			User.AC = AC;
			User.WA = WA;
			User.TLE = TLE;
			User.CE = CE;
			User.RE = RE;
			User.MLE = MLE;
			User.Skpd = Skpd;
		}
		private void ProcessInfo(string ID)
		{
			ReqUrl = "http://codeforces.com/api/user.info?handles=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			JsonUserInfo json = JsonConvert.DeserializeObject <JsonUserInfo> (RetString);
			User.Name = json.result[0].firstName + " " + json.result[0].lastName;
			User.Institute = json.result[0].organization;
			User.City = json.result[0].city;
			User.Status = json.result[0].rank;
			User.Country = json.result[0].country;
			User.MaxRank = json.result[0].maxRank;
			User.Contribution = json.result[0].contribution;
			User.ProPicPath = json.result[0].titlePhoto;
			if (User.ProPicPath == "") User.ProPicPath = DefaultImagePath;
		}
	}
}
