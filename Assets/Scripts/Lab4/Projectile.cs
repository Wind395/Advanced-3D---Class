using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 5;

    private GameObject[] target;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        for (int i = 0; i < target.Length; i++)
        {
            Seek(target[i].transform);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);
            HitTarget();
        }
    }

    public void Seek(Transform target)
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}