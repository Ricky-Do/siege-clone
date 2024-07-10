using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthSO healthSO;

    private float currentHealth;

    private void Start(){
        currentHealth = healthSO.maxHealth;

        Debug.Log($"{healthSO.name}: {currentHealth}");
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            TakeDamage();
            currentHealth -= 10;
        }
    }

    private void TakeDamage(){
        Debug.Log($"{currentHealth} - 10");
        Debug.Log($"Health: {currentHealth - 10}");
    }
}
