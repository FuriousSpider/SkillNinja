using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderHandler : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefsHandler.GetMusicVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
