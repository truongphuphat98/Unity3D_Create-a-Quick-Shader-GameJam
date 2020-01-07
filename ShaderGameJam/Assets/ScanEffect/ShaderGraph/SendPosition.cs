using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SendPosition : MonoBehaviour
{
	public float radius = 1f;
	public float thin = 1f;
	public Color color = Color.red;

	void Update () {
		Shader.SetGlobalVector("_Target", transform.position);
		Shader.SetGlobalFloat("_Radius", radius);
		Shader.SetGlobalFloat("_Thin", thin);
		Shader.SetGlobalColor("_Color", color);
	}
}
