using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 400 * Time.deltaTime);
        
    }
}
