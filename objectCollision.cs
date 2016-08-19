using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class objectCollision : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public float pushBack;
    public int playerCol;

    public playerController player1;
    public player2Controller player2;

    private Transform respawnPoint;

	// Use this for initialization
	void Start () {
        
	}

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "southWall")
        {
            add_collision_force(col);
        }
        else if (col.gameObject.name == "northWall")
        {
            add_collision_force(col);
        }
        else if (col.gameObject.name == "eastWall")
        {
            add_collision_force(col);
        }
        else if (col.gameObject.name == "westWall")
        {
            add_collision_force(col);
        }
        else if (col.gameObject.name == "floor")
        {
            if (this.gameObject.layer == 1)
            {
                player1.score1 += 5;
                player1.setCountText();
                Destroy(this.gameObject);
            }
            else if (this.gameObject.layer == 2)
            {
                player2.score2 += 5;
                player2.setCountText();
                Destroy(this.gameObject);
            }
            else
            {
                respawnPoint = GameObject.FindWithTag("ballRespawn").transform;
                transform.position = respawnPoint.position;
            }

        }
    }

    void add_collision_force(Collision c)
    {
        // Calculate Angle Between the collision point and the player
        Vector3 dir = c.contacts[0].point - transform.position;
        // We then get the opposite (-Vector3) and normalize it
        dir = -dir.normalized;
        // And finally we add force in the direction of dir and multiply it by force. 
        // This will push back the player
        GetComponent<Rigidbody>().AddForce(dir * pushBack);
    }
}
