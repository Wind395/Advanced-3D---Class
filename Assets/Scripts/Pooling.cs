using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pooling : MonoBehaviour
{

    public GameObject objectShowDamage;

    [Header("Pooling")]
    [SerializeField] private GameObject textDamage;
    private List<GameObject> pool;
    [SerializeField] private int poolSize = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject objs = Instantiate(textDamage, transform.position, Quaternion.identity, transform);
            pool.Add(objs);
            objs.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var get = pool.FirstOrDefault(x => !x.gameObject.activeSelf);
            if (get != null)
            {
                get.SetActive(true);
                get.GetComponent<RectTransform>().anchoredPosition = objectShowDamage.transform.position;
                StartCoroutine(DamagePopUp(get.gameObject));
            }
        }
    }

    IEnumerator DamagePopUp(GameObject get)
    {
        yield return new WaitForSeconds(.5f);
        get.SetActive(false);
    }
}
