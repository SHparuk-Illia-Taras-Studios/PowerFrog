using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    private JumpScript _jumpScript;

    private void Awake()
    {
        _jumpScript = GetComponentInParent<JumpScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Power")) return;
        GetComponentInParent<Rigidbody2D>().Sleep();
        _jumpScript.spriteRenderer.sprite = _jumpScript.frogSprite.idle;
    }
}