using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    [Header("Setup")]
    [SerializeField] GameObject backgroundPrefab;
    [SerializeField] int poolsize = 3;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 2f;

    float backgroundWidth;

    Queue<GameObject> backgrounds = new Queue<GameObject>();

    void Start()
    {
        // Get Width automatically
        backgroundWidth = backgroundPrefab.GetComponent<SpriteRenderer>().bounds.size.x;

        //Spawn initial backgrounds
        for (int i = 0; i < poolsize; i++)
        {
            SpawnBackground(i * backgroundWidth);
        }
    }

    void Update()
    {
        MoveBackgrounds();
        RecycleBackground();
    }

    // Move all background left
    void MoveBackgrounds()
    {
        foreach (GameObject bg in backgrounds)
        {
            bg.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
    }

    void RecycleBackground()
    {
        GameObject firstBG = backgrounds.Peek();

        //If completely off screen (left side)
        if (firstBG.transform.position.x <= -backgroundWidth)
        {
            GameObject lastBG = GetLastBackground();

            //move first to the end
            firstBG.transform.position = new Vector3(lastBG.transform.position.x + backgroundWidth, firstBG.transform.position.y, firstBG.transform.position.z);

            //Update queue order
            backgrounds.Dequeue();
            backgrounds.Enqueue(firstBG);

        }
    }

    //Spawn new background
    void SpawnBackground(float xPos)
    {
        GameObject bg = Instantiate(backgroundPrefab, new Vector3(xPos, 0, 0), Quaternion.identity);
        backgrounds.Enqueue(bg);
    }

    //GameObject Get las tBackground in queue
    GameObject GetLastBackground()
    {
        GameObject last = null;
        foreach (var bg in backgrounds)
        {
            last = bg;
        }
        return last;
    }
}
