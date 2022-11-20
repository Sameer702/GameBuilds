using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Player player;    
    private float timer;
    public float timeBetweenDamage;

    // Moment it collides
    void OnTriggerEnter(Collider other)
    {
        enemyDealsDamage(other);
    }

    // While they are colliding
    void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenDamage)
        {
            enemyDealsDamage(other);
            timer = 0;
        }
    }

    void enemyDealsDamage(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            player.takeDamage(5);
        }
    }

}
