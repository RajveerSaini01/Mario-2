using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private Camera _camera;
    private Ray _ray;
    private RaycastHit _rayCastHit;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootRay();
        }
    }

    private void ShootRay()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _rayCastHit))
        {
            Debug.Log(_rayCastHit.transform.name);
            Destroy(_rayCastHit.transform.gameObject);
             
        }
    }
}
