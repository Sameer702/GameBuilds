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
    public Image overlay;
    public float duration;
    public float fadeSpeed;
    public AudioSource healSound;
    private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (time.getCurrentTime() == "07:00")
        {
            winScreen.Setup();
        }

        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    public void increaseHealth(int val)
    {
        if (currentHealth == 100)
        {
            return;
        }
        currentHealth = currentHealth + val;
        
        if (currentHealth >= 100)
        {
            currentHealth = 100;
        }
        healthBar.setHealth(currentHealth);
        healSound.Play();
    }

    public void takeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
        healthBar.setHealth(currentHealth);
    }
}
