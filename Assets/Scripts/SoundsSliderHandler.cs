using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsSliderHandler : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefsHandler.GetSoundsVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
