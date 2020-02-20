using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coincollider : MonoBehaviour
{


    public AudioSource coinsound;
    public AudioClip coin;
    

    // Start is called before the first frame update
    void Start()
    {
        coinsound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Score.scoreval += 10;
    }
   

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            if (!coinsound.isPlaying)
            {
                coinsound.clip = coin;
                coinsound.Play();
                Debug.Log("Played");
            }
            Score.scoreval += 10;
            

           
            Debug.Log("hit detecetl");
            Destroy(gameObject);
        }
    }
}
