using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeWheelScript : MonoBehaviour
{
    [SerializeField] private Sprite[] chargeSprites;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public int GetCharge() => chargeSprites.Length;

    public void SetCharge(int charge)
    {
        _spriteRenderer.sprite = chargeSprites[charge];
    }
}