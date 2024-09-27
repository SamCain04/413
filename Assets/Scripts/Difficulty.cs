using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    public ApplePicker applePicker; // Reference to the ApplePicker
    public AppleTree appleTree; // Reference to the AppleTree

    // Define difficulty levels
    private float[] dropSpeeds = { 1.0f, 0.75f, 0.5f }; // Speed values for easy, medium, hard
    private float[] basketWidths = { 4.0f, 3.0f, 2.0f }; // Width values for easy, medium, hard

    public void OnButtonClick(int difficultyLevel)
    {
        if (difficultyLevel < 0 || difficultyLevel >= dropSpeeds.Length)
            return; // Ensure valid level

        applePicker.SetBasketWidth(basketWidths[difficultyLevel]); // Set the basket width
        appleTree.SetAppleDropDelay(dropSpeeds[difficultyLevel]); // Set the apple drop speed
    }
}
