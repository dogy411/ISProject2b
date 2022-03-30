using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFoV : MonoBehaviour
{
    public Transform player;
    public float fieldOfView = 45;
    Transform emitter;

    public Renderer rend;

public bool canSeePlayer = false;
    void Start()
    {
        emitter = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
      RaycastHit hit;

      Vector3 rayDirection = (player.position + Vector3.up) - emitter.position;
    Vector3 endVector = Quaternion.AngleAxis(fieldOfView , Vector3.up) * transform.forward * 10;
    Debug.DrawRay(emitter.position, endVector, Color.magenta);

  Vector3 endVector = Quaternion.AngleAxis(-fieldOfView , Vector3.up) * transform.forward * 10;
    Debug.DrawRay(emitter.position, endVector, Color.magenta);



   float angle = Vector3.Angle(rayDirection, emitter.forward);
   if(angle < fieldOfView){
       if(Physics.Raycast(emitter.position, rayDirection, out hit, 30f)){
           if(hit.collider.CompareTag("Player")){
               canSeePlayer = true;
               Debug.DrawRay(emitter.position, rayDirection, Color.red);
               rend.material.color = Color.red;
           }
           else {
               canSeePlayer = false;
                Debug.DrawRay(emitter.position, rayDirection, Color.green);
               rend.material.color = Color.green;
           }
       }
       else
       {
           canSeePlayer = false;
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
