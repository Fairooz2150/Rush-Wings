using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GameObject arrowPrefab;

    [SerializeField] Transform arrowPos;

    [SerializeField] Transform bird;

    [SerializeField] float shootForce = 15f;

    [SerializeField] float reloadTime = 2.5f;

    float currentCooldown = 0f;
    [SerializeField] Image reloadImage;

    void Start()
    {
        currentCooldown = reloadTime;
    }
    void Update()
    {
        //reduce cooldown over time
        if (currentCooldown < reloadTime)
        {
            currentCooldown += Time.deltaTime;

            reloadImage.fillAmount = currentCooldown / reloadTime;

        }
        else
        {
            reloadImage.fillAmount = reloadTime;
        }
    }
    public void Shoot()
    {
        // Block shooting if still cooling down
        if (currentCooldown < reloadTime)
            return;

        GameObject arrow = Instantiate(
            arrowPrefab,
            arrowPos.position,
            arrowPrefab.transform.rotation
        );

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(bird.right * shootForce, ForceMode2D.Impulse);

        //Reset cooldown
        currentCooldown = 0;
    }

}
