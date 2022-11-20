using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    // public float health = 50f;
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = calculateHealth();
    }

    public void takeDamage (float amount)
    {
        health -= amount;
        slider.value = calculateHealth();
        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    float calculateHealth()
    {
        return health / maxHealth;
    }
}
