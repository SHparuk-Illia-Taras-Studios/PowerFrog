using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPower : MonoBehaviour
{
    [SerializeField] private float energy = 0;
    private float _coef = 0.5f;
    private SpriteRenderer _spriteRenderer;
    private IEnumerator coroutine;
    private String[] _tags = {"Power", "Switch"};

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var tag in _tags)
        {
            if (!other.CompareTag(tag)) continue;
            coroutine = GetEnergyCoroutine(other);
            StartCoroutine(coroutine);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (var tag in _tags)
        {
            if (!other.CompareTag(tag)) continue;
            StopCoroutine(coroutine);
        }
        
    }

    private IEnumerator GetEnergyCoroutine(Collider2D other)
    {
        var timer = 0.01f;
        while (true)
        {
            if (other == null) break;
            
            if (other.CompareTag("Power"))
            {
                if (energy + _coef > 100) break;
                timer = 0.01f;
                energy += _coef;
                other.GetComponent<PowerLogic>().PullPower(_coef);
                UpdateColor();
            }
            else if (other.CompareTag("Switch"))
            {
                if (energy - _coef * 2 < 0) break;
                timer = 0.1f;
                energy -= _coef * 2;
                other.GetComponent<Switch>().GivePower(_coef * 2);
                UpdateColor();
            }  
            
            yield return new WaitForSeconds(timer);
        }
        StopCoroutine(coroutine);
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
