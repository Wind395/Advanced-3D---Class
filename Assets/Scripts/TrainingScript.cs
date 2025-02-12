using System.Collections;
using UnityEngine;

public class TrainingScript : MonoBehaviour
{

    public Transform target;

    public float duration;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveAndAttack());
    }

    IEnumerator MoveAndAttack()
    {
        float elapsedTime = 0;
        transform.LookAt(target);
        yield return new WaitForSeconds(1f);
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target.position, elapsedTime / duration);
        }
        transform.position = target.position;
        yield return new WaitForSeconds(1f);
        Debug.Log("Attack");
    }
}
