using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CubeNegative : MonoBehaviour
{
    private bool used = false;
    private void OnTriggerEnter(Collider other)
    {
        if (used) return; 
        if (other.gameObject.CompareTag("Player"))
        {
            used = true;
            other.gameObject.GetComponent<MainCube>().killHer();
        }
        else if (other.gameObject.CompareTag("Positive"))
        {
            used = true;
            Destroy(other.gameObject);
            GameObject.Find("Collector").transform.Translate(0, 1, 0);
        }
    }
}
