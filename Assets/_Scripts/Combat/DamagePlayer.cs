using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the script that deals damage to the player

public class DamagePlayer : MonoBehaviour
{
    public Player player;    
    private float timer;
    public int damagePerSecond;
    public int second;

    // Moment it collides
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyDealsDamage();
        }
        if (other.tag == "Dragon")
        {
            transform.parent = other.transform;
            other.GetComponent<Dragon>().takeDamage(40);
        }
    }

    // While they are colliding
    void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        
        if ((other.gameObject.tag == "Player"))
        {
            if (timer >= second)
            {
                enemyDealsDamage();
                timer = 0;
            }
        }
    }

    void enemyDealsDamage()
    {
        player.takeDamage(damagePerSecond);
        
    }

}
