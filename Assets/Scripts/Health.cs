using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthSO healthSO;

    public event EventHandler<OnHealthUpdateEventArgs> OnHealthUpdate;
    public class OnHealthUpdateEventArgs : EventArgs{
        public float healthChange;
    }

    private float currentHealth;

    private void Start(){
        currentHealth = healthSO.maxHealth;
    }

    private void Update(){
        
    }

    public void TakeDamage(float damage){
        OnHealthUpdate?.Invoke(this, new OnHealthUpdateEventArgs{healthChange = damage});
        Debug.Log($"{healthSO.name} Health: {currentHealth}");
        Debug.Log($"{healthSO.name} Damage: {damage}");
        currentHealth += damage;
        Debug.Log($"{healthSO.name}: {currentHealth}");
        CheckDeath();
    }

    private void CheckDeath(){
        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    
}
