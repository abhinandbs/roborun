using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject Gameovertext;
    public GameObject Resume;
    public GameObject Panel;
    public GameObject PauseButton;
    
    // Start is called before the first frame update
    void Start()
    {
        PauseButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        //Score.scoreval = 0;
       
        PauseButton.gameObject.SetActive(false);
        Time.timeScale = 0;
        Gameovertext.gameObject.SetActive(false);
        Panel.gameObject.SetActive(true);
        Resume.gameObject.SetActive(true);
        //SceneManager.LoadScene("scene1");
       
    }
    public void ResumeGame()
    {


        PauseButton.gameObject.SetActive(true);
        Gameovertext.gameObject.SetActive(true);
        //Score.scoreval = 0;
        Panel.gameObject.SetActive(false);
        Time.timeScale = 1;
        Resume.gameObject.SetActive(false);
        //SceneManager.LoadScene("scene1");
    }
}
