using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanable : MonoBehaviour
{
    public bool scanned;
    public GameObject obj;

    void Start()
    {
        obj.SetActive(false);
    }

    public void Scanned()
    {
        scanned = true;
        obj.SetActive(true);
    }
}
