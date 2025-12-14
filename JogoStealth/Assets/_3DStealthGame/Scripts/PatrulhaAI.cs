using UnityEngine;
using UnityEngine.AI;

public class AIPatrol: MonoBehaviour
{

    public Transform [] positions;
    private NavMeshAgent agent;
    private int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        index = 0;
        Vector3 newPos =new Vector3(positions[index].position.x, transform.position.y, positions[index].position.z);
        agent.SetDestination(newPos);
    }

    void Update()
    {
        if(Vector3.Distance(agent.destination, transform.position) < 0.1f)
        {   index = (index + 1) % positions.Length;
            Vector3 newPos =new Vector3(positions[index].position.x, transform.position.y, positions[index].position.z);
            agent.SetDestination(newPos);
        }   
        
    }
}