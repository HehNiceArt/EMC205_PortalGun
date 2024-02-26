using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSpheres : MonoBehaviour
{
    public GameObject Sphere;
    public Transform Player;
    Rigidbody body;
    private void Start()
    {
       body = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Sphere, Player.position * 1f, Quaternion.identity);
        }
    }

}
