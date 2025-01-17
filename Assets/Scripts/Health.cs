using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField] int maxHealth;
    [Range(1, 100)]
    [SerializeField] float currentHealth;

    public TextMeshProUGUI hp;

    public UnityEvent <Vector3> spawnOnDeath;
    public UnityEvent onDeath;
    public UnityEvent onHitTaken;

    private void Start()
    {
        if (hp != null)
            hp.text = ((int)currentHealth).ToString();
    }
    public bool changeHealth(int amount)
    { 
        currentHealth += amount;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        if(currentHealth < 0)
            currentHealth = 0;

        //onHealthChange?.Invoke((int)currentHealth);

        return true;
    }

    public void hpDecrease(float amount)
    {
        if (currentHealth <= 0) return;


        onHitTaken?.Invoke();

        currentHealth = Mathf.FloorToInt(currentHealth - amount);

        if (currentHealth < 0)
        {
            currentHealth = 0;
            transform.GetComponent<Collider>().enabled = false;
        }

        if (hp != null)
            hp.text = ((int)currentHealth).ToString();

        //onHealthChange?.Invoke((int)currentHealth);

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
            
            spawnOnDeath?.Invoke(transform.position);
        }
    }
}
