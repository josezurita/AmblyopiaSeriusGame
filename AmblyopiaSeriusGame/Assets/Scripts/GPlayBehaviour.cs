using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GPlayBehaviour : MonoBehaviour {

    public GameObject gPlayBtn;
    public GameObject archBtn;
    public GameObject leaderBtn;
    public GameObject exitBtn;
    public GameObject gPlaySettingsBtn;
    public Text authStatus;

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
            exitBtn.SetActive(false);
            gPlaySettingsBtn.SetActive(true);
            // Reset UI
            //signInButtonText.text = "Sign In";
            authStatus.text = "No conectado a Play Games";
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
            exitBtn.SetActive(true);
            gPlaySettingsBtn.SetActive(false);
            authStatus.text = "Conectado como " + Social.localUser.userName;

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
            //authStatus.text = "Signed in as: " + c;
            Debug.Log("Signed in as: " + Social.localUser.userName);
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");
            archBtn.SetActive(false);
            leaderBtn.SetActive(false);
            gPlayBtn.SetActive(true);
            exitBtn.SetActive(false);
            gPlaySettingsBtn.SetActive(true);
            // Reset UI
            //signInButtonText.text = "Sign In";
            authStatus.text = "No conectado a Play Games";
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

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }
}
