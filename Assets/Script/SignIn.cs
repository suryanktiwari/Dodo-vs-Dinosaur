using System.Collections;
using UnityEngine;
using GooglePlayGames;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class SignIn  {

	// Use this for initialization
	public bool val=false;

	public void login()
	{	
		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate ((bool success) => {

				if (success) {
					val = true;
					Debug.Log (Social.localUser.userName);
				} else
					Debug.Log ("LOL");
			});
		}	



	}
}
          