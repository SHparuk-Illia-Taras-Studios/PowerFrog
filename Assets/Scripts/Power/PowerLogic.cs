using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLogic : MonoBehaviour
{
    [SerializeField] private float orbEnergy = 100;
    private Transform _transform;
    void Start()
    {
        _transform = gameObject.transform;
    }

    void Update()
    {
        transform.localScale = Vector3.one * (orbEnergy / 100f);
    }

    /// <summary>
    /// Викачати енергію з джерела
    /// </summary>
    /// <param name="energy">Скільки енергії викачати</param>
    public void PullPower(float energy)
    {
        orbEnergy -= energy;
        if (orbEnergy <= 0)
        {
           Destroy(gameObject);
        }
    }
}
