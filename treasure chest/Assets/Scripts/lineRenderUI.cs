using UnityEngine;
using System.Collections;

public class lineRenderUI : MonoBehaviour {
public Color c1 = Color.white;
public Color c2 = new Color(1, 1, 1, 0);
public bool useWorldSpace;
public GameObject player;
public int lengthOfLineRenderer = 20;

	// Use this for initialization
	void Start () {
		print(player.name);
		LineRenderer lineRender = gameObject.AddComponent<LineRenderer> ();
		lineRender.useWorldSpace = false;
		lineRender.material = new Material (Shader.Find ("Particles/Additive"));
		lineRender.SetColors (c1, c2);
		lineRender.SetVertexCount (lengthOfLineRenderer);
	}
	
	// Update is called once per frame
	void Update () {
		LineRenderer lineRender = GetComponent<LineRenderer>();
		Vector3[] points = new Vector3[lengthOfLineRenderer];
		float t = Time.time;
		int i = 0;
		while (i < lengthOfLineRenderer) {
			points[i] = new Vector3(i * 0.5f, Mathf.Sin (i + t), 0);
			i++;

}
		lineRender.SetPositions(points);
}

}