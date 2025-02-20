using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile_Pooling : MonoBehaviour
{

    public GameObject projectilePrefab;
    public int projectilePoolSize = 20;
    private List<GameObject> projectilePool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectilePool = new List<GameObject>();

        for (int i = 0; i < projectilePoolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilePool.Add(projectile);
        }
    }

    public void GetObject(GameObject _firePos)
    {
        var get = projectilePool.FirstOrDefault(p => !p.activeInHierarchy);
        if (get != null)
        {
            get.transform.position = _firePos.transform.position;
            get.transform.rotation = _firePos.transform.rotation;
            get.SetActive(true);
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectilePool.Add(projectile);
        }
    }

    public void ReturnObject(GameObject projectile)
    {
        projectile.SetActive(false);
    }
}
