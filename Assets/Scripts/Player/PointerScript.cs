using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    private Transform _parent;
    void Awake()
    {
        _parent = transform.parent;
    }

    [SerializeField] private float angle;
    void Update()
    {
        if (angle > 360) angle -= 360;
        else if (angle < 0) angle += 360;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        angle = Vector2.SignedAngle(Vector2.right, mousePos - _parent.position);
        
        transform.rotation = Quaternion.AngleAxis(angle, _parent.transform.forward);
        
        transform.localPosition = new Vector2(Mathf.Sin((90-angle) * Mathf.Deg2Rad), 
            Mathf.Cos((90-angle) * Mathf.Deg2Rad)) * 1.2f;
    }

    
} 
