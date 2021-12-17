using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MusicButtonHandler : MonoBehaviour, IPointerClickHandler
{
    public Sprite musicImg;
    public Sprite noMusicImg;

    static List<MusicButtonHandler> buttonsList = new List<MusicButtonHandler>();

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        buttonsList.Add(this);

        //TODO: add music to PlayerPrefs and change music to something different
        image = gameObject.GetComponent<Image>();

        if (PlayerPrefsHandler.IsMusicPlaying()) {
            image.sprite = musicImg;
        } else {
            image.sprite = noMusicImg;
        }
    }

    public void onButtonClick(bool isMusicOn) {
        if (isMusicOn) {
            foreach (MusicButtonHandler handler in buttonsList) {
                handler.image.sprite = musicImg;
            }
        } else {
            foreach (MusicButtonHandler handler in buttonsList) {
                handler.image.sprite = noMusicImg;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        MusicHandler.switchMusic();
        onButtonClick(MusicHandler.isMusicOn);
        if (MusicHandler.isMusicOn) {
            PlayerPrefsHandler.SetMusic(PlayerPrefsHandler.PREF_MUSIC_ON);
        } else {
            PlayerPrefsHandler.SetMusic(PlayerPrefsHandler.PREF_MUSIC_OFF);
        }
    }
}
