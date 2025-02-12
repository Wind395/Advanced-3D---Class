using System.Collections;
using UnityEngine;

public class Lesson2 : MonoBehaviour
{
    public Renderer rendererObject;
    
    public float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rendererObject = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(FadeOut());
        }
        
    }

    IEnumerator FadeOut()
    {
        Color startColor = rendererObject.material.color;
        float startAlpha = rendererObject.material.color.a;
        float endAlpha = 0f;
        float duration = 0f;
        
        while (duration < time)
        {
            duration += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, duration / time);
            
            rendererObject.material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            
            yield return null;
        }
        Debug.Log("Done");
    }
    
}
