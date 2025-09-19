using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;
    public float branchChance = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        //Start dropping apples
        //Invoke("DropApple", 2f);
        Invoke("DropApple", 2f);
    }

    // void DropItem()
    // {
    //     GameObject itemToDrop;
    //     if (Random.value <= branchChance)
    //     {
    //         itemToDrop = branchPrefab;
    //     }
    //     else
    //     {
    //         itemToDrop = applePrefab;
    //     }

    //     GameObject droppedItem = Instantiate<GameObject>(itemToDrop);
    //     droppedItem.transform.position = transform.position;
    // }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void DropBranch()
    {
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        Invoke("DropBranch", branchChance);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move Right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        // else if (Random.value < changeDirChance)
        // {
        //     speed *= -1;
        // }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
