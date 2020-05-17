using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard  {
	public void Post(int score)
	{	if (Social.localUser.authenticated) {
			Social.ReportScore (
				score
			,
				GPGSIds.leaderboard_high_score,
				(bool success) => {

					if (success) {
						Debug.Log ("SUCCESS");

					} else {
						Debug.Log ("Failure");

					}
				});
		}
	}
	public void show()
	{	
		Social.ShowLeaderboardUI ();	
	}
}
