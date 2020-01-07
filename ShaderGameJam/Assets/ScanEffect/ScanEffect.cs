using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EagleVision
{
    [ExecuteInEditMode]
    public class ScanEffect : MonoBehaviour
    {
        public Transform playerScanPosition;
        public Material effectMaterial;
        public SendPosition sendpos;

        [Header("Scan Attributes")]
        public float scanDistance;
        public float scanSpeed;

        private Camera _camera;

        bool _scanning;
        Scannable[] _scannables;

        void Start()
        {
            _scannables = FindObjectsOfType<Scannable>();
            sendpos = GetComponent<SendPosition>();
        }

        void Update()
        {
            if (_scanning)
            {
                if (scanDistance < 30)
                {
                    scanDistance += Time.deltaTime * scanSpeed;
                    foreach (Scannable s in _scannables)
                    {
                        if (Vector3.Distance(playerScanPosition.transform.position, s.transform.position) <= scanDistance)
                            s.Ping();
                    }
                    if (scanDistance > 30)
                    {
                        _scanning = false;
                        scanDistance = 0;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                _scanning = true;
                scanDistance = 0;
            }
        }
   }     
}

