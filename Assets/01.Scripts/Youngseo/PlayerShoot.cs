using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float delayTime = 0.1f;

    private void Start()
    {
        StartCoroutine(ShootBullet());
    }

    IEnumerator ShootBullet()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject obj = Instantiate(BulletPrefab, transform.position, transform.rotation);
                obj.transform.SetParent(null);
                yield return new WaitForSeconds(delayTime);
            }
            yield return 0;
        }
    }
}
