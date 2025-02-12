using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] private Camera cam;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            agent.SetDestination(GetMousePosition());
        }
        
    }

    private Vector3 GetMousePosition()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
