using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3 : MonoBehaviour
{

    public List<GameObject> gameObjects;
    public List<GameObject> wayPoints;

    public float duration;
    
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveObjects());

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(ScaleObjects());
        }
    }

    IEnumerator MoveObjects()
    {
        float elapsedTime = 0;
        for (int i = 0; i < gameObjects.Count; i++)
        {
            elapsedTime += Time.deltaTime;
            gameObjects[i].transform.position = Vector3.Lerp(gameObjects[i].transform.position, wayPoints[i].transform.position, elapsedTime / duration);
            yield return new WaitForSeconds(1f);
            gameObjects[i].transform.position = wayPoints[i].transform.position;
        }
    }

    IEnumerator ScaleObjects()
    {
        float elapsedTime = 0;
        for (int i = 0; i < gameObjects.Count; i++)
        {
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                gameObjects[i].transform.localScale = Vector3.Lerp(gameObjects[i].transform.localScale, new Vector3(5f, 5f, 5f), elapsedTime / duration);
                yield return null;
            }

            elapsedTime = 0;
        }
    }
}
