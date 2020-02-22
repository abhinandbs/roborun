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
        float currentcoin = PlayerPrefs.GetFloat("coinscore", 0);
        currentcoin += Score.coinval;
        PlayerPrefs.SetFloat("coinscore", currentcoin);
        Score.scoreval = 0;
        Score.coinval = 0;
       
        Time.timeScale = 1;
        SceneManager.LoadScene("scene1");
    }
    

    public void Gohome()
    {
        float currentcoin = PlayerPrefs.GetFloat("coinscore", 0);
        currentcoin += Score.coinval;
        PlayerPrefs.SetFloat("coinscore", currentcoin);
        Score.scoreval = 0;
        Score.coinval = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("welcome");
    }
    public void showad()
    {


        GameObject Panel = GameObject.Find("GameOver");
        Panel.SetActive(false);
        enemycollider player = FindObjectOfType<enemycollider>();

      
        Debug.Log("resumeshowad");
        GameObject currentplayer = FindObjectOfType<Spawmplayer>().CurrentPlayer;

        if (player.isdestroy)
        {
            currentplayer.transform.position = currentplayer.transform.position - new Vector3(0f, -2f, -5f);
        }
        else
        {
            if(currentplayer.transform.position.x < 0)
            {
                Debug.Log(currentplayer.transform.position);
                currentplayer.transform.position = currentplayer.transform.position - new Vector3(-3f, -12f, -5f);
            }
            else if(currentplayer.transform.position.x ==0)
            {
                currentplayer.transform.position = currentplayer.transform.position - new Vector3(0f, -12f, -5f);
            }
            else
            {
                currentplayer.transform.position = currentplayer.transform.position - new Vector3(+3f, -12f, -5f);
            }
            
        }
        
        Time.timeScale = 1;

        player.isdestroy = false;
        if (!player.destroysound.isPlaying && !player.isdestroy)
        {

            player.destroysound.clip = player.game;
            player.destroysound.Play();
        }



    }
    

    public void exitgame()
    {

        Application.Quit();
    }
}
