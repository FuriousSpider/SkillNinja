using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static long score;
    [TextArea]
    public string scoreText;

    TMPro.TextMeshProUGUI text;
    string textValue;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {   
        if (score == 0) {
            text.enabled = false;
        } else {
            text.enabled = true;
            textValue = text.text.Split(":")[0] + ": ";
            text.text = textValue + score;
        }
    }
}
