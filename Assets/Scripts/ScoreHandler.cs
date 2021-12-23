using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static long score;
    [TextArea]
    public string scoreText;
    public bool hideWhenScoreZero;

    TMPro.TextMeshProUGUI text;
    string textValue;

    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {   
        if (score == 0 && hideWhenScoreZero) {
            Hide();
        } else {
            Show();
            textValue = text.text.Split(":")[0] + ": ";
            text.text = textValue + (score / 1000);
        }
    }

    private void Hide() {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    private void Show() {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
