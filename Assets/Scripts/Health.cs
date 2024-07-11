using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthSO healthSO;

    public event EventHandler<OnTakeDamageEventArgs> OnTakeDamage;
    public class OnTakeDamageEventArgs : EventArgs{
        public float damageTaken;
    }

    private float currentHealth;

    private void Start(){
        currentHealth = healthSO.maxHealth;
    }

    private void Update(){
        
    }

    public void TakeDamage(float damage){
        OnTakeDamage?.Invoke(this, new OnTakeDamageEventArgs{damageTaken = damage});
        currentHealth -= damage;
        Debug.Log($"{healthSO.name}: {currentHealth}");
        CheckDeath();
    }

    private void CheckDeath(){
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    
}
