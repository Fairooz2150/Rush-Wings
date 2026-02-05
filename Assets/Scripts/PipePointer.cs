using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePointer : MonoBehaviour
{

    public Transform bottomPipe;
    [SerializeField] float moveAmount = 12.4f;
    [SerializeField] float moveSpeed = 2f;

    bool shouldMove = false;
    float targetY;



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("down the pipe");
            Destroy(collision.gameObject);
            targetY = bottomPipe.position.y - moveAmount;
            shouldMove = true;
        }
    }
    void Update()
    {
        if (shouldMove)
        {
            Vector3 pos = bottomPipe.position;

            pos.y = Mathf.MoveTowards(pos.y, targetY, moveSpeed * Time.deltaTime);

            bottomPipe.position = pos;

            if (Mathf.Approximately(pos.y, targetY))
            {
                shouldMove = false; 
            }
        }
    }
}
