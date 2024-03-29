﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawmplayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform campos;
    public GameObject[] playermodels;
    private GameObject CurrentPlayer;
    public float playerspeed;
    private GameObject groundclone;
    public GameObject groundpostion;
    public int val;
    public GameObject Panel;
    public GameObject ResumeButton;
    private int totalspawm = 0;
    public int groundnumber;
    public GameObject coin;
    public GameObject[] enemy;
    public int coincount;
    private static int level = 1;
    public float movespeed;
    public bool moveleft;
    public bool moveright;


    public GameObject[] ground;
    private float j = 3 * 86f - 59.222222f;

    void Start()
    {
        int playval = PlayerPrefs.GetInt("player", 0);
        
        Vector3 position = new Vector3(0f, 1f, -21.6f);
      
        CurrentPlayer= Instantiate(playermodels[playval], position, Quaternion.identity);
        campos.transform.position = new Vector3(0f, 4f, -9f);
        groundclone = groundpostion;

        Score.scoreval = 0;
        Score.coinval = 0;
        InvokeRepeating("AddScore",0,.5f);


    }

    void AddScore()
    {
        Score.scoreval += 1;
    }


    void SpawnGround()
    {
        float dist = groundclone.transform.position.z - CurrentPlayer.transform.position.z;
        // Debug.Log(dist);
        if (dist < 200f)
        {


            Vector3 position = new Vector3(21, 11, j);
            groundclone = Instantiate(ground[val], position, Quaternion.identity);
            for (int i = 0; i < coincount; i++)
            {
                Vector3 coinposition = new Vector3(Random.Range(-3.0f, 3.0f), 0.5f, Random.Range(groundclone.transform.position.z - 50f, groundclone.transform.position.z));
                GameObject createdcoin = Instantiate(coin, coinposition, Quaternion.identity) as GameObject;

            }

            for (int k = 0; k < level; k++)
            {

                Vector3 enemyposition = new Vector3(Random.Range(-3.0f, 3.0f), 0.5f, Random.Range(groundclone.transform.position.z - 50f, groundclone.transform.position.z));
                GameObject createdenemy = Instantiate(enemy[val], enemyposition, Quaternion.identity) as GameObject;
            }

            totalspawm += 1;

            if (totalspawm == groundnumber)
            {
                changeval(val);
                totalspawm = 0;

            }

            j = j + 55.96f;
            //j = j +groundwidth;


        }
    }
    // Update is called once per frame

    void LateUpdate()
    {
        campos.transform.position = CurrentPlayer.transform.position + new Vector3(0f, 4f, -9f);
    }

        void Update()
    {
       
       
        CurrentPlayer.transform.position += Vector3.forward * Time.deltaTime * playerspeed;
        SpawnGround();


        //movement 
        if (CurrentPlayer.transform.position.y < -10)
        {

          

            Time.timeScale = 0;
            Debug.Log("GameOver");
            Panel.gameObject.SetActive(true);
            ResumeButton.gameObject.SetActive(false);
           
        }









        if (Input.GetKey(KeyCode.RightArrow) || moveright)
        {
           

            CurrentPlayer.transform.position += Vector3.right * Time.deltaTime * movespeed;


        }
        else if (Input.GetKey(KeyCode.LeftArrow) || moveleft)
        {

            //player.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
            CurrentPlayer.transform.position += Vector3.left * Time.deltaTime * movespeed;
           

        }


      
      
            //gamelevel
            if (Score.scoreval <= 0)
        {
            level = 1;


        }
        else if (Score.scoreval < 100)
        {
            level = 2;

        }
        else if (Score.scoreval < 5000)
        {
            level = 3;

        }
        else if (Score.scoreval < 50000)
        {
            level = 4;

        }
        else if (Score.scoreval < 100000)
        {
            level = 5;

        }
        else
        {
            level = 6;

        }

        //playerspeed
        if (Score.scoreval <= 50)
        {
            playerspeed = 15;
            movespeed = 5;

        }
        else if (Score.scoreval < 500)
        {
            playerspeed = 20;
            movespeed = 7;

        }
        else if (Score.scoreval < 1000)
        {
            playerspeed = 30;
            movespeed = 10;

        }
        else if (Score.scoreval < 10000)
        {
            playerspeed = 30;
            movespeed = 10;

        }
        else if (Score.scoreval < 100000)
        {
            playerspeed = 40;
            movespeed = 10;
        }
        else
        {
            playerspeed = 50;
            movespeed = 10;

        }

    }
    void changeval(int value)
    {
        if (value == 0)
        {
            val = 1;

        }
        else if (value == 1)
        {
            val = 2;
        }
        else if (value == 2)
        {
            val = 3;
        }
        else if (value == 3)
        {
            val = 4;
        }
        else if (value == 4)
        {
            val = 0;
        }


    }



}
