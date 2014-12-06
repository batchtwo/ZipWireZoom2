using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static float timeOfDay; // 0 - 100


    GUIText text;

    void Awake ()
    {
        text = GetComponent <GUIText> ();
        score = 0;
        timeOfDay = 1.4f;
    }

    void Update ()
    {
        score +=1;
        timeOfDay -= 0.0012f;
        text.text = "DISTANCE: " + score + "m";
    }

}