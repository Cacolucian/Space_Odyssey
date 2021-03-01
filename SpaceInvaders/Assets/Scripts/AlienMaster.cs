using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AlienMaster : MonoBehaviour
{
    public GameObject bullet;

    private Vector3 hMoveDistance = new Vector3(0.05f, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0.2f, 0);

    private const float right_border = 1.0f;
    private const float left_border = -1.0f;
    private const float max_move_speed = 0.05f;
    private const float max_shoot_speed = 0.1f;
    private const float START_Y = 1.2f;
    private const float FINISH_Y = -1.2f;

    private float moveTimer = 0.01f;
    private const float moveTime = 0.02f;

    private float shootTimer;
    private const float shootTime = 0.03125f;

    public static List<GameObject> allAliens = new List<GameObject>();
    public static List<GameObject> redAliens = new List<GameObject>();

    public static List<GameObject> column1 = new List<GameObject>();
    public static List<GameObject> column2 = new List<GameObject>();
    public static List<GameObject> column3 = new List<GameObject>();
    public static List<GameObject> column4 = new List<GameObject>();
    public static List<GameObject> column5 = new List<GameObject>();
    public static List<GameObject> column6 = new List<GameObject>();
    public static List<GameObject> column7 = new List<GameObject>();
    public static List<GameObject> column8 = new List<GameObject>();



    private bool movingRight;
    private bool entering = true;
    public static int random;







    // Start is called before the first frame update
    void Start()
    {

        GameObject red1 = GameObject.Find("alien1");
        GameObject red2 = GameObject.Find("alien1 (1)");
        GameObject red3 = GameObject.Find("alien1 (2)");
        GameObject red4 = GameObject.Find("alien1 (3)");
        GameObject red5 = GameObject.Find("alien1 (4)");
        GameObject red6 = GameObject.Find("alien1 (5)");
        GameObject red7 = GameObject.Find("alien1 (6)");
        GameObject red8 = GameObject.Find("alien1 (7)");
        GameObject white1 = GameObject.Find("alien2");
        GameObject white2 = GameObject.Find("alien2 (1)");
        GameObject white3 = GameObject.Find("alien2 (2)");
        GameObject white4 = GameObject.Find("alien2 (3)");
        GameObject white5 = GameObject.Find("alien2 (4)");
        GameObject white6 = GameObject.Find("alien2 (5)");
        GameObject white7 = GameObject.Find("alien2 (6)");
        GameObject white8 = GameObject.Find("alien2 (7)");
        GameObject white9 = GameObject.Find("alien2 (8)");
        GameObject white10 = GameObject.Find("alien2 (9)");
        GameObject white11 = GameObject.Find("alien2 (10)");
        GameObject white12 = GameObject.Find("alien2 (11)");
        GameObject white13 = GameObject.Find("alien2 (12)");
        GameObject white14 = GameObject.Find("alien2 (13)");
        GameObject white15 = GameObject.Find("alien2 (14)");
        GameObject white16 = GameObject.Find("alien2 (15)");
        GameObject white17 = GameObject.Find("alien2 (16)");
        GameObject white18 = GameObject.Find("alien2 (17)");
        GameObject white19 = GameObject.Find("alien2 (18)");
        GameObject white20 = GameObject.Find("alien2 (19)");
        GameObject white21 = GameObject.Find("alien2 (20)");
        GameObject white22 = GameObject.Find("alien2 (21)");
        GameObject white23 = GameObject.Find("alien2 (22)");
        GameObject white24 = GameObject.Find("alien2 (23)");
        redAliens.Add(red1);
        redAliens.Add(red2);
        redAliens.Add(red3);
        redAliens.Add(red4);
        redAliens.Add(red5);
        redAliens.Add(red6);
        redAliens.Add(red7);
        redAliens.Add(red8);

        column1.Add(red1);
        column1.Add(white1);
        column1.Add(white9);
        column1.Add(white17);

        column2.Add(red2);
        column2.Add(white2);
        column2.Add(white10);
        column2.Add(white18);

        column3.Add(red3);
        column3.Add(white3);
        column3.Add(white11);
        column3.Add(white19);

        column4.Add(red4);
        column4.Add(white4);
        column4.Add(white12);
        column4.Add(white20);

        column5.Add(red5);
        column5.Add(white5);
        column5.Add(white13);
        column5.Add(white21);

        column6.Add(red6);
        column6.Add(white6);
        column6.Add(white14);
        column6.Add(white22);

        column7.Add(red7);
        column7.Add(white7);
        column7.Add(white15);
        column7.Add(white23);

        column8.Add(red8);
        column8.Add(white8);
        column8.Add(white16);
        column8.Add(white24);





        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
        {
            //Debug.Log(go.ToString());
            allAliens.Add(go);
            //Debug.Log(allAliens);
        }


    }

    // Update is called once per frame
    void Update()
    {



        if (entering)
        {
            
            transform.Translate(Vector2.down * Time.deltaTime * 1);

            if (transform.position.y <= START_Y)
                entering = false;
        }



        else
        {
            if (moveTimer <= 0)
                MoveEnemies();

            if (shootTimer <= 0)
                
                    Shoot();


                



            moveTimer -= Time.deltaTime;
            shootTimer -= Time.deltaTime;
        }
        
    }

    private void MoveEnemies()
    {
        if(allAliens.Count > 0)
        {
            int hitMax = 0;

            for (int i =0; i < allAliens.Count; i++)
            {
                if (movingRight)
                    allAliens[i].transform.position += hMoveDistance;
                else
                    allAliens[i].transform.position -= hMoveDistance;

                if (allAliens[i].transform.position.x > right_border || allAliens[i].transform.position.x < left_border)
                    hitMax++;
                if (allAliens[i].transform.position.y <= FINISH_Y)
                {
                    MenuManage.OpenGameOver();
                    Debug.Log("BORDER");
                }
            }

            if(hitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                
                    allAliens[i].transform.position -= vMoveDistance;

                    movingRight = !movingRight;
                
            }

            moveTimer = GetMoveSpeed();

        }

        if (allAliens.Count <= 0)
        {
            MenuManage.OpenGameOver();
        }


    }

    public void Shoot()
    {

            random = Random.Range(0, redAliens.Count);
            Vector2 pos = redAliens[random].transform.position;
            //Debug.Log(pos);
            //foreach ( var x in redAliens)
            //{
            //Debug.Log("liczba kosmitow" + x.ToString());
            //}
            

            Instantiate(bullet, pos, Quaternion.identity);

            //Debug.Log("SPEED  " + GetShootSpeed());
            shootTimer = Random.Range(4, 7) * GetShootSpeed();
            //Debug.Log("SHOOTTIME" + shootTimer);
        





    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;
 



        if (f < max_move_speed)
            return max_move_speed;
        else
            return f;
    }

    private float GetShootSpeed()
    {

        float g = allAliens.Count * shootTime;
        if (g < max_shoot_speed)
            return max_shoot_speed;
        else
            return g;
    }
}
