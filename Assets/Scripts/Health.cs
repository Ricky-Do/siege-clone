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

        Debug.Log($"{healthSO.name}: {currentHealth}");
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            TakeDamage();
            currentHealth -= 10;
        }
    }

    private void TakeDamage(){
        OnHealthUpdate?.Invoke(this, new OnHealthUpdateEventArgs{healthChange = -10f});
        Debug.Log($"{currentHealth} - 10");
        Debug.Log($"Health: {currentHealth - 10}");
    }

    
}
