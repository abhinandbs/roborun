using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public Text finalcoin;
    private float high;
 
    void Start()
    {
       
        high = PlayerPrefs.GetFloat("coinscore", 0);
      
        finalcoin.text = "" +high;
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
    public void SelectRobot()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("scene2");
    }
    public void HighSCore()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Highscore");
    }
    public void Gohome()
    {
        Score.scoreval = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("welcome");
    }
    public void exitgame()
    {

        Application.Quit();
    }
}
