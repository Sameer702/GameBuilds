using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//specific to enemy type bear to make him deal damage to player

public class Dragon : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Animator animator;

    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = calculateHealth();
    }

    internal void takeDamage()
    {
        throw new NotImplementedException();
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        slider.value = calculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health <= 0f)
        {
            animator.SetTrigger("die");
            Die();
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    float calculateHealth()
    {
        return health / maxHealth;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
