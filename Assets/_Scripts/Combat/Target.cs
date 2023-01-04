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
    public Decay hunger;

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
        if (this.tag == "enemy")
        {
            hunger.increaseHunger(5);
        }
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
        else if (other.tag == "Bear")
        {
            other.GetComponent<Bear>().takeDamage(20);
        }
        else if (other.tag == "Spider")
        {
            other.GetComponent<Spider>().takeDamage(20);
        }
    }
}
