using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[DefaultExecutionOrder(1)]
public class BadUnit : MonoBehaviour
{
    // Value for handle cache of component
    private Transform playerTr;
    private Transform unitTr;
    private NavMeshAgent navAgent;
    private Animator anim;

// Distance between units and player
    public float AroundTarget = 2.5f;

    public bool moving = false;

// Awake()
    private void Awake()
    {
        // Put this object int BadManager Units List
        BadManager.Instance.Units.Add(this);

        // Assign Components
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        unitTr = GetComponent<Transform>();
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            // Get distance of enemy and player
            float distance = Vector3.Distance(playerTr.position, unitTr.position);

            // If unit is close enough to player
            if (distance <= AroundTarget)
            {
                // Stop NavMeshAgent
                NavAgentWork(false);
                
                // Stop walking animation
                WalkAnim(false);

                // If unit is arrived, count the unit number
                BadManager.Instance.arrivedUnitNum++;

                moving = false;
            }
        }

        // change unit's rotation to player
        Quaternion lookRotation = Quaternion.LookRotation((playerTr.position - unitTr.position).normalized);
        unitTr.rotation = Quaternion.Slerp(unitTr.rotation, lookRotation, 4.0f * Time.deltaTime);
    }


// Functions
    // Set Navigation Mesh Agent Destination
    public void SetNavDestination(Vector3 Position)
    {
        navAgent.SetDestination(Position);
    }

    // Set unit walking animation
    public void WalkAnim(bool Check)
    {
        anim.SetBool("walking", Check);
    }

    // set Navigation Mesh Agent stop or not
    public void NavAgentWork(bool Check)
    {
        navAgent.isStopped = !Check;
    }
}
