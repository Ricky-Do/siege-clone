using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;
    [SerializeField] private Image healthFill;
    [SerializeField] private HealthSO healthSO;
    [SerializeField] private Transform player;
    private Health health;


    // Start is called before the first frame update
    void Start()
    {
        health = player.GetComponent<Health>();

        maxHealth = healthSO.maxHealth;
        currentHealth = maxHealth;
        health.OnTakeDamage += Health_OnHealthUpdate;
    }

    private void Health_OnHealthUpdate(object sender, Health.OnTakeDamageEventArgs e)
    {
        currentHealth += e.damageTaken;
    }

    // Update is called once per frame
    void Update()
    {
        healthFill.fillAmount = currentHealth / maxHealth;
    }
}
