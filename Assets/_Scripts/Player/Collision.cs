using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Player player;    
    private float timer;

    // Moment it collides
    void OnTriggerEnter(Collider other)
    {
        enemyDealsDamage(other);
    }

    // While they are colliding
    void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        if ((other.gameObject.tag == "enemy"))
        {
            if (timer >= 2)
            {
                player.takeDamage(5);
                timer = 0;
            }
        }
        // if (timer >= timeBetweenDamage)
        // {
        //     if (other.gameObject.tag == "enemy")
        //     {
        //         player.takeDamage(5);
        //     }
        //     timer = 0;
        // }
    }

    void enemyDealsDamage(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            player.takeDamage(5);
        }
    }

}
