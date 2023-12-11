using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private GameObject _bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(_bullet, _shootPosition.transform.position, transform.rotation);
        }
    }
}