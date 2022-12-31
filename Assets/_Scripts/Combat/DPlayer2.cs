using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlayer2 : MonoBehaviour
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
            Debug.Log("Entered");
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
        Debug.Log(other.tag);
        Debug.Log(other.gameObject.tag);
        timer += Time.deltaTime;
        Debug.Log(timer);
        if ((other.gameObject.tag == "Player"))
        {
            Debug.Log("Still here 2");
            if (timer >= second)
            {
                enemyDealsDamage();
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

    void enemyDealsDamage()
    {
        player.takeDamage(damagePerSecond);
        
    }

}
