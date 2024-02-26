using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Teleportables : MonoBehaviour
{
    public PortalGun PortalGun;

    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
            PortalGun.Teleport(this.gameObject, go);
    }
}
