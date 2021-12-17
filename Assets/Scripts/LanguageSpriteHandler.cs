using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSpriteHandler : MonoBehaviour
{
    private static List<Data> items = new List<Data>();

    public Sprite spriteEnglish;
    public Sprite spritePolish;
    public bool isManager;

    static bool firstRun = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!isManager) {
            items.Add(new Data(gameObject, spriteEnglish, spritePolish));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (firstRun) {
            firstRun = false;
            if (PlayerPrefsHandler.IsLanguageEnglish()) {
                LanguageSpriteHandler.SetLanguageToEnglish();
            } else {
                LanguageSpriteHandler.SetLanguageToPolish();
            }
        }
    }

    public static void SetLanguageToEnglish() {
        foreach (Data data in items) {
            data.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = data.spriteEnglish;
        }
    }

    public static void SetLanguageToPolish() {
        foreach (Data data in items) {
            data.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = data.spritePolish;
        }
    }

    public class Data {
        public GameObject gameObject;
        public Sprite spriteEnglish;
        public Sprite spritePolish;

        public Data(GameObject gameObject, Sprite spriteEnglish, Sprite spritePolish) {
            this.gameObject = gameObject;
            this.spriteEnglish = spriteEnglish;
            this.spritePolish = spritePolish;
        }
    }
}
