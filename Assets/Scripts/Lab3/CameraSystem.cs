using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public CinemachineCamera[] cinemachineCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cinemachineCamera[0].Priority = 0;
            cinemachineCamera[1].Priority = 1;
        }
    }

    [System.Obsolete]
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cinemachineCamera[0].Priority = 1;
            cinemachineCamera[1].Priority = 0;
        }
    }
    
}
