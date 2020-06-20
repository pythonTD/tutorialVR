using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using CrazyMinnow.SALSA;


public class pathAnimation2 : MonoBehaviour
{

    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f; //If the distance between the enemy and the waypoint is less than this, then it has reacehd the waypoint
    private int lastWaypointIndex;

    private float movementSpeed = 2.0f;
    private float rotationSpeed = 4.0f;

    VRIK ik;

    Animator anim;
    VRIK VRIKscript;
    Salsa3D salsa;

    public Transform newHead;
    public Transform newR_arm;
    public Transform newL_arm;




    // Use this for initialization
    void Start()
    {
        if (taskPhaseManager.ack2) { 
            lastWaypointIndex = waypoints.Count - 1;
            targetWaypoint = waypoints[targetWaypointIndex]; //Set the first target waypoint at the start so the enemy starts moving towards a waypoint
            anim = GetComponent<Animator>();
            anim.SetBool("walk", true);
            anim.enabled = true;

            VRIKscript = gameObject.GetComponent<VRIK>();
            VRIKscript.enabled = false;

            ik = GetComponent<VRIK>();
            ik.solver.spine.headTarget = newHead;
            ik.solver.leftArm.target = newL_arm;
            ik.solver.rightArm.target = newR_arm;

        }
    }

    // Update is called once per frame
    void Update(){
        setPosition();
            //anim.SetBool("walk",true);
        
    }

    /// <summary>
    /// Checks to see if the enemy is within distance of the waypoint. If it is, it called the UpdateTargetWaypoint function 
    /// </summary>
    /// <param name="currentDistance">The enemys current distance from the waypoint</param>
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    /// <summary>
    /// Increaes the index of the target waypoint. If the enemy has reached the last waypoint in the waypoints list, it resets the targetWaypointIndex to the first waypoint in the list (causes the enemy to loop)
    /// </summary>
    /// 

    void setPosition() {

        float movementStep = movementSpeed * Time.deltaTime;
        float rotationStep = rotationSpeed * Time.deltaTime;

        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationStep);

        Debug.DrawRay(transform.position, transform.forward * 50f, Color.green, 0f); //Draws a ray forward in the direction the enemy is facing
        Debug.DrawRay(transform.position, directionToTarget, Color.red, 0f); //Draws a ray in the direction of the current target waypoint

        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }



    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
            movementSpeed = 0f;
            rotationSpeed = 0f;

            anim.SetBool("walk", false);

            //you will have to set the VRIK components to the new created box
            GetComponent<Animator>().enabled = false;
            GetComponent<VRIK>().enabled = true;
            GetComponent<VRIK>().solver.Reset();







        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }
}