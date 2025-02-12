using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{

    private Rigidbody rb;
    private NavMeshAgent agent;

    public enum State
    {
        Idle,
        Move,
        Jump,
        Boost
    }

    State currentState = State.Idle;

    public float boostSpeed = 10f;
    private float boostTime = 2f;
    private bool isBoosting = false;
    private float totalDistance;
    private float distanceCovered = 0f;
    private bool isJumping = false;
    private bool stopJump = false;

    public Transform target;
    private Vector3 startPosition;
    int _randomAction;

    [SerializeField] private GameObject jumpArea;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        totalDistance = Vector3.Distance(startPosition, target.position);
        currentState = State.Move;
        _randomAction = Random.Range(0, 1);
    }

    void Update()
    {

        distanceCovered = Vector3.Distance(startPosition, agent.transform.position);
        
        if (distanceCovered >= totalDistance / 3f)
        {
            RandomizeAction();
        }

        switch(currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Move:
                Move();
                break;
            case State.Jump:
                Jump();
                break;
            case State.Boost:
                StartCoroutine(Boost());
                break;
        }

        

    }

    void RandomizeAction()
    {
        Debug.Log("Randomize Action");
        
        switch (_randomAction)
        {
            case 0:
                jumpArea.SetActive(true);
                currentState = State.Jump;
                break;
            case 1:
                currentState = State.Boost;
                break;
        }
    }


    void Idle()
    {
        Debug.Log("Idle");
    }


    void Move()
    {
        Debug.Log("Move");
        agent.SetDestination(target.position);
    }

    void Jump()
    {
        Debug.Log("Jump");
        //transform.position = new Vector3(transform.position.x, transform.position.y * 5 * Time.deltaTime, transform.position.z);
        //yield return new WaitForSeconds(0.5f);
        Invoke("EndJump", 1f);
    }

    private void EndJump()
    {
        currentState = State.Move;
    }

    IEnumerator Boost()
    {
        agent.speed *= 2f;
        yield return new WaitForSeconds(2f);
        agent.speed /= 2f;
    }
}
