using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
using Highscore;

public class db_new : MonoBehaviour
{
	private string conn;
	private List<HighScore> Highscores = new List<HighScore> ();
	public GameObject scorePrefab;
	public Transform scoreParent;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("DB script starts");
		//string conn = "URI=file:" + Application.dataPath + "Plugins/Users.db"; //Path to database.
		string conn = "URI=file:Users.db"; 
		//GetScores ();
		ShowScores ();
	}

	void Update ()
	{ 
	}

	private void InsertScore (string name, int NewScore)
	{
		string conn = "URI=file:Users.db"; 
		IDbConnection dbconn;
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open (); 

		//Open connection to the database.

		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = String.Format (
			                  "INSERT INTO UserInfo (Id,Username,Score) VALUES (\"{1}\",\"{2}\")", name, NewScore); 
		dbcmd.CommandText = sqlQuery;
		dbcmd.ExecuteScalar ();
		dbconn.Close ();

		//shows data on console

	}




	public void GetScores ()
	{
		Highscores.Clear (); 
		string conn = "URI=file:Users.db"; 
		IDbConnection dbconn;
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open (); 

		//Open connection to the database.

		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = "SELECT * FROM UserInfo ORDER BY Score DESC";
		//Id,Username,Score 
		dbcmd.CommandText = sqlQuery;

		IDataReader reader = dbcmd.ExecuteReader (); 

		//executes commands to reader

		while (reader.Read ()) {
			int Id = reader.GetInt32 (0);
			string Username = reader.GetString (1);
			int Score = reader.GetInt32 (2);

			Highscores.Add (new HighScore (Id, Username, Score));


			Debug.Log ("Id= " + Id + "  name =" + Username + " Score= " + Score);
		}

		//shows data on console
		reader.Close ();
		reader = null;
		dbcmd.Dispose ();
		dbcmd = null;
		dbconn.Close ();
		dbconn = null;

		//closing the reader

	}

	private void DeleteScore (int Id)
	{
		string conn = "URI=file:Users.db"; 
		IDbConnection dbconn;
		dbconn = (IDbConnection)new SqliteConnection (conn);
		dbconn.Open (); 

		//Open connection to the database.

		IDbCommand dbcmd = dbconn.CreateCommand ();
		string sqlQuery = String.Format 
			("DELETE FROM UserInfo WHERE Id = \"{0}\"", Id); 
		dbcmd.CommandText = sqlQuery;
		dbcmd.ExecuteScalar ();
		dbconn.Close ();

		//deletes ID 
	}

	private void ShowScores ()
	{
		Debug.Log ("Printing Highscores");
		GetScores ();

		String Score = "Score";
		String Name = "Name";
		String Rank = "Rank";

		for (int i = 0; i < 10 && i < Highscores.Count; i++) {
			Debug.Log (i + "\n");	
			Name += "\n" + Highscores [i].Username;
			Score += "\n" + Highscores [i].Score;
			Rank += "\n" + ((int)(i+1)).ToString ();
		}
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = Score;
		GameObject.Find ("NameText").GetComponent<Text> ().text = Name;
		GameObject.Find ("RankText").GetComponent<Text> ().text = Rank;

		/*
		for (int i = 0; i <Highscores.Count; i++) {
			GameObject tmpObjec = Instantiate(scorePrefab);
			tmpObjec.transform.SetParent(scoreParent, false); 
			HighScore tmpScore = Highscores [i];
			tmpObjec.GetComponent<HighScorePrefab> ().SetScore (
				tmpObjec.name, tmpScore.Score.ToString(), "#" + (i + 1).ToString ()); 
*/

		//name.GetComponent<Text> ().text += "\n#" + (i + 1);
		//score.GetComponent<Text> ().text += "\n" + tmpScore.Username;
		//rank.GetComponent<Text> ().text += "\n" + tmpScore.Score;

		//tmpScore.GetComponent<RankText> ().text += "\n#" + (i + 1);
		//tmpScore.GetComponent<NameText> ().text += "\n" + tmpScore.Username;
		//tmpScore.GetComponent<ScoreText> ().text += "\n" + tmpScore.Score;
		//coreParent = GameObject.Find ("Scores").transform;


		//tmpObjec.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1); 
		//showing rank to the player
		//tmpObjec.transform.SetParent(scoreParent); 

	}
}
	
