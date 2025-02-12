using System.Collections;
using UnityEngine;

public class SunMoon : MonoBehaviour
{
    public Transform center;

    public float duration;
    public float elapsedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(SunMoonSystem());
    }

    IEnumerator SunMoonSystem() 
    {
        transform.LookAt(center);

        transform.RotateAround(center.position, Vector3.right,  360 / duration * Time.deltaTime);
        yield return null;
    }
}
