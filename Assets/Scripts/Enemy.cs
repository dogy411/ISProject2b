using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float attackInterval =2;
   bool canAttack = true;
   public Transform player;
   public Health playerHealth;
   public int attackDamage = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Vector3.Distance(this.transform.position, player.position) < 3){
         if(canAttack){
             playerHealth.health -= attackDamage;
             StartCoroutine(ResetAttack());
         }
     }   
    }
    IEnumerator ResetAttack(){
        canAttack = false;
        yield return new WaitForSeconds(attackInterval);
        canAttack = true;
    }
}
