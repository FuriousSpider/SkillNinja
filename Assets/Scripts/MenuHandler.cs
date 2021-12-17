using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public static MenuHandler INSTANCE;

    public Button startButton;
    public Image loadingCircle;
    public Text startButtonText;

    void Awake() {
        if (INSTANCE == null) {
            INSTANCE = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    public void Disable() {
        startButton.interactable = false;
        startButtonText.gameObject.SetActive(false);
        loadingCircle.gameObject.SetActive(true);
    }

    public void Enable() {
        startButton.interactable = true;
        startButtonText.gameObject.SetActive(true);
        loadingCircle.gameObject.SetActive(false);
    }
}
