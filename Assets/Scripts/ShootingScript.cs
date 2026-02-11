using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    GameObject arrowPrefab;

    [SerializeField]
    Transform arrowPos;

    [SerializeField]
    Transform bird;

    [SerializeField]
    float shootForce = 15f;

    public void Shoot()
    {
        // Vector3 birdPos = bird.position;

        // birdPos.y -= 2f;

        GameObject arrow = Instantiate(
            arrowPrefab,
            arrowPos.position,
            arrowPrefab.transform.rotation
        );

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(bird.right * shootForce, ForceMode2D.Impulse);
    }
}
