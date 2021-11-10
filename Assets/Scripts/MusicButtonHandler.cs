using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicButtonHandler : MonoBehaviour, IPointerClickHandler
{
    public Sprite musicImg;
    public Sprite noMusicImg;
    
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = musicImg;
    }

    public void onButtonClick(bool isMusicOn) {
        if (isMusicOn) {
            image.sprite = musicImg;
        } else {
            image.sprite = noMusicImg;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MusicHandler.switchMusic();
        onButtonClick(MusicHandler.isMusicOn);
    }
}
