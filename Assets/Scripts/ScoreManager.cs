using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    GUIText text;

    void Awake ()
    {
        text = GetComponent <GUIText> ();
        score = 0;
    }

    void Update ()
    {
        text.text = "SCORE: " + score;
    }

}