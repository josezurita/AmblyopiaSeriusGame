using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.EventSystems;

public class GPlayBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject startButton = GameObject.Find("startButton");
        EventSystem.current.firstSelectedGameObject = startButton;


        //  ADD THIS CODE BETWEEN THESE COMMENTS

        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        // END THE CODE TO PASTE INTO START

        PlayGamesPlatform.Instance.Authenticate(GPlaySignInCallback, true);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GPlaySignIn()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(GPlaySignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            //signInButtonText.text = "Sign In";
            //authStatus.text = "";
        }
    }

    public void GPlaySignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("(Lollygagger) Signed in!");

            // Change sign-in button text
            //signInButtonText.text = "Sign out";

            // Show the user's name
            //authStatus.text = "Signed in as: " + Social.localUser.userName;
            Debug.Log("Signed in as: " + Social.localUser.userName);
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");

            // Show failure message
            //signInButtonText.text = "Sign in";
            //authStatus.text = "Sign-in failed";
            Debug.Log("Sign-in failed");
        }
    }
}
