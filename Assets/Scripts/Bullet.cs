using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 2;

    void Start(){
        if(Random.value < 0.8f){
            damage *= 2;
            Debug.Log("Critical Hit");
        }
    }
}