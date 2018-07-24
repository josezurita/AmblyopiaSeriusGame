using UnityEngine;

public class FigureBehaviour : MonoBehaviour {

    private Vector3 randomVector;
    private new Rigidbody2D rigidbody2D;
    public float magnitud;
    public bool diferente;
    public Sprite[] sprites;

    // Use this for initialization
    void Start () {
        int x = Random.Range(-10, 10);
        int y = Random.Range(-10, 10);
        randomVector = new Vector3(x, y);
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = (Vector3.ClampMagnitude(randomVector,0.5f)*magnitud);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (diferente && Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.touchCount);
        }
    }

    public void setSprite(int figura, int color)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[(figura*4)+color];
    }
}
