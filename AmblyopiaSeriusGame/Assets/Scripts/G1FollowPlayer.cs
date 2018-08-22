using UnityEngine;

public class G1FollowPlayer : MonoBehaviour {

    public Transform player;

    private void Update()
    {
        if (!PauseBehaviourScript.GameIsPaused)
        {
            if (player.position.x > transform.position.x || player.position.x < transform.position.x)
            {
                transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            }
        }
    }

 


}
