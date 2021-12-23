using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBestHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string textValue = textField.text.Split(":")[0] + ": ";
        int score = PlayerPrefsHandler.GetBestScore();
        textField.text = textValue + score;
    }
}
