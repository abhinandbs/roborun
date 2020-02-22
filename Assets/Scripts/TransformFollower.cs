using UnityEngine;
using System.Collections;

public class TransformFollower : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    public Vector3 offsetPosition;

    public Transform camerapos;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void Start()
    {
        offsetPosition = camerapos.position;
    }
    private void Update()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        
       
    }
}