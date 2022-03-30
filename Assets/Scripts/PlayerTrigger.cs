using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public Gun gun;

    void Start() {
        if(gun == null) {
            Debug.LogError("You forgot to assign the gun here.");
            // try to find it manually, use this method sparingly
            gun = GameObject.Find("Gun").GetComponent<Gun>();
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("I've hit a " + other.gameObject.name);
        if(other.gameObject.CompareTag("Ammo Pickup")) {
            // call the gun.GetAmmo() function
            gun.GetAmmo();
            Destroy(other.gameObject);
        }
    }
}