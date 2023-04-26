using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] PlayerSO _playerSO;
    public float shootDelay;

    private void Start()
    {
        shootDelay = _playerSO.shootDelay;
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
                yield return new WaitForSeconds(shootDelay);
            }
            yield return 0;
        }
    }
}
