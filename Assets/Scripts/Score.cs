using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    void Start()
    {
        scoreAmount=0f;
        pointIncreasedPerSecond = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: "+ (int)scoreAmount;
        scoreAmount+= pointIncreasedPerSecond * Time.deltaTime;
    }
}
