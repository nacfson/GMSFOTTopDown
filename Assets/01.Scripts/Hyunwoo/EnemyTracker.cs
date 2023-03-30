using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    [SerializeField]
    private bool tracker = true;
    public LayerMask player;

    void Update()
    {
        transform.Translate(-0.05f,0,0);
        tracker = Physics2D.OverlapCircle(transform.position, 5f, player);

        if(tracker == true)
        {
            transform.Translate(PlayerController.Instance.PlayerPos);
        }
    }
}
