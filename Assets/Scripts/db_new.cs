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


	// Use this for initialization
	void Start ()
	{
		Debug.Log ("DB script starts");
		//string conn = "URI=file:" + Application.dataPath + "Plugins/Users.db"; 

		//Path to database.
		string conn = "URI=file:Users.db"; 
		//GetScores ();
		ShowScores ();

		// Calling mehthod to show the scores
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

			//prints on console
		}


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

		//deletes ID if called
	}

	private void ShowScores ()
	{
		GetScores ();

		//Calls getscores method Which has connection to database

		String Score = "Score";
		String Name = "Name";
		String Rank = "Rank";

		//declaring 

		for (int i = 0; i < 10 && i < Highscores.Count; i++) {  
			Debug.Log (i + "\n");	
			Name += "\n" + Highscores [i].Username; //from table
			Score += "\n" + Highscores [i].Score;
			Rank += "\n" + ((int)(i+1)).ToString ();
		}
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = Score;
		GameObject.Find ("NameText").GetComponent<Text> ().text = Name;
		GameObject.Find ("RankText").GetComponent<Text> ().text = Rank;

		//replaces the text fields in "score" with values from the database connected 

	}
}
	
