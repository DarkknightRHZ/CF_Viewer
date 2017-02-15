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
			tmp = 0;
			for (int i = RetString.Length - 7; i <= RetString.Length - 4; i++)
			{
				if (RetString[i] < '0' || RetString[i] > '9') break;
				tmp *= 10;
				tmp += (RetString[i] - '0');
			}
			s1 = "";
			s2 = "";
			if (tmp < 1200) 
			{
				s1 = "d3d1c2";
				s2 = "Newbie";
			}
			else if (tmp >= 1200 && tmp < 1400)
			{
				s1 = "008000";
				s2 = "Pupil";
			}
			else if (tmp >= 1400 && tmp < 1600)
			{
				s1 = "00cccc";
				s2 = "Specialist";
			}
			else if (tmp >= 1600 && tmp < 1900)
			{
				s1 = "0000FF";
				s2 = "Expert";
			}
			else if (tmp >= 1900 && tmp < 2200)
			{
				s1 = "ff33cc";
				s2 = "Candidate Master";
			}
			else if (tmp >= 2200 && tmp < 2400)
			{
				s1 = "FFA500";
				s2 = "Master";
			}
			else if (tmp >= 2400 && tmp < 2700)
			{
				s1 = "FF0000";
				s2 = "International Master";
			}
			else if (tmp >= 2700 && tmp < 2900)
			{
				s1 = "FF0000";
				s2 = "Grand Master";
			}
			else if (tmp >= 2900 && tmp <= 3100)
			{
				s1 = "FF0000";
				s2 = "International Grand Master";
			}
			else
			{
				s1 = "FF0000";
				s2 = "Legendary Grand Master";
			}
			User.Color = s1;
			User.Status = s2;
			User.Rating = tmp;
		}
		private void ProcessStatus(string ID)
		{
			AC = Sub = WA = TLE = RE = CE = MLE = Skpd = 0;
			ReqUrl = "http://codeforces.com/api/user.status?handle=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			//Console.WriteLine("{0}",RetString.Length);
			int i,j;
			for (i = 0; i < RetString.Length - 25; i++)
			{
				s1 = "";
				for (j = i; j < i + 2; j++) s1 += RetString[j];
				if (s1 == "id")
				{
					Sub++;
					i = j - 1;
					continue;
				}
				for (; j < i + 6; j++) s1 += RetString[j];
				if (s1 == "t\":\"OK")
				{
					AC++;
					i = j - 1;
					continue;
				}
				for (; j < i + 7; j++) s1 += RetString[j];
				if (s1 == "SKIPPED")
				{
					Skpd++;
					i = j - 1;
					continue;
				}
				for (; j < i + 12; j++) s1 += RetString[j];
				if (s1 == "WRONG_ANSWER")
				{
					WA++;
					i = j - 1;
					continue;
				}
				for (; j < i + 13; j++) s1 += RetString[j];
				if (s1 == "RUNTIME_ERROR")
				{
					RE++;
					i = j - 1;
					continue;
				}
				for (; j < i + 17; j++) s1 += RetString[j];
				if (s1 == "COMPILATION_ERROR")
				{
					CE++;
					i = j - 1;
					continue;
				}
				for (; j < i + 19; j++) s1 += RetString[j];
				if (s1 == "TIME_LIMIT_EXCEEDED")
				{
					TLE++;
					i = j - 1;
					continue;
				}
				for (; j < i + 21; j++) s1 += RetString[j];
				if (s1 == "MEMORY_LIMIT_EXCEEDED")
				{
					MLE++;
					i = j - 1;
					continue;
				}
			}
			User.Sub = Sub;
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
			string FirstName, LastName, Institute, City, Country, ProPicPath, Contribution, MaxRank, s;
			FirstName = LastName = Institute = City = Country = Contribution = ProPicPath = MaxRank = "";
			int i,j,k;
			ReqUrl = "http://codeforces.com/api/user.info?handles=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			for (i = 0; i < RetString.Length; i++)
			{
				s = "";
				for (j = i; j < i + 4 && j < RetString.Length; j++) s += RetString[j];
				if (s == "city")
				{
					for (k = j + 3; k < RetString.Length && RetString[k] != '"'; k++)
					{
						City += RetString[k];
					}
					i = j - 1;
					continue;
				}
				for (; j < i + 7 && j < RetString.Length; j++) s += RetString[j];
				if (s == "country")
				{
					for (k = j + 3; k < RetString.Length && RetString[k] != '"'; k++)
					{
						Country += RetString[k];
					}
					i = j - 1;
					continue;
				}
				if (s == "maxRank")
				{
					for (k = j + 3; k < RetString.Length && RetString[k] != '"'; k++)
					{
						MaxRank += RetString[k];
					}
					i = j - 1;
					continue;
				}
				for (; j < i + 8 && j < RetString.Length; j++) s += RetString[j];
				if (s == "lastName")
				{
					for (k = j + 3; k < RetString.Length && RetString[k] != '"'; k++)
					{
						LastName += RetString[k];
					}
					i = j - 1;
					continue;
				}
				for (; j < i + 9 && j < RetString.Length; j++) s += RetString[j];
				if (s == "firstName")
				{
					for (k = j + 3; k < RetString.Length && RetString[k] != '"'; k++)
					{
						FirstName += RetString[k];
					}
					i = j - 1;
					continue;
				}
				for (; j < i + 10 && j < RetString.Length; j++) s += RetString[j];
				if (s == "titlePhoto")
				{
					for (k = j + 3; k < RetString.Length && RetString[k] != '"'; k++)
					{
						ProPicPath += RetString[k];
					}
					i = j - 1;
					continue;
				}
				for (; j < i + 12 && j < RetString.Length; j++) s += RetString[j];
				if (s == "organization")
				{
					for (k = j + 3; k < RetString.Length && RetString[k] != '"'; k++)
					{
						Institute += RetString[k];
					}
					i = j - 1;
					continue;
				}
				if (s == "contribution")
				{
					for (k = j + 2; k < RetString.Length && RetString[k] != ','; k++)
					{
						Contribution += RetString[k];
					}
					i = j - 1;
					continue;
				}
			}
			if (ProPicPath == "") ProPicPath = DefaultImagePath;
			User.Name = FirstName + " " + LastName;
			User.Institute = Institute;
			User.City = City;
			User.Country = Country;
			User.MaxRank = MaxRank;
			User.Contribution = Contribution;
			User.ProPicPath = ProPicPath;
		}
	}
}
