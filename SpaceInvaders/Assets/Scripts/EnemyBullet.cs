using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int scoreValue;
    int dmg;
    private float speed = 2;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            

            
            if (AlienMaster.random == 1)
            {
                dmg = AlienMaster.column1.Count;
            }
            if (AlienMaster.random == 2)
            {
                dmg = AlienMaster.column2.Count;
            }
            if (AlienMaster.random == 3)
            {
                dmg = AlienMaster.column3.Count;
            }
            if (AlienMaster.random == 4)
            {
                dmg = AlienMaster.column4.Count;
            }
            if (AlienMaster.random == 5)
            {
                dmg = AlienMaster.column5.Count;
            }
            if (AlienMaster.random == 6)
            {
                dmg = AlienMaster.column6.Count;
            }
            if (AlienMaster.random == 7)
            {
                dmg = AlienMaster.column7.Count;
            }
            if (AlienMaster.random == 8)
            {
                dmg = AlienMaster.column8.Count;
            }

            UIManager.UpdateScore(scoreValue-dmg);
            MenuManage.OpenGameOver();
            
        }
    }
}

