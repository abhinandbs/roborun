using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createplane : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform prefab;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {

            Instantiate(prefab, new Vector3(-0.12f, -0.42f, i * 30.06f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
