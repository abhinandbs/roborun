using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{

    public GameObject sphere;
  void OnBecameInvisible()
    {
      Destroy(sphere);


    }
}
