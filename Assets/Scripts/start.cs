using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public Text finalscore;
    private float high;
    private float highscore;
    void Start()
    {
       
        high = PlayerPrefs.GetFloat("highscore", highscore);
      
        finalscore.text = "" +high;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Newgame()
    {
        Score.scoreval = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("scene1");
    }

    public void Gohome()
    {
        Score.scoreval = 0;

        SceneManager.LoadScene("welcome");
    }
    public void exitgame()
    {

        Application.Quit();
    }
}
