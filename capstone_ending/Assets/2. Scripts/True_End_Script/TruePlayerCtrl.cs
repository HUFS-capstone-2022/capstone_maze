using UnityEngine;
using UnityEngine.AI;

public class TruePlayerCtrl : MonoBehaviour
{
// Must have values
    private Transform playerTr;
    private NavMeshAgent navAgent;
    
// Values for set destination or check player is arrived
    float distance = 0.0f;
    private Vector3 destination = new Vector3(97.0f, 13.45f, -74.0f);

    public bool setAgentDest = true;
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
            if (setAgentDest)
            {
                navAgent.SetDestination(destination);
                setAgentDest = false;
            }

            distance = Vector3.Distance(playerTr.position, destination);

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
            TrueManager.Instance.makeFadeOut = true;
        }

    }
}
