using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    

    public TextMeshProUGUI highscoreText;
    public Text highscore;
    public Text highscore_2;
    //public Text highscore_3;
    //public Text highscore_4;
    //public Text highscore_5;
    //private int highsScoreInt;
    public bool update;
    public Text countGames;
    private int launchCount;


    public int temp;

    public static UIManager instance;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public static void UpdateScore(int s)
    {
        instance.score += s;
        instance.scoreText.text = instance.score.ToString("000");
    }

    public static void ResetUI()
    {
        instance.score = 0;
        instance.scoreText.text = instance.score.ToString("000");
    }

    public static void UpdateHighscore()
    {

        instance.launchCount = PlayerPrefs.GetInt("TimesLaunched", 0);
        instance.countGames.text = instance.launchCount.ToString();
        Debug.Log(instance.score);

        instance.highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        instance.highscore_2.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        int number = instance.score;
        if (number > PlayerPrefs.GetInt("Highscore", 0))
        {


            PlayerPrefs.SetInt("Highscore", number);
            instance.highscore.text = instance.score.ToString();
            instance.highscore_2.text = instance.score.ToString();

        }



        //for (int i = 1; i <= 5; i++) //for top 5 highscores
        //{
        //    if (PlayerPrefs.GetInt("highscorePos" + i) < instance.score)     //if cuurent score is in top 5
        //    {
        //        instance.temp = PlayerPrefs.GetInt("highscorePos" + i);     //store the old highscore in temp varible to shift it down 
        //        PlayerPrefs.SetInt("highscorePos" + i, instance.score);     //store the currentscore to highscores
        //        if (i < 5)                                        //do this for shifting scores down
        //        {
        //            int j = i + 1;
        //            PlayerPrefs.SetInt("highscorePos" + j, instance.temp);
        //        }
        //    }
        //}





        //instance.highScore_1.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        //instance.highScore_2.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        //instance.highScore_3.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        //instance.highScore_4.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        //instance.highScore_5.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

        //int newScore = instance.score;
        //for (int i = 1; i <= 5; i++)
        //{
        //    if (newScore > PlayerPrefs.GetInt("highScore_" + i))
                
        //    {
                
        //        for (int x = 5; x > i; x--)
        //        {
                    
        //            int value = PlayerPrefs.GetInt("highScore_" + (x - 1));
                    
        //            PlayerPrefs.SetInt("highScore_" + x, value);

                    
        //            instance.highscore_1.text = value.ToString();
                    
        //        }
        //        break;
        //    }
        //}
    }
    public static void CountGames()
    {


        instance.launchCount = PlayerPrefs.GetInt("TimesLaunched", 0);


        instance.launchCount = instance.launchCount + 1;


        PlayerPrefs.SetInt("TimesLaunched", instance.launchCount);
        instance.countGames.text = instance.launchCount.ToString();



    }


}
