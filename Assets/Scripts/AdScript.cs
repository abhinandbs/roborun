using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdScript : MonoBehaviour
{
    private BannerView bannerView;

    // Use this for initialization
    void Start()
    {

#if UNITY_ANDROID
            string appId = "ca-app-pub-5089442852374733~9310927709";
       
#elif UNITY_IPHONE
            //string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        //string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.RequestBanner();
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        

           string adUnitId = "ca-app-pub-5089442852374733/5436289543";
        // string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
            //string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    private void showBannerAd()
    {
        // string adID = "ca-app-pub-5089442852374733/5436289543";

        string adID = "ca-app-pub-5089442852374733/5436289543";
        //***For Testing in the Device***
      /*  AdRequest request = new AdRequest.Builder()
       .AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
       .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // My test device.
       .Build();
       */

        //***For Production When Submit App***
        AdRequest request = new AdRequest.Builder().Build();

        BannerView bannerAd = new BannerView(adID, AdSize.SmartBanner, AdPosition.Bottom);
        bannerAd.LoadAd(request);
    }

    // Update is called once per frame
    void Update()
    {
        
       
         
    }

   /* public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            //Stop Sound
            //

            Debug.Log("SHOW AD XXX");
        }

    }

    InterstitialAd interstitial;
    private void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-3940256099942544/1033173712";


        string adUnitId = adID;


        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitId);

       

        //***Production***
        AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        interstitial.OnAdClosed += Interstitial_OnAdClosed;

        // Load the interstitial with the request.
        interstitial.LoadAd(request);

        Debug.Log("AD LOADED XXX");

    }

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        //Resume Play Sound

    }*/
}
