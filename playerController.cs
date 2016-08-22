using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerController : MonoBehaviour {

    public float speed;
    public float collision;
    public float pushBack;

    public Text countText;

    private Rigidbody rb;
    public int score1;
    private Transform respawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score1 = 0;
        setCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            score1 = score1 + 3;
            setCountText();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ObjectCollision"))
        {
            col.gameObject.transform.GetComponent<Renderer>().material.color = rb.GetComponent<Renderer>().material.color;
            col.gameObject.layer = 1;
            //col.gameObject.GetComponent<objectCollision>();

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            float total_horizontal = moveHorizontal * collision;
            float total_vertical = moveVertical * collision;

            col.gameObject.GetComponent<Rigidbody>().AddForce(total_horizontal, 0, total_vertical);
            //Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Wall")
        {
            add_collision_force(col);
        }
        else if (col.gameObject.name == "floor")
        {
            respawnPosition = GameObject.FindWithTag("Respawn").transform;
            transform.position = respawnPosition.position;
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

    public void setCountText()
    {
        countText.text = "Player 1 Score: " + score1.ToString();
    }

}
