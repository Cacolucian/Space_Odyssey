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

    //void OnLevelComplete()
    //{
    //    levelComplete = true;
    //    score = 10000; //values from your scoring logic
    //    for (int i = 1; i <= 5; i++) //for top 5 highscores
    //    {
    //        if (PlayerPrefs.GetInt("highscorePos" + i) < score)     //if cuurent score is in top 5
    //        {
    //            temp = PlayerPrefs.GetInt("highscorePos" + i);     //store the old highscore in temp varible to shift it down 
    //            PlayerPrefs.SetInt("highscorePos" + i, score);     //store the currentscore to highscores
    //            if (i < 5)                                        //do this for shifting scores down
    //            {
    //                int j = i + 1;
    //                PlayerPrefs.SetInt("highscorePos" + j, temp);
    //            }
    //        }
    //    }
    //}

    //void OnGUI()
    //{
    //    if (levelComplete)
    //    {
    //        for (int i = 1; i <= 5; i++)
    //        {
    //            GUI.Box(new Rect(100, 75 * i, 150, 50), "Pos " + i + ". " + PlayerPrefs.GetInt("highscorePos" + i));
    //        }
    //    }
    //}
}