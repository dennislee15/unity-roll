using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player2Controller : MonoBehaviour
{

    public float speed2;
    public float pushBack;

    public int collision;
    private Rigidbody rb2;

    public Text score2Text;
    public int score2;
    private Transform respawn2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        score2 = 0;
        setCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal1");
        float moveVertical = Input.GetAxis("Vertical1");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb2.AddForce(movement * speed2);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ObjectCollision"))
        {
            //col.gameObject.transform.GetComponent<Renderer>().material.color = Color.red;
            col.gameObject.transform.GetComponent<Renderer>().material.color = rb2.GetComponent<Renderer>().material.color;
            col.gameObject.layer = 2;

            // Add additional force to collisions
            float moveHorizontal = Input.GetAxis("Horizontal1");
            float moveVertical = Input.GetAxis("Vertical1");

            float total_horizontal = moveHorizontal * collision;
            float total_vertical = moveVertical * collision;

            col.gameObject.GetComponent<Rigidbody>().AddForce(total_horizontal, 0, total_vertical);
            //Destroy(col.gameObject);
        }
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
            respawn2 = GameObject.FindWithTag("respawn2").transform;
            transform.position = respawn2.position;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score2 = score2 + 3;
            setCountText();
        }
    }

    public void setCountText()
    {
        score2Text.text = "Player 2 Score: " + score2.ToString();
    }
}
