using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    public CapsuleCollider PlayerCollider;
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private LayerMask _floorLayer;
    [SerializeField] private LayerMask _portalLayer;
    [SerializeField] private GameObject _bluePortalPrefab;
    [SerializeField] private GameObject _redPortalPrefab;

    [SerializeField] private GameObject _bluePortal;
    [SerializeField] private GameObject _redPortal;

    private static PortalGun _instance;
    private void Awake()
    {
        if (_instance == null) { _instance = this; }
        else { Destroy(gameObject); }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootPortal(_bluePortalPrefab, ref _bluePortal);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShootPortal(_redPortalPrefab, ref _redPortal);
        }
    }

    void ShootPortal(GameObject _portalPrefab, ref GameObject portal)
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _wallLayer))
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, hit.normal);
            CreatePortal(_portalPrefab, hit.point, rotation, ref portal);
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _floorLayer))
        {
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            CreatePortal(_portalPrefab, hit.point, rotation, ref portal);
        }
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _portalLayer))
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.right, hit.normal);
            CreatePortal(_portalPrefab, hit.point, rotation, ref portal);
        }
    }

    void CreatePortal(GameObject _portalPrefab, Vector3 position, Quaternion rotation, ref GameObject portal)
    {
        GameObject _newPortal = Instantiate(_portalPrefab, position, rotation);

        if (portal != null) { Destroy(portal); }
        portal = _newPortal;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponent<Rigidbody>() != null)
        {
            Teleport(other.gameObject);
        }
            Debug.Log("aa");
    }
    void Teleport(GameObject teleportObject)
    {

    }
}
