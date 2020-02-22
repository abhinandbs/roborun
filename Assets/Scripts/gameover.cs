using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update


    public Text finalscore;
    public Text finalcoin;
    private RewardBasedVideoAd rewardedAd;



    void Start()
    {
        rewardedAd = RewardBasedVideoAd.Instance;
        RequestRewardedAd();
        // Called when the user should be rewarded for watching a video.
        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardedAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
    }

    // Update is called once per frame
    void Update()
    {
        finalscore.text = ""+Score.scoreval;
        finalcoin.text = "" + Score.coinval;

        
    }

    public void Newgame()
    {
        float currentcoin = PlayerPrefs.GetFloat("coinscore", 0);
        currentcoin += Score.coinval;
        PlayerPrefs.SetFloat("coinscore", currentcoin);
        Score.scoreval = 0;
        Score.coinval = 0;
       
     
        SceneManager.LoadScene("scene1");
        Time.timeScale = 1;
    }
    

    public void Gohome()
    {
        float currentcoin = PlayerPrefs.GetFloat("coinscore", 0);
        currentcoin += Score.coinval;
        PlayerPrefs.SetFloat("coinscore", currentcoin);
        Score.scoreval = 0;
        Score.coinval = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("welcome");
    }


    public void resumegame()
    {
        GameObject Panel = GameObject.Find("GameOver");
        Panel.SetActive(false);
        enemycollider player = FindObjectOfType<enemycollider>();


        Debug.Log("resumeshowad");
        GameObject currentplayer = FindObjectOfType<Spawmplayer>().CurrentPlayer;

        if (player.isdestroy)
        {
            currentplayer.transform.position = currentplayer.transform.position - new Vector3(0f, -2f, -5f);
        }
        else
        {
            if (currentplayer.transform.position.x < 0)
            {
                Debug.Log(currentplayer.transform.position);
                currentplayer.transform.position = currentplayer.transform.position - new Vector3(-3f, -12f, -5f);
            }
            else if (currentplayer.transform.position.x == 0)
            {
                currentplayer.transform.position = currentplayer.transform.position - new Vector3(0f, -12f, -5f);
            }
            else
            {
                currentplayer.transform.position = currentplayer.transform.position - new Vector3(+3f, -12f, -5f);
            }

        }

        Time.timeScale = 1;

        player.isdestroy = false;
        if (!player.destroysound.isPlaying && !player.isdestroy)
        {

            player.destroysound.clip = player.game;
            player.destroysound.Play();
        }

    }
    public void showad()
    {
      ShowRewardedAd();
        

       


    }
    

    public void exitgame()
    {

        Application.Quit();
    }
    public void RequestRewardedAd()
    {
        string adID = "ca-app-pub-3940256099942544/5224354917";


        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request, adID);
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        RequestRewardedAd();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for "
                        + amount.ToString() + " " + type);
        resumegame();
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }
   
}
