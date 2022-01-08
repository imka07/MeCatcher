using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text text;
    void Start()
    {
        float lastscore = PlayerPrefs.GetFloat("score");
        float RecordScore = PlayerPrefs.GetFloat("RecordScore");
        if (lastscore > RecordScore)
        {
            RecordScore = lastscore;
            PlayerPrefs.SetFloat("RecordScore", RecordScore);
            text.text = RecordScore.ToString();
        }
        else
        {
            text.text = RecordScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
