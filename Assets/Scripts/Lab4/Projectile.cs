using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 5;

    private Projectile_Pooling projectilePool;
    private GameObject[] target;

    void Start()
    {
        projectilePool = GameObject.Find("PoolManager").GetComponent<Projectile_Pooling>();
    }

    void Update()
    {
        target = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < target.Length; i++)
        {
            Seek(target[i].transform);
        }

        if (target.Length == 0)
        {
            projectilePool.ReturnObject(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HitTarget();
        }
    }

    public void Seek(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void HitTarget()
    {
        projectilePool.ReturnObject(gameObject);
    }
}