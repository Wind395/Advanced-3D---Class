using System.Collections;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    [SerializeField] private Transform firePos;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    private Projectile_Pooling projectilePool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectilePool = GameObject.Find("PoolManager").GetComponent<Projectile_Pooling>();
    }

    // Update is called once per frame
    void Update()
    {
        fireCountdown -= Time.deltaTime;
        if (fireCountdown <= 0)
        {
            DetectEnemy();
            fireCountdown = 1f / fireRate;
        }
    }

    void Shoot() 
    {
        projectilePool.GetObject(firePos.gameObject);
    }

    // Detect enemies in range
    void DetectEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.tag == "Enemy")
            {
                Shoot();
            }
        }
    }

}
