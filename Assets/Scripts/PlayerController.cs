using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody player;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Image winloseImage;
    public Text winloseText;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            player.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("q") || Input.GetKey("left"))
        {
            player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("z") || Input.GetKey("up"))
        {
            player.AddForce(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            player.AddForce(0, 0, -speed * Time.deltaTime);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }
        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            SetWinblaka();
            winloseImage.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }
    void Update()
    {
        if (health == 0)
        {
            Setloseblaka();
            winloseImage.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(0);

    }
    void SetScoreText()
    {
        scoreText.text = "Score:" + this.score;
    }
    void SetHealthText()
    {
        healthText.text = "Health:" + this.health;
    }
    void SetWinblaka()
    {
        winloseText.color = Color.black;
        winloseText.text = "You win!";
        winloseImage.color = Color.green;
    }
    void Setloseblaka()
    {
        winloseText.color = Color.white;
        winloseText.text = "Game Over!";
        winloseImage.color = Color.red;
    }
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Maze");
        score = 0;
        health = 5;
    }
}
