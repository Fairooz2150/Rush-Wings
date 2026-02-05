using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
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

        if(Input.GetKeyDown(KeyCode.RightArrow) && birdIsAlive)
        {
            arrow.Shoot();
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Pipe")
    //     {
    //         score.showGameOver();
    //         birdIsAlive = false;
    //     }
    // }
}
