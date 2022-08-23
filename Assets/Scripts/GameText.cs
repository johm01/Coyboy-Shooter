using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameText : MonoBehaviour
{
    public static GameText instance;

    public Text killText;

    int score = 0;
    int highscore = 0;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        killText.text = "Score: "+score;
    }

    // Update is called once per frame
    void Update()
    { 

    }

    public void AddScore(int scoreadd)
    {
        score = score + scoreadd;
        killText.text = "Score: "+score;
        if(score >= highscore)
        {
            score = highscore;
        }
    }
}
