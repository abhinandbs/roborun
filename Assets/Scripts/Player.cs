using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody rb;
    public float movespeed;
    public float playerspeed;
    private Animator anim;
    public GameObject player;
    public float jump;
    bool jumping;
    public bool moveleft;
    public bool moveright;
    public GameObject coin;
    public GameObject[] enemy;
    public int val;
    public GameObject Panel;
    public GameObject ResumeButton;
    public GameObject[] ground;
     private float j = 3*86f-59.222222f;
   // private float j = 143.2f;
    private GameObject groundclone;
    private int totalspawm = 0;
    public int groundnumber;
    private static int level = 1;
    private float groundwidth;


    public int coincount;

   



    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jumping = true;
        player.transform.rotation = Quaternion.AngleAxis(360, Vector3.down);

        groundclone = ground[val];


       // groundwidth = ground[val].transform.localScale.z;


        InvokeRepeating("SpawnGround", 1f, .5f);


        


    }

   

    void SpawnGround()
    {
        float dist = groundclone.transform.position.z - player.transform.position.z;
        // Debug.Log(dist);
        if (dist > 30f || dist < 500f)
        {
           

            Vector3 position = new Vector3(21, 11, j);
            groundclone = Instantiate(ground[val], position, Quaternion.identity);
            for (int i = 0; i < coincount; i++)
            {
                Vector3 coinposition = new Vector3(Random.Range(-3.0f, 3.0f), 0.5f, Random.Range(groundclone.transform.position.z -50f, groundclone.transform.position.z));
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
    void Update(){



            anim.SetBool("forward", true);
            player.transform.position += Vector3.forward * Time.deltaTime * playerspeed;

            if (player.transform.position.y < -10)
            {
                Time.timeScale = 0;
                Debug.Log("GameOver");
                Panel.gameObject.SetActive(true);
                ResumeButton.gameObject.SetActive(false);
            }







            // transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.DownArrow) || moveleft || moveright)
            {
                anim.SetBool("forward", true);

            }
            else
            {
                //anim.SetBool("forward", false);
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                player.transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
                player.transform.position += new Vector3(1.0f, 0.0f, 1.0f) * Time.deltaTime * movespeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                player.transform.position += new Vector3(-1.0f, 0.0f, 1.0f) * Time.deltaTime * movespeed;
                player.transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);
            }
            else if (Input.GetKey(KeyCode.RightArrow) || moveright)
            {
                // anim.SetBool("forward", true);
                //player.transform.rotation = Quaternion.AngleAxis(90, Vector3.up);
                player.transform.rotation = Quaternion.AngleAxis(45, Vector3.up);


                player.transform.position += Vector3.right * Time.deltaTime * movespeed;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                player.transform.rotation = Quaternion.AngleAxis(360, Vector3.down);
                player.transform.position += Vector3.forward * Time.deltaTime * movespeed;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || moveleft)
            {
                //player.transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
                player.transform.position += Vector3.left * Time.deltaTime * movespeed;
                player.transform.rotation = Quaternion.AngleAxis(-45, Vector3.up);

            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                player.transform.rotation = Quaternion.AngleAxis(-180, Vector3.up);
                player.transform.position += Vector3.back * Time.deltaTime * movespeed;
            }


            if (Input.GetKey(KeyCode.Space))
            {
                anim.SetBool("jump", true);
                // player.transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);

                if (jumping)
                {

                    rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jump);
                }
                else
                {

                }

            }
            else
            {
                anim.SetBool("jump", false);
            }
            if (!moveleft || !moveright)
            {
                player.transform.rotation = Quaternion.AngleAxis(360, Vector3.down);
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
        else if (Score.scoreval < 10000)
        {
            level = 3;
            
        }
        else if (Score.scoreval < 50000)
        {
            level = 4;
            
        }
        else if(Score.scoreval < 100000)
        {
            level = 5;
           
        }
        else
        {
            level = 6;
            
        }

        //playerspeed
        if (Score.scoreval <= 100)
        {
            playerspeed = 10;
            movespeed = 5;

        }
        else if (Score.scoreval < 500)
        {
            playerspeed = 15;
            movespeed = 7;

        }
        else if (Score.scoreval < 1000)
        {
            playerspeed = 20;
            movespeed = 9;

        }
        else if (Score.scoreval < 10000)
        {
            playerspeed = 30;
            movespeed = 11;

        }
        else if (Score.scoreval < 100000)
        {
            playerspeed = 40;
            movespeed = 13;
        }
        else
        {
            playerspeed = 50;
            movespeed = 14;

        }


    }

    
   
    

    
    void OnCollisionEnter(Collision collision)
    {
        jumping = true;
    }

    void OnCollisionExit(Collision other)
    {
        jumping = false;
       
    }
    
    void changeval(int value)
    {
        if (value == 0 )
        {
            val =  1;

        }
        else if(value == 1)
        {
            val = 2;
        }else if(value == 2)
        {
            val = 0;
        }
        
    }

   
}
