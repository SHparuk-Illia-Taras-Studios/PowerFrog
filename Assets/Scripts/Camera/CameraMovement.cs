using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float time = 1f;
    [SerializeField] private Vector3 speedVector;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            throw new UnityException("Camera Target is null");
        }
        speedVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
            new Vector3(target.position.x, target.position.y, transform.position.z), 
            ref speedVector, 
            time);
    }
}
