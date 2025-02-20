using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Enemies
{
    private NavMeshAgent _agent;
    [SerializeField] private GameObject vfxExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        //_agent.SetDestination(path.transform.position);
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            StartCoroutine(HitandDie(other.gameObject));
        }
    }

    IEnumerator HitandDie(GameObject other)
    {
        health -= other.GetComponent<Projectile>().damage;
        GameObject vfx = Instantiate(vfxExplosion, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.5f);
        Destroy(vfx);
        Die();
    }
}
