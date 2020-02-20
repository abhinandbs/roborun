using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touch : MonoBehaviour
{

    private Player player;
    public Text textleft;
    public Text textright;
    public Image leftImage;
    public Image RightImage;

   

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<Player>();
        float val = PlayerPrefs.GetFloat("firsttime");
        if (val == 0)
        {
            textleft.text =  "MOVE LEFT";
            textright.text = "MOVE RIGHT";
            var tempColor = leftImage.color;
            tempColor.a = 0.49f;

            leftImage.color = tempColor;
            var tempColor1 = RightImage.color;
            tempColor1.a = 0.49f;
            RightImage.color = tempColor1;

            PlayerPrefs.SetFloat("firsttime",1);
        }
        else
        {
            textleft.text = "";
            textright.text = "";
        }

       

    }

    // Update is called once per frame
   
    public void LeftArrow()
    {
        textleft.text = "";
        var tempColor = leftImage.color;
        tempColor.a = 0f;

        leftImage.color = tempColor;
        
        player.moveright = false;
        player.moveleft = true;
    }
    public void RightArrow()
    {
        textright.text = "";
       
        var tempColor1 = RightImage.color;
        tempColor1.a = 0f;
        RightImage.color = tempColor1;

        player.moveright = true;
        player.moveleft = false;
    }
   
    public void ReleaseLeftArrow()
    {
        player.moveleft = false;
    }
    public void ReleaseRightArrow()
    {
        player.moveright = false;

    }
}
