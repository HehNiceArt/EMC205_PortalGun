using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float HP = 100f;
    public GameObject self;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Teleportables"))
        {
            HP -= 50f;
            if(HP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
