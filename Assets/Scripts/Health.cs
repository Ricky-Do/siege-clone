using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthSO healthSO;

    private float currentHealth;

    private void Start(){
        currentHealth = healthSO.maxHealth;

        Debug.Log($"Player health: {currentHealth}");
    }
}
