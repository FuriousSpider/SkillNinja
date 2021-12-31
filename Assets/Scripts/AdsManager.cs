using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleMobileAds.Api;

public class AdsManager : MonoBehaviour
{
    public static AdsManager INSTANCE;
    private InterstitialAd interstitial;
    private OnAdFinished onAdFinishedCallback;

    string adUnitId = "ca-app-pub-9343619959181571/4663722755";
    bool isAdLoaded;

    void Awake() {
        if (INSTANCE == null) {
            INSTANCE = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => {});
        List<string> deviceIds = new List<string>();
        deviceIds.Add("9680131D0DE8F3455E4DA194E011CA51");
        
        RequestConfiguration requestConfiguration = new RequestConfiguration
            .Builder()
            .SetTestDeviceIds(deviceIds)
            .build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        this.CreateInterstitialAd();

        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        this.interstitial.OnAdOpening += HandleOnAdOpened;

        CreateAdRequestAndLoad();
    }

    private void CreateAdRequestAndLoad() {
        this.interstitial.LoadAd(new AdRequest.Builder().Build());
    }

    public void CreateInterstitialAd() {
        if (this.interstitial != null) {
            this.interstitial.Destroy();
        }

        this.interstitial = new InterstitialAd(adUnitId);
        isAdLoaded = false;
    }

    public void ShowInterstitialAd() {
        if (isAdLoaded) {
            this.interstitial.Show();
        } else {
            this.CreateAdRequestAndLoad();
            this.onAdFinishedCallback();
        }
        // this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void HandleOnAdLoaded(object sender, System.EventArgs args) {
        isAdLoaded = true;
        // this.interstitial.Show();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args) {
        isAdLoaded = false;
        // this.onAdFinishedCallback();
    }

    public void HandleOnAdOpened(object sender, System.EventArgs args) {
        this.onAdFinishedCallback();
    }

    public void SetOnAdFinishedListener(OnAdFinished callback) {
        this.onAdFinishedCallback = callback;
        isAdLoaded = false;
        this.CreateAdRequestAndLoad();
    }

    public delegate void OnAdFinished();
}
