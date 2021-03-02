using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour
{
    public bool levelComplete;
    public string highscorePos;
    public int score;
    public int temp;

    void Start()
    {
        score = 0;
    }

}