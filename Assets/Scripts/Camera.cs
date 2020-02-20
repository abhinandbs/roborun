using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        // offset = transform.position - player.transform.position.x;
        Vector3 pos = transform.position;
        pos.x = 0;
        pos.z =-6;
        transform.position = pos;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        // transform.position = player.transform.position + offset;
        Vector3 pos = transform.position;
        pos.x = player.transform.position.x;
        pos.z = player.transform.position.z -15;
        pos.y = player.transform.position.y +5;
        transform.position = pos;

    }
}
