using UnityEngine.UI;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public float health = 300;
    public float maxHealth = 300;

    public GameObject healthBarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.value = calculateHealth();
    }

    // Update is called once per frame
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
            Die();
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
