using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength, highofFly;
    public ScoreManager score;
    public ShootingScript arrow;
    public TouchArea touchArea;
    public GameObject pauseBtn;
    public Animator flyAnimation;
    public bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        arrow = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootingScript>();
        touchArea = GameObject.FindGameObjectWithTag("Touch Area").GetComponent<TouchArea>();

        Time.timeScale = 0f;

    }

    // Update is called once per frame
    void Update()
    {

        bool isFlyingActive = Input.GetKey(KeyCode.Space) || touchArea.isTouching;

        if (isFlyingActive)

        {
            Fly();
        }
        else
        {
            StopFlying();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShootArrow();
        }


        // if ((transform.position.y >= highofFly || transform.position.y <= -highofFly) && birdIsAlive)
        // {
        //     gameOver();

        // }
        if (Mathf.Abs(transform.position.y) >= highofFly && birdIsAlive)
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
        pauseBtn.SetActive(false);
        myRigidbody.constraints = RigidbodyConstraints2D.None;
    }

    public void ShootArrow()
    {
        if (birdIsAlive)
        {

            arrow.Shoot();
        }

    }
    public void Fly()
    {
        Time.timeScale = 1f;

        if (birdIsAlive)
        {

            myRigidbody.velocity = Vector2.up * flapStrength;

            flyAnimation.SetTrigger("Fly");
        }
        else
        {
            flyAnimation.SetTrigger("Idle");

        }
    }
    public void StopFlying()
    {
        flyAnimation.SetTrigger("Idle");
    }
}
