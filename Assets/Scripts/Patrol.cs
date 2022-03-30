    // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public Transform[] points;
        public float reactionTime = 1;
        private int destPoint = 0;
        private NavMeshAgent agent;

private AIFoV fov;

        void Start () {
            agent = GetComponent<NavMeshAgent>();
fov = GetComponent<AIFoV>();
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

private float eyesOnPlayerTimer = 0;

        void Update () {

if(fov.canSeePlayer == true){
eyesOnPlayerTimer += Time.deltaTime;
if(eyesOnPlayerTimer > reactionTime){
    agent.destination = fov.player.position;
}
}
else{
    eyesOnPlayerTimer = 0;
}
Debug.Log("EyesOnPlayerTimer: " + eyesOnPlayerTimer);

            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                StartCoroutine(WaitAtPatrolPoint());
        }
     IEnumerator WaitAtPatrolPoint() {
         yield return new WaitForSeconds(2);
         GotoNextPoint();
     }
    }