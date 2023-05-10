using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] PlayerSO playerSO;
    Transform firePosTrm;
    public float shootDelay;

    private void Awake()
    {
        firePosTrm = transform.Find("Gun/FirePos").GetComponent<Transform>();
    }

    private void Start()
    {
        shootDelay = playerSO.shootDelay;
        StartCoroutine(ShootBullet());
    }

    IEnumerator ShootBullet()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(BulletPrefab, firePosTrm.position, firePosTrm.rotation);
                yield return new WaitForSeconds(shootDelay);
            }
            yield return 0;
        }
    }
}
