using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

public class enemycollider : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject Panel;

    private Pause ResumeButton;
    private RewardBasedVideoAd rewardedAd;
    private InterstitialAd interstitial;
    public AudioSource destroysound;
    public AudioClip destroy;
    public AudioClip game;
    private bool isdestroy = false;
    void Start()
    {
        Panel = GameObject.Find("GameOver");
        Panel.SetActive(false);
        ResumeButton = FindObjectOfType<Pause>();
        RequestInterstitialAds();
       // RequestRewardedAd();

        rewardedAd = RewardBasedVideoAd.Instance;

        // Called when the user should be rewarded for watching a video.
        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardedAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

      //  destroysound.clip = game;
       // destroysound.Play();
    }

    // Update is called once per frame
    void Update()
    {
       if (!destroysound.isPlaying && !isdestroy) {
            
        destroysound.clip = game;
        destroysound.Play();
    }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            destroysound.Stop();
            //Score.scoreval += 10;
            // ShowRewardedAd();
            Debug.Log("enemy collide");
            destroysound.clip = destroy;
            destroysound.Play();
            isdestroy = true;

            Debug.Log("Played");

            // Debug.Log(Score.scoreval);
            Time.timeScale = 0;
            other.gameObject.SetActive(false);

            Destroy(other.gameObject);
            Panel.SetActive(true);
            ResumeButton.gameObject.SetActive(false);

            showInterstitialAd();

           

           



        }

    }
    public void showInterstitialAd()
    {
        Debug.Log("called");
        //Show Ad
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }

    }

   
    private void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-5089442852374733/3601653066";


        string adUnitId = adID;


        // Initialize an InterstitialAd.
        // interstitial = new InterstitialAd(adUnitId);
        this.interstitial = new InterstitialAd(adUnitId);


        //***Production***
        AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        // interstitial.OnAdClosed += Interstitial_OnAdClosed;

        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

        Debug.Log("AD LOADED XXX");

    }

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        //Resume Play Sound

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
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

}
