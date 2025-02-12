using System.Collections;
using UnityEngine;

public class Lesson1 : MonoBehaviour
{
    public GameObject objectPrefab;

    public float rangeRandomMin;
    public float rangeRandomMax;

    public float max = 10;
    public float current = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(InstantiateObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiateObject()
    {
        while (current < max)
        {
            GameObject newObject = Instantiate(objectPrefab, new Vector3(Random.Range(rangeRandomMin, rangeRandomMax), Random.Range(1, 5), Random.Range(rangeRandomMin, rangeRandomMax)), Quaternion.identity);
            yield return new WaitForSeconds(2f);
            //Destroy(newObject);
            current++;
        }
    }
}
