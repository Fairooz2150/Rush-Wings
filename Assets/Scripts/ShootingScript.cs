using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform bird;
    [SerializeField] float shootForce = 15f;


    public void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, new Vector3 (0f,0f,0f), bird.rotation);

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(bird.right * shootForce, ForceMode2D.Impulse);
    }
}
