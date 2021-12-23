using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    public float speed;

    public GameObject mainCamera;
    public GameObject mainMenuPoint;
    public GameObject gamePoint;
    public GameObject helpPoint;
    public GameObject helpStep2Point;
    public GameObject helpStep3Point;
    public GameObject helpStep4Point;
    public GameObject helpStep5Point;
    public GameObject languageSelectorPoint;
    public GameObject settingsPoint;

    Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = mainMenuPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, destination, Time.deltaTime * speed);
    }

    public void GoToScreen(int screen) {
        switch(screen) {
            case Values.MANAGER_SCREEN_MAIN_MENU:
                destination = mainMenuPoint.transform.position;
                break;
            case Values.MANAGER_SCREEN_GAME:
                destination = gamePoint.transform.position;
                break;
            case Values.MANAGER_SCREEN_HELP:
                destination = helpPoint.transform.position;
                break;
            case Values.MANAGER_SCREEN_LANGUAGE:
                destination = languageSelectorPoint.transform.position;
                break;
            case Values.MANAGER_SCREEN_SETTINGS:
                destination = settingsPoint.transform.position;
                break;
            case Values.MANAGER_SCREEN_HELP_STEP_2:
                destination = helpStep2Point.transform.position;
                break;
            case Values.MANAGER_SCREEN_HELP_STEP_3:
                destination = helpStep3Point.transform.position;
                break;
            case Values.MANAGER_SCREEN_HELP_STEP_4:
                destination = helpStep4Point.transform.position;
                break;
            case Values.MANAGER_SCREEN_HELP_STEP_5:
                destination = helpStep5Point.transform.position;
                break;
        }
    }

    public void GoToMainMenuScreen() {
        GoToScreen(Values.MANAGER_SCREEN_MAIN_MENU);
    }

    public void GoToMainMenuScreenInstant() {
        destination = mainMenuPoint.transform.position;
        mainCamera.transform.position = mainMenuPoint.transform.position;
    }

    public void GoToGameScreen() {
        GoToScreen(Values.MANAGER_SCREEN_GAME);
    }

    public void GoToHelpScreen() {
        GoToScreen(Values.MANAGER_SCREEN_HELP);
    }

    public void GoToLanguageSelectorScreen() {
        GoToScreen(Values.MANAGER_SCREEN_LANGUAGE);
    }

    public void GoToSettingsScreen() {
        GoToScreen(Values.MANAGER_SCREEN_SETTINGS);
    }

    public void GoToHelpStep2Screen() {
        GoToScreen(Values.MANAGER_SCREEN_HELP_STEP_2);
    }

    public void GoToHelpStep3Screen() {
        GoToScreen(Values.MANAGER_SCREEN_HELP_STEP_3);
    }

    public void GoToHelpStep4Screen() {
        GoToScreen(Values.MANAGER_SCREEN_HELP_STEP_4);
    }

    public void GoToHelpStep5Screen() {
        GoToScreen(Values.MANAGER_SCREEN_HELP_STEP_5);
    }
}
