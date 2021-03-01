using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue;
    public string[] objTags;

    public GameObject explosion;

    public void Kill()
    {
        UIManager.UpdateScore(scoreValue);

        AlienMaster.column1.Remove(gameObject);
        AlienMaster.column2.Remove(gameObject);
        AlienMaster.column3.Remove(gameObject);
        AlienMaster.column4.Remove(gameObject);
        AlienMaster.column5.Remove(gameObject);
        AlienMaster.column6.Remove(gameObject);
        AlienMaster.column7.Remove(gameObject);
        AlienMaster.column8.Remove(gameObject);
        AlienMaster.allAliens.Remove(gameObject);
        AlienMaster.redAliens.Remove(gameObject);

        Instantiate(explosion, transform.position, Quaternion.identity);



        Destroy(gameObject);
    }


}
