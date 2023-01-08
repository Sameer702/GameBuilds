using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//the script that controls and decays the players hunger

public class Decay : MonoBehaviour
{
    public int decayPercent;
    public int decayAmount;
    public float decayTime;
    public Text decayText;
    public bool decaying;
    public Player player;
    public int healAbovePercent;

    void Start()
    {
        StartCoroutine(decay());
    }

    void Update()
    {
        decayText.text = decayPercent + "%";
    }

    //increases the player hunger
    public void increaseHunger(int val)
    {
        if (decayPercent >= 100)
        {
            return;
        }
        decayPercent += val;
        
        if (decayPercent >= 100)
        {
            decayPercent = 100;
            player.increaseHealth(2);
        }
    }

    IEnumerator decay()
    {
        while (decaying)
        {
            yield return new WaitForSeconds(decayTime);

            if (decayPercent >= healAbovePercent)
            {
                player.increaseHealth(3);
            }
            
            if (decayPercent >= 0)
            {
                decayPercent = decayPercent - decayAmount;

                if (decayPercent <= 0)
                {
                    decayPercent = 0;
                }
            }
            if (decayPercent < 15)
            {
                player.takeDamage(10);
            }
        }
    }
}
