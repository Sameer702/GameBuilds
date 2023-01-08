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
        if ((other.gameObject.tag == "enemy"))
        {
            if (timer >= 2)
            {
                player.takeDamage(5);
                timer = 0;
            }
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
