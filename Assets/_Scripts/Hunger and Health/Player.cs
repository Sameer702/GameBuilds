using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public WinningScreen winScreen;
    public TimeController time;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (time.getCurrentTime() == "07:00")
        {
            winScreen.Setup();
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        healthBar.setHealth(currentHealth);
    }
}
