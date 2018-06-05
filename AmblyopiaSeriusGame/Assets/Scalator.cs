
using UnityEngine;

public class Scalator : MonoBehaviour {

    public float speed = 00f;
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector2(speed * Time.deltaTime, speed * Time.deltaTime);
	}
}
