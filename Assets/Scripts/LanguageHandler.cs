using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageHandler : MonoBehaviour
{

    private static List<Data> items = new List<Data>();

    public string textEnglish;
    public string textPolish;
    public bool isManager;

    static bool firstRun = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!isManager) {
            items.Add(new Data(gameObject, textEnglish, textPolish));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstRun) {
            firstRun = false;
            if (PlayerPrefsHandler.IsLanguageEnglish()) {
                LanguageHandler.SetLanguageToEnglish();
            } else {
                LanguageHandler.SetLanguageToPolish();
            }
        }
    }

    public static void SetLanguageToEnglish() {
        foreach (Data data in items) {
            data.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = data.textEnglish;
        }
    }

    public static void SetLanguageToPolish() {
        foreach (Data data in items) {
            data.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = data.textPolish;
        }
    }

    public class Data {
        public GameObject gameObject;
        public string textEnglish;
        public string textPolish;

        public Data(GameObject gameObject, string textEnglish, string textPolish) {
            this.gameObject = gameObject;
            this.textEnglish = textEnglish;
            this.textPolish = textPolish;
        }
    }
}
