using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    float delayTime = 3f;

    void Start()
    {
        StartCoroutine(GenrateEnemy());
    }

    IEnumerator GenrateEnemy()
    {
        while (true)
        {
            GameObject obj = Instantiate(EnemyPrefab, transform.position, transform.rotation);
            obj.transform.SetParent(null);
            yield return new WaitForSeconds(delayTime);
        }
    }
}
