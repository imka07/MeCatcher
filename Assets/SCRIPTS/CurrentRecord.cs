using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentRecord : MonoBehaviour
{
    public Text text;
    public Text text2;
    void Start()
    {
         float lastscore = PlayerPrefs.GetFloat("score");
        float RecordScore = PlayerPrefs.GetFloat("RecordScore");
        text.text = lastscore.ToString();
        if (lastscore > RecordScore)
        {
            RecordScore = lastscore;
            PlayerPrefs.SetFloat("RecordScore", RecordScore);
            text2.text = RecordScore.ToString();
        }
        else
        {
            text2.text = RecordScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
