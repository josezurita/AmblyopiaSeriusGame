using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.EventSystems;

public class GPlayBehaviour : MonoBehaviour {

    public GameObject gPlayBtn;
    public GameObject archBtn;
    public GameObject leaderBtn;

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
            archBtn.SetActive(false);
            leaderBtn.SetActive(false);
            gPlayBtn.SetActive(true);
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
            archBtn.SetActive(true);
            leaderBtn.SetActive(true);
            gPlayBtn.SetActive(false);
            if (Social.localUser.authenticated)
            {
                // Unlock the "welcome" achievement, it is OK to
                // unlock multiple times, only the first time matters.
                PlayGamesPlatform.Instance.ReportProgress(
                    GPGSIds.achievement_welcome_to_amblio,
                    100.0f, (bool result) =>
                    {
                        Debug.Log("(Lollygagger) Welcome Unlock: " + result);
                    });
            }

            // Increment the "sharpshooter" achievement
            //PlayGamesPlatform.Instance.IncrementAchievement(
            //       GPGSIds.achievement_sharpshooter,
            //       1,
            //       (bool success) => {
            //           Debug.Log("(Lollygagger) Sharpshooter Increment: " +
            //                 success);
            //       });
            // Change sign-in button text
            //signInButtonText.text = "Sign out";
            // Show the user's name
            //authStatus.text = "Signed in as: " + Social.localUser.userName;
            Debug.Log("Signed in as: " + Social.localUser.userName);
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");
            archBtn.SetActive(false);
            leaderBtn.SetActive(false);
            gPlayBtn.SetActive(true);
            // Show failure message
            //signInButtonText.text = "Sign in";
            //authStatus.text = "Sign-in failed";
            Debug.Log("Sign-in failed");
        }
    }

    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        }
        else
        {
            Debug.Log("Cannot show Achievements, not logged in");
        }
    }
}
