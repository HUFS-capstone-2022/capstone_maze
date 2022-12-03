using UnityEngine;
using UnityEngine.AI;

public class TruePlayerCtrl : MonoBehaviour
{
// Must have values
    private Transform playerTr;
    private NavMeshAgent navAgent;
    private AudioSource audioSource;
    
// Values for set destination or check player is arrived
    float distance = 0.0f;
    private Vector3 destination = new Vector3(108.7f, 13.372f, -71.1f);

    public bool setAgentDest = true;
    public bool arrived = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GetComponent<Transform>();
        navAgent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TrueManager.Instance.makePlayerMoving)
        {
            if (setAgentDest)
            {
                navAgent.SetDestination(destination);
                audioSource.Play();
                setAgentDest = false;
            }

            distance = Vector3.Distance(playerTr.position, destination);

            if (distance < 0.2f)
            {
                navAgent.isStopped = true;
                audioSource.Stop();
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
