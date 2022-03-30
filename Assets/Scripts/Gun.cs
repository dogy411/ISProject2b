using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // public variables
    public Rigidbody bulletPrefab;
    public Transform bulletSpawn;

    // attributes are awesome, really
    [Range(10,100)]
    public float bulletSpeed = 50;
    public float fireRate = 0.1f;

    public bool debug = false;

    [Header("Audio")]
    public AudioClip fire, getAmmo;
    // build one for reload, and out-of-bullets, and picking up bullets


    // private variables
    [Header("Ammo Management")]
    public int totalAmmo = 30;
    public int clipSize = 10;
    public int clip = 0;

    private AudioSource aud;        // the audiosource attached to this gameObject.

    bool canShoot = true;

    void Start() {
        aud = this.gameObject.GetComponent<AudioSource>();
    }

    public void Reload() {
        if(clip == clipSize) {
            if(debug) Debug.Log("Clip is already full.");
            return;
        }

        if(totalAmmo + clip >= clipSize) {          // if 90 > 10
            totalAmmo -= (clipSize - clip);          // 90 - 10 = 80
            clip = clipSize;                // clip = 10
        } else {
            // throw the rest of the ammo into the clip
            clip = totalAmmo + clip;
            totalAmmo = 0;
        }

        
    }

    public void Fire() {
        if(canShoot) {
            if(clip > 0) {
                if(debug) Debug.Log("Pow!");
                aud.pitch = Random.Range(0.95f, 1.05f);     // slightly vary the pitch of each gunshot.
                aud.PlayOneShot(fire);          // PlayOneShot() will overlap sounds, unlike .Play()
                clip -= 1;
                // create a copy of the bullet prefab
                Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                // move the bullet in front of the gun
                bullet.transform.Translate(0,0,1);
                // add forward force to the bullet
                bullet.AddRelativeForce(Vector3.forward * bulletSpeed, ForceMode.Impulse);

                StartCoroutine(Cooldown());
            } else {
                if(debug) Debug.Log("Out of Ammo!");
            }
        }
        
    }

    public void GetAmmo() {
        totalAmmo += 90;
        aud.PlayOneShot(getAmmo);
    }

    IEnumerator Cooldown() {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    
}