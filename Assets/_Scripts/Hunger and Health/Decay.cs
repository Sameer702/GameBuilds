using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Decay : MonoBehaviour
{
    public static int decayPercent;
    public int decayAmount;
    public float decayTime;
    public Text decayText;
    public bool decaying;
    public Player player;

    void Start()
    {
        StartCoroutine(decay());
        
    }

    void Update()
    {
        decayText.text = decayPercent + "%";
    }
    IEnumerator decay()
    {
        while (decaying)
        {
            yield return new WaitForSeconds(decayTime);
            
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
    public void decreaseHunger(int food){
        decayPercent = decayPercent + food;
    }
}
