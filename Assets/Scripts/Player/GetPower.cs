using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPower : MonoBehaviour
{
    [SerializeField] private float energy = 0;
    private float _coef = 0.5f;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Power"))
        {
            energy += _coef;
            other.GetComponent<PowerLogic>().PullPower(_coef);
            UpdateColor();
        }
    }

    /// <summary>
    /// Повертає скільки енергії в жаби (у 100-бальній шкалі)
    /// </summary>
    /// <returns>Енергію</returns>
    public float GetEnergy()
    {
        return energy;
    }
    
    private void UpdateColor()
    {
        float percent = energy * 0.01f;
        float g = Mathf.Lerp(1, 0.7f, percent);
        float b = Mathf.Lerp(1, 0, percent);
        _spriteRenderer.color = new Color(1, g, b);
    }
}
