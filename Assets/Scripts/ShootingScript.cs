using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;

    [SerializeField] Transform arrowPos;

    [SerializeField] Transform bird;

    [SerializeField] float shootForce = 15f;

    [SerializeField] float cooldownTime = 2.5f; 

    float currentCooldown = 0f;


    void Update()
    {
        //reduce cooldown over time
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
       // Block shooting if still cooling down
       if (currentCooldown > 0)
        return;

        GameObject arrow = Instantiate(
            arrowPrefab,
            arrowPos.position,
            arrowPrefab.transform.rotation
        );

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(bird.right * shootForce, ForceMode2D.Impulse);

        //Reset cooldown
        currentCooldown = cooldownTime;
    }

}
