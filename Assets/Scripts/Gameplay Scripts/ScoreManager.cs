using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    // Script to keep track of the score and time of day

    public static int score;
    public static float timeOfDay; // -0.1 - 1.5

    // Text printed on screen displaying distance score
    GUIText text;

    void Awake ()
    {
        // Set values
        text = GetComponent <GUIText> ();
        score = 0;
        timeOfDay = 1.4f;
    }

    void Update ()
    {
        // Clamp the time.
        // Buffer of 1.5 so there is some normal day time before sunsets.
        // Likewise other way just as a safety net.
        timeOfDay = Mathf.Clamp(timeOfDay, -0.1f, 1.5f);

        // If it isn't game over:
        if (!GameOverManager.gameOver)
        {
            // Constantly increment the distance
            score +=1;
            // Decrement the time of day
            timeOfDay -= 0.0015f; // 0.0015
            // Print out the score in metres
            text.text = "DISTANCE: " + score + "m";
        }
    }
}