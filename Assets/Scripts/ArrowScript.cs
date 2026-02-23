using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            Debug.Log("Touched collider");
            if (gameObject.layer != 0)
            {
                gameObject.layer = 0;
            }

        }

    }

    void Start()
    {
        GameObject arrow = gameObject;
        StartCoroutine(DestroyObject(arrow));
    }


    IEnumerator DestroyObject(GameObject arrow)
    {
        yield return new WaitForSeconds(5f);
        Destroy(arrow);
    }



}
