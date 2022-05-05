using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody player;
    private int score = 0;
    public int health = 5;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            player.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("q") || Input.GetKey("left"))
        {
            player.AddForce(-speed * Time.deltaTime, 0 , 0);
        }
        if (Input.GetKey("z") || Input.GetKey("up"))
        {
            player.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            player.AddForce(0 , 0, -speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }
        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
