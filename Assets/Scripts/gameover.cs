using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update


    public Text finalscore;
    public Text finalcoin;
    
   
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalscore.text = ""+Score.scoreval;
        finalcoin.text = "" + Score.coinval;

        
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
        Time.timeScale = 1;
        SceneManager.LoadScene("welcome");
    }
    public void exitgame()
    {

        Application.Quit();
    }
}
