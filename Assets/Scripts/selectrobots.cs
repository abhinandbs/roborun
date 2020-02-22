using System.Collections;
using System.Collections.Generic;
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
   
  
   
    void Start()
    {
        Time.timeScale = 1;
        camerapos.transform.position = new Vector3(0f, 94f, -614f);
       
        xpos = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
       currentselected = PlayerPrefs.GetInt("player",0);
        if(selected == currentselected)
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
            camerapos.transform.position = new Vector3(xpos, 94f, -614f);
           
            changeval(selected,"next");
            
        }
      
    }
    public void Previous()
    {
        if (xpos > 0f)
        {
            xpos -= 200f;
            camerapos.transform.position = new Vector3(xpos, 94f, -614f);
            changeval(selected, "previous");
          

        }
    }
    public void Selected()
    {
        PlayerPrefs.SetInt("player", selected);

        //SceneManager.LoadScene("welcome");
    }
    public void Back()
    {
        //PlayerPrefs.SetFloat("player", selected);

        SceneManager.LoadScene("welcome");
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
