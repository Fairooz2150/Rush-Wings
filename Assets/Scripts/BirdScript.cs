using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength, highofFly;
    public ScoreManager score;
    public ShootingScript arrow;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        arrow = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)

        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && birdIsAlive)
        {
            arrow.Shoot();
        }


        // if ((transform.position.y >= highofFly || transform.position.y <= -highofFly) && birdIsAlive)
        // {
        //     gameOver();

        // }
        if (Mathf.Abs(transform.position.y)>=highofFly && birdIsAlive)
        {
            gameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Pointer")
        {
            gameOver();
        }
    }

    void gameOver()
    {
        score.showGameOver();
        birdIsAlive = false;
        myRigidbody.constraints = RigidbodyConstraints2D.None;
    }
}
