using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{


    public static float scoreval = 0;
    public static float coinval = 0;
    private float highscore;
    private float high;
    public Text score;
    public Text coin;
  
    // Start is called before the first frame update
    void Start()
    {

        score.text = ""+0;
        coin.text = "" + 0;

        high = PlayerPrefs.GetFloat("highscore", 0);
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
        coin.text = "" + coinval;
        if (scoreval > highscore)
        {
            highscore = scoreval;
            PlayerPrefs.SetFloat("highscore", highscore);
        }
    }
}
