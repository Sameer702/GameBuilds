using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//manages the player

public class Player : MonoBehaviour
{
    public int currentLevel;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public WinningScreen winScreen;
    public GameObject deathScreen;
    public TimeController time;
    public Image overlay;
    public float duration;
    public float fadeSpeed;
    public AudioSource healSound;
    public AudioSource damagedSound;
    public Gun pistol;
    public Gun smg;
    public Gun shotgun;
    public Gun ak;
    private float durationTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        deathScreen.SetActive(false);
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    //Checks if the player is dead, also updates the players ammo and more
    void Update()
    {
        if (time.getCurrentTime() == "07:00")
        {
            winScreen.Setup();
        }
        if (currentHealth <= 0)
        {
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else if (time.getCurrentTime() == "10:00")
        {
            shotgun.magazines = 10;
        }
        else if (time.getCurrentTime() == "14:00")
        {
            smg.magazines = 12;
        }
        else if (time.getCurrentTime() == "20:00")
        {
            ak.magazines = 10;
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
        if (currentHealth >= 100)
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
        damagedSound.Play();
        healthBar.setHealth(currentHealth);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        Debug.Log("Saving Finished");
    }
}
