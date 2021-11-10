using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static long score;
    [TextArea]
    public string scoreText;

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (score == 0) {
            text.text = "";
        } else {
            text.text = scoreText + score;
        }
    }
}
