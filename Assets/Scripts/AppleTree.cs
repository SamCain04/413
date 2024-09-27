using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab; // Apple prefab reference linked via the editor
    public float speed = 1f; // Speed of the tree
    public float leftAndRightEdge = 10f; // Distance tree moves before turning
    public float changeDirChance = 0.1f; // Chance of direction change
    public float appleDropDelay = 1f; // Interval between apple spawns

    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    // Method to set the apple drop delay
    public void SetAppleDropDelay(float newDelay)
    {
        appleDropDelay = newDelay;
        CancelInvoke("DropApple"); // Cancel any existing invokes
        Invoke("DropApple", appleDropDelay); // Start the new delay
    }
}
