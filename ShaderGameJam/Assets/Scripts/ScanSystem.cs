using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanSystem : MonoBehaviour
{
    public SphereCollider col;
    public float timeAfterScan;
    float curRadius;

    public float growSpeed;

    float radius;
    bool scanning;
    string tagg;

    public float thin = .11f;
    public Color color = Color.red;

    void Start()
    {
        scanning = false;
        Shader.SetGlobalFloat("_Thin", 0);
        Shader.SetGlobalFloat("_Radius", 0);
        radius = col.radius;
        col.radius = 0;
    }

    void Update()
    {
        if (!scanning && Input.GetKeyDown(KeyCode.B))
        {
            LaunchScan("scannable");
        }
    }

    public void LaunchScan(string tagg)
    {
        this.tagg = tagg;
        StartCoroutine(ScanProgressively());
    }

    IEnumerator ScanProgressively()
    {
        Shader.SetGlobalFloat("_Thin", thin);
        Shader.SetGlobalColor("_Color", color);

        scanning = true;
        curRadius = 0.0f;
        while (curRadius < radius)
        {
            Shader.SetGlobalVector("_Target", transform.position);
            Shader.SetGlobalFloat("_Radius", (curRadius / radius) * 10f);
            curRadius += growSpeed;
            col.radius = curRadius;
            yield return null;
        }
        Shader.SetGlobalFloat("_Thin", 0);
        Shader.SetGlobalFloat("_Radius", 0);
        yield return new WaitForSeconds(timeAfterScan);
        col.radius = 0.0f;
        scanning = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (!scanning)
            return;
        Debug.Log("ici");
        Scanable s = other.gameObject.GetComponent<Scanable>();
           if (s)
                s.Scanned();

    }
}
