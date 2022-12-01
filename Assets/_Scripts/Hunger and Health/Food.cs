using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Food : MonoBehaviour
{
    
    public Collider other;

    void Start(){
        Decay.decayPercent=100;
    }
        

    private void OnTriggerEnter(Collider other) 
    {
        decreaseHunger(10);
        Die();
    }
    public void decreaseHunger(int food){

        Decay.decayPercent = Decay.decayPercent + food;
        if (Decay.decayPercent >= 100)
        {
            Decay.decayPercent = 100;
        }
    }

    void Die(){
        Destroy(gameObject);
    }

}
