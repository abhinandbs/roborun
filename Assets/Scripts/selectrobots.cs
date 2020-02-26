using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectrobots : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform camerapos;
    private float xpos;
    private int selected=0;
    public Text selectedtext;
    private int currentselected;
    public Text finalcoin;
    private float high;
    public GameObject alertbox;
    public GameObject confirmbox;
  


    void Start()
    {
        Time.timeScale = 1;
        camerapos.transform.position = new Vector3(0f, 119f, -905f);
       
        xpos = 0f;
      // PlayerPrefs.DeleteAll();
        // PlayerPrefs.SetFloat("coinscore", 5000);

        alertbox.SetActive(false);
        confirmbox.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        high = PlayerPrefs.GetFloat("coinscore", 0);

        finalcoin.text = "" + high;

        //player0 default
        int player1 = PlayerPrefs.GetInt("player1", 0);
        int player2 = PlayerPrefs.GetInt("player2", 0);
        int player3 =  PlayerPrefs.GetInt("player3", 0);
        int player4 = PlayerPrefs.GetInt("player4", 0);

        if (selected == 0)
        {
            changeselect();
        }
        else if(selected == 1)
        {
            if (player1 == 1) {

                changeselect();
            }
            else
            {
                selectedtext.text = "500";
                selectedtext.color = Color.yellow;
            }
        }else if (selected == 2)
        {
            if (player2 == 1)
            {

                changeselect();
            }
            else
            {
                selectedtext.text = "1000";
                selectedtext.color = Color.yellow;
            }
        }
        else if (selected == 3)
        {
            if (player3 == 1)
            {

                changeselect();
            }
            else
            {
                selectedtext.text = "2500";
                selectedtext.color = Color.yellow;
            }
        }
        else if (selected == 4)
        {
            if (player4 == 1)
            {

                changeselect();
            }
            else
            {
                selectedtext.text = "5000";
                selectedtext.color = Color.yellow;
            }
        }
        






    }

    public void changeselect()
    {
        currentselected = PlayerPrefs.GetInt("player", 0);




        if (selected == currentselected)
        {

            Color newColor = new Color(0f, 250f, 228f, 255f);
            selectedtext.text = "SELECTED";
            selectedtext.color = newColor;
        }
        else
        {
            selectedtext.text = "SELECT";
            selectedtext.color = Color.white;
        }
    }

    public void Next()
    {
        if( xpos <800f)
        {
            xpos += 200f;
            camerapos.transform.position = new Vector3(xpos, 119f, -905f);
           
            changeval(selected,"next");
            
        }
      
    }
    public void Previous()
    {
        if (xpos > 0f)
        {
            xpos -= 200f;
            camerapos.transform.position = new Vector3(xpos, 119f, -905f);
            changeval(selected, "previous");
          

        }
    }
    public void Selected()
    {

        int player1 = PlayerPrefs.GetInt("player1", 0);
        int player2 = PlayerPrefs.GetInt("player2", 0);
        int player3 = PlayerPrefs.GetInt("player3", 0);
        int player4 = PlayerPrefs.GetInt("player4", 0);

        float totalcoin = PlayerPrefs.GetFloat("coinscore", 0);


        if (selected == 0)
        {
            PlayerPrefs.SetInt("player", selected);
        }
        else if (selected == 1)
        {

            if (player1 == 0)
            {
                if (totalcoin >= 500)
                {
                    confirmbox.SetActive(true);
                    // float newcoin = totalcoin - 500;

                    // PlayerPrefs.SetInt("player1", 1);
                    // PlayerPrefs.SetInt("player", selected);
                    // PlayerPrefs.SetFloat("coinscore", newcoin);
                }
                else
                {
                    alertbox.SetActive(true);


                }
            }
            else if (player1 == 1)
            {
                PlayerPrefs.SetInt("player", selected);

            }

        }
        else if (selected == 2)
        {
            if (player2 == 0)
            {
                if (totalcoin >= 1000)
                {
                    confirmbox.SetActive(true);
                    //float newcoin = totalcoin - 1000;

                    // PlayerPrefs.SetInt("player2", 1);
                    // PlayerPrefs.SetInt("player", selected);
                    //PlayerPrefs.SetFloat("coinscore", newcoin);
                }
                else
                {
                    alertbox.SetActive(true);
                }
            }
            else if (player2 == 1)
            {
                PlayerPrefs.SetInt("player", selected);

            }
        }
        else if (selected == 3)
        {
            if (player3 == 0)
            {
                if (totalcoin >= 2500)
                {
                    confirmbox.SetActive(true);
                    // float newcoin = totalcoin - 2500;

                    // PlayerPrefs.SetInt("player3", 1);
                    // PlayerPrefs.SetInt("player", selected);
                    // PlayerPrefs.SetFloat("coinscore", newcoin);
                }
                else
                {
                    alertbox.SetActive(true);
                }
            }
            else if (player3 == 1)
            {
                PlayerPrefs.SetInt("player", selected);

            }
        }
        else if (selected == 4)
        {
            if (player4 == 0)
            {
                if (totalcoin >= 5000)
                {

                    confirmbox.SetActive(true);
                    //float newcoin = totalcoin - 5000;

                    //PlayerPrefs.SetInt("player4", 1);
                   // PlayerPrefs.SetInt("player", selected);
                    //PlayerPrefs.SetFloat("coinscore", newcoin);
                }
                else
                {
                    alertbox.SetActive(true);
                }
            }
            else if (player4 == 1)
            {
                PlayerPrefs.SetInt("player", selected);

            }
        }

        //SceneManager.LoadScene("welcome");
    }
    public void Back()
    {
        //PlayerPrefs.SetFloat("player", selected);

        SceneManager.LoadScene("welcome");
    }

    public void Okay()
    {
        //PlayerPrefs.SetFloat("player", selected);
        alertbox.SetActive(false);
        
    }
    public void Confirm()
    {
        float totalcoin = PlayerPrefs.GetFloat("coinscore", 0);
        if (selected == 1)
        {
           float newcoin = totalcoin - 500;

            PlayerPrefs.SetInt("player1", 1);
            PlayerPrefs.SetInt("player", selected);
            PlayerPrefs.SetFloat("coinscore", newcoin);
        }else if(selected == 2)
        {
            float newcoin = totalcoin - 1000;

             PlayerPrefs.SetInt("player2", 1);
             PlayerPrefs.SetInt("player", selected);
            PlayerPrefs.SetFloat("coinscore", newcoin);
        }
        else if(selected == 3)
        {
             float newcoin = totalcoin - 2500;

             PlayerPrefs.SetInt("player3", 1);
             PlayerPrefs.SetInt("player", selected);
             PlayerPrefs.SetFloat("coinscore", newcoin);
        }
        else if(selected == 4)
        {
            float newcoin = totalcoin - 5000;

            PlayerPrefs.SetInt("player4", 1);
             PlayerPrefs.SetInt("player", selected);
            PlayerPrefs.SetFloat("coinscore", newcoin);
        }
        confirmbox.SetActive(false);
    }
    public void Confirmno()
    {
        confirmbox.SetActive(false);
    }

    public void changeval(int select,string current)
    {
        if (current.Equals("next"))
        {
            selected = select+1;
            Debug.Log(selected);
        }
        else
        {
            selected = select-1;
            Debug.Log(selected);
        }
       

    }
}
