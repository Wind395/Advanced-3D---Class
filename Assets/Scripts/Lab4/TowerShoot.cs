using System.Collections;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    [SerializeField] private Transform firePos;

    public float fireRate = 1f;
    private float fireCountdown = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        GameObject bullet = Instantiate(bulletPrefab, firePos.transform.position, Quaternion.identity);
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
