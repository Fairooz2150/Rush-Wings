using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength, highofFly;
    public ScoreManager score;
    public ShootingScript arrow;
    public TouchArea touchArea;
    public GameObject pauseBtn, flyInstrAnimObj, shootInstrAnimObj;
    public Animator flyAnimation;
    public bool birdIsAlive = true;
    [SerializeField] AudioClip beatWithPipeSound;
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

        bool isFlyingActive = Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W) || touchArea.isTouching;
        bool isShoot = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetMouseButtonDown(1);
        if (isFlyingActive)

        {
            Fly();
        }
        else
        {
            StopFlying();
        }

        if (isShoot)
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
            if (birdIsAlive)
            {
                UISoundManager.Play(beatWithPipeSound);
                gameOver();
            }

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
        if (shootInstrAnimObj)
        {
            Destroy(shootInstrAnimObj);
        }
        if (birdIsAlive)
        {
            arrow.Shoot();
        }

    }
    public void Fly()
    {
        Time.timeScale = 1f;
        if (flyInstrAnimObj)
        {

            Destroy(flyInstrAnimObj);
        }

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
