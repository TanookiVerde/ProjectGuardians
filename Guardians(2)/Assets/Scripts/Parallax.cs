using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	private float offset;
	private Material background;

	void Start () 
	{
		background = GetComponent<Renderer> ().material;
	}

	void Update () 
	{
		offset += 0.001f;
		background.SetTextureOffset ("_MainTex", new Vector3 (offset * 4, 0,0));
	}
}
