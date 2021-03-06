using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public AudioSource newHigh;

    public Text highScore;
    public bool soundPlayed;
    void Start()
    {
        scoreAmount=0f;
        
        pointIncreasedPerSecond = 1f;
        highScore.text ="HighScore: "+ PlayerPrefs.GetInt("HighScore",0).ToString(); //set default value to 0
        soundPlayed=false;

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: "+ (int)scoreAmount;
        scoreAmount+= pointIncreasedPerSecond * Time.deltaTime;

        if ( scoreAmount > PlayerPrefs.GetInt("HighScore",0))
        {
           if (!soundPlayed) {
        newHigh.Play();
        soundPlayed = true;
  }
            PlayerPrefs.SetInt("HighScore", (int)scoreAmount);
            highScore.text = "HighScore: "+ (int)scoreAmount;
        }
    }

    public  void Reset() {
        PlayerPrefs.DeleteKey("HighScore");
    }
}
