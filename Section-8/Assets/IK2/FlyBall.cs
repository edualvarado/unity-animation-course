using UnityEngine;
using System.Collections;

public class FlyBall : MonoBehaviour {

	float t = 0;
	
	// Update is called once per frame
	void Update () {

		float newX = Mathf.Cos(t);
		float newZ = Mathf.Sin(t);

		this.transform.position = new Vector3(newX, this.transform.position.y, newZ);
		t += 0.001f;
	}
}
