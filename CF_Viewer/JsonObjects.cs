/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 2/17/2017
 * Time: 12:34 AM
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
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace CF_Viewer
{
	/// <summary>
	/// Description of JsonUserInfo.
	/// </summary>
	public class JsonUserInfoResult
	{
	    public string lastName { get; set; }
	    public string country { get; set; }
	    public int lastOnlineTimeSeconds { get; set; }
	    public string city { get; set; }
	    public int rating { get; set; }
	    public int friendOfCount { get; set; }
	    public string titlePhoto { get; set; }
	    public string handle { get; set; }
	    public string avatar { get; set; }
	    public string firstName { get; set; }
	    public string contribution { get; set; }
	    public string organization { get; set; }
	    public string rank { get; set; }
	    public int maxRating { get; set; }
	    public int registrationTimeSeconds { get; set; }
	    public string maxRank { get; set; }
	}
	public class JsonUserInfo
	{
	    public string status { get; set; }
	    public List<JsonUserInfoResult> result { get; set; }
	}
	public class JsonUserStatusProblem
	{
	    public int contestId { get; set; }
	    public string index { get; set; }
	    public string name { get; set; }
	    public string type { get; set; }
	    public double points { get; set; }
	    public List<string> tags { get; set; }
	}
	public class JsonUserStatusMember
	{
	    public string handle { get; set; }
	}
	public class JsonUserStatusAuthor
	{
	    public int contestId { get; set; }
	    public List<JsonUserStatusMember> members { get; set; }
	    public string participantType { get; set; }
	    public bool ghost { get; set; }
	    public int room { get; set; }
	    public int startTimeSeconds { get; set; }
	}
	public class JsonUserStatusResult
	{
	    public int id { get; set; }
	    public int contestId { get; set; }
	    public int creationTimeSeconds { get; set; }
	    public object relativeTimeSeconds { get; set; }
	    public JsonUserStatusProblem problem { get; set; }
	    public JsonUserStatusAuthor author { get; set; }
	    public string programmingLanguage { get; set; }
	    public string verdict { get; set; }
	    public string testset { get; set; }
	    public int passedTestCount { get; set; }
	    public int timeConsumedMillis { get; set; }
	    public int memoryConsumedBytes { get; set; }
	}
	public class JsonUserStatus
	{
	    public string status { get; set; }
	    public List<JsonUserStatusResult> result { get; set; }
	}
	public class JsonUserRatingsResult
	{
	    public int contestId { get; set; }
	    public string contestName { get; set; }
	    public string handle { get; set; }
	    public int rank { get; set; }
	    public int ratingUpdateTimeSeconds { get; set; }
	    public int oldRating { get; set; }
	    public int newRating { get; set; }
	}
	public class JsonUserRatings
	{
	    public string status { get; set; }
	    public List<JsonUserRatingsResult> result { get; set; }
	}
}
