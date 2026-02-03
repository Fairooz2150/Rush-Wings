using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePointer : MonoBehaviour
{

    public Transform bottomPipe;
    [SerializeField] float moveAmount = 12.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer==6)
        {
            Debug.Log("down the pipe");
           Vector3 pos = bottomPipe.position;
           pos.y -= moveAmount;
           bottomPipe.position = pos;
        }
    }
}
