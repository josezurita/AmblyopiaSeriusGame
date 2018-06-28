using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;

    private void Update()
    {

        if (player.position.x > transform.position.x || player.position.x < transform.position.x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }

 


}
