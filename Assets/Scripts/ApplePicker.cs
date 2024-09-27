using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -15f;
    public float basketSpacingY = -1.5f;

    public List<GameObject> basketList;

    public float appleDropSpeed = 1.0f;

    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY - (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    void Update()
    {
        // Logic for controlling apple drop speed can be implemented here if needed
    }

    // Method to set the width of all baskets
    public void SetBasketWidth(float newWidth)
    {
        foreach (GameObject basket in basketList)
        {
            Basket basketScript = basket.GetComponent<Basket>();
            if (basketScript != null)
            {
                basketScript.SetWidth(newWidth);
            }
        }
    }

    public void SetAppleDropSpeed(float newSpeed)
    {
        appleDropSpeed = newSpeed;
        // You may want to add logic here to adjust the actual dropping speed of apples if needed
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];

        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
