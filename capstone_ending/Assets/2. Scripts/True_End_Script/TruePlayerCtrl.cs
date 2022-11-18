using UnityEngine;
using UnityEngine.AI;

public class TruePlayerCtrl : MonoBehaviour
{
    private Transform playerTr;
    private NavMeshAgent navAgent;
    public float smoothTime = 1.0f;
    float distance = 0.0f;


    private Vector3 destination0 = new Vector3(97.0f, 13.45f, -74.0f);

    public bool order = true;
    public bool arrived = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GetComponent<Transform>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TrueManager.Instance.makePlayerMoving)
        {
            navAgent.SetDestination(destination0);
            distance = Vector3.Distance(playerTr.position, destination0);
            if (order)
            {
                order = false;
            }

            if (distance < 0.1f)
            {
                navAgent.isStopped = true;
                TrueManager.Instance.makePlayerMoving = false;
                arrived = true;
            }
        }

        if (arrived)
        {
            // fade In
            TrueManager.Instance.makeFadeIn = true;
        }

    }
}
