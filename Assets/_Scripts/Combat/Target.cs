using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float HP = 50f;
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    public Animator animator;

    void Start()
    {
        health = maxHealth;
        slider.value = calculateHealth();
    }

    public void DamageTake(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
        }
        else
        {
            animator.SetTrigger("damage");
        }
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

    private void OnTriggerEnter(Collider other)
    {
        Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Dragon")
        {
            other.GetComponent<Dragon>().takeDamage(20);
        }
    }
}
