using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    private Vector3 originalScale; // Store the original scale

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        originalScale = transform.localScale; // Store the original scale for resetting
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        GameObject collideWith = coll.gameObject;
        if (collideWith.CompareTag("Apple"))
        {
            Destroy(collideWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }

    // Method to adjust the width of the basket
    public void SetWidth(float newWidth)
    {
        newWidth = Mathf.Max(newWidth, 0.5f); // Prevent width from going below a certain value
        transform.localScale = new Vector3(newWidth, originalScale.y, originalScale.z);
    }
}
