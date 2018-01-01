using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text score;
    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();
        score.text = getScoreString();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = getScoreString();
    }

    private String getScoreString()
    {
        return "Score: " + Coin.score;
    }
}
