using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{


    public static float scoreval = 0;
    private float highscore;
    private float high;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        high = PlayerPrefs.GetFloat("highscore", highscore);
        if (high == 0)
        {
            highscore = 0;
        }
        else
        {
            highscore = high;
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreval;
        if (scoreval > highscore)
        {
            highscore = scoreval;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
    }
}
