using UnityEngine;
using UnityEngine.AI;

public class NPCScript : MonoBehaviour
{
    public GameObject PC;
    public GameObject[] waypoints = new GameObject[4];

    private int index = 0;
    private int dist = 5;
    private bool perseg = false;
    private GameObject destino;
    private NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        next();
    }

    // Update is called once per frame
    void Update()
    {
        GetTarget();
    }

    private void next()
    {
        destino = waypoints[index++];

        index = (index == 4)? 0: index;
    }

    private void GetTarget()
    {
        destino = GetNextTarget();

        agente.SetDestination(destino.transform.position);
    }

    private GameObject GetNextTarget()
    {
        if (NextTo(PC))
            return PC;
        if (NextTo(destino))
            next();
        destino = waypoints[index];
        return destino;
    }

    private bool NextTo(GameObject obj)
    {
        return Vector3.Distance(obj.transform.position, transform.position) < dist;
    }
}
