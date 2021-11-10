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
        }
    }

    public void GoToMainMenuScreen() {
        GoToScreen(Values.MANAGER_SCREEN_MAIN_MENU);
    }

    public void GoToGameScreen() {
        GoToScreen(Values.MANAGER_SCREEN_GAME);
    }

    public void GoToHelpScreen() {
        GoToScreen(Values.MANAGER_SCREEN_HELP);
    }
}
