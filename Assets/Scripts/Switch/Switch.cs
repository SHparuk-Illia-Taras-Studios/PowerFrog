using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SwitchSprites
{
    public Sprite charge0;
    public Sprite charge25;
    public Sprite charge50;
    public Sprite charge75;
    public Sprite charge100;
}
public class Switch : MonoBehaviour
{
    [SerializeField] private float energy;
    [SerializeField] private SwitchSprites sprites;
    [SerializeField] private SpriteRenderer counter;

    public void GivePower(float energy)
    {
        this.energy += energy;
        UpdatePowerGfx();
    }

    private void UpdatePowerGfx()
    {
        counter.sprite = energy switch
        {
            < 25 => sprites.charge0,
            >= 25 and < 50 => sprites.charge25,
            >= 50 and < 75 => sprites.charge50,
            >= 75 and <= 99 => sprites.charge75,
            > 99 => sprites.charge100,
            _ => counter.sprite
        };
    }
}
