using System;
using System.Collections;
using UnityEngine;

public class TrainingScript2 : MonoBehaviour
{
    
    bool isMoving = false;
    private int count = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(HamChinh());
    }

    IEnumerator HamChinh()
    {
        isMoving = true;
        yield return StartCoroutine(DiChuyen());
        yield return new WaitUntil(() => !isMoving);
        yield return new WaitUntil(Dem);
    }

    IEnumerator DiChuyen()
    {
        Debug.Log("DiChuyen");
        yield return new WaitForSeconds(2f);
        isMoving = false;
    }

    bool Dem()
    {
        if (count < 100)
        {
            count++;
            print("Dem: " + count);
            return false;
        }
        return true;
    }
}
