using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public AudioSource coinSound;
    void OnCollisionEnter(Collision collision){
         if(collision.collider.tag == "Coin"){
             Debug.Log("COIN COLLECTED");
             coinSound.Play();
             Destroy(collision.gameObject);

             //Play sound ecc.. and Score
         }
    }
    
}
