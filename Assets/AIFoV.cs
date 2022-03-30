using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFoV : MonoBehaviour
{
    public Transform player;
    public float fieldOfView = 45;
    Transform emitter;

    public Renderer rend;

    void Start()
    {
        emitter = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit hit;

      Vector3 rayDirection = (player.position + Vector3.up) - emitter.position; 
   float angle = Vector3.Angle(rayDirection, emitter.forward);
   if(angle < fieldOfView){
       if(Physics.Raycast(emitter.position, rayDirection, out hit, 30f)){
           if(hit.collider.CompareTag("Player")){
               Debug.DrawRay(emitter.position, rayDirection, Color.green);
               rend.material.color = Color.green;
           }
           else {
                Debug.DrawRay(emitter.position, rayDirection, Color.red);
               rend.material.color = Color.red;
           }
       }
       else
       {
           rend.material.color = Color.gray;
            Debug.DrawRay(emitter.position, rayDirection, Color.cyan);
       }
   }
else{
    rend.material.color = Color.gray;
     Debug.DrawRay(emitter.position, rayDirection, Color.cyan);
}


       }
}
