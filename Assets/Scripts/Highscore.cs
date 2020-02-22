using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
     public Text finalscore;
     private float high;
      private float highscore;
    // Start is called before the first frame update
    void Start()
    {
        high = PlayerPrefs.GetFloat("highscore", highscore);

         finalscore.text = "" +high;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Gohome()
    {
        Score.scoreval = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("welcome");
    }
}
