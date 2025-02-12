using System.Collections.Generic;
using UnityEngine;

public class BuildTowers : MonoBehaviour
{

    public List<GameObject> towerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("TowerPlace"))
                {
                    Debug.Log("Tower clicked");
                    SpawnTower(2, hit.collider.transform.position);
                }
            }
        }
    }

    private void SpawnTower(int towerIndex, Vector3 transform)
    {
        Instantiate(towerPrefab[towerIndex], transform, Quaternion.identity);
    }
}
