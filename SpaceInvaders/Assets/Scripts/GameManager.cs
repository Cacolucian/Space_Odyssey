using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public GameObject[] allAlienSets;
    private GameObject currentSet;
    private Vector2 spawnPos = new Vector2(-0.7f, 3);


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }


    public static void CancelGame()
    {
        instance.StopAllCoroutines();

        AlienMaster.allAliens.Clear();
        AlienMaster.redAliens.Clear();
        AlienMaster.column1.Clear();
        AlienMaster.column2.Clear();
        AlienMaster.column3.Clear();
        AlienMaster.column4.Clear();
        AlienMaster.column5.Clear();
        AlienMaster.column6.Clear();
        AlienMaster.column7.Clear();
        AlienMaster.column8.Clear();

        if (instance.currentSet != null)
            Destroy(instance.currentSet);
        UIManager.ResetUI();
    }

    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }



    private IEnumerator SpawnWave()
    {
        AlienMaster.allAliens.Clear();
        AlienMaster.redAliens.Clear();
        AlienMaster.column1.Clear();
        AlienMaster.column2.Clear();
        AlienMaster.column3.Clear();
        AlienMaster.column4.Clear();
        AlienMaster.column5.Clear();
        AlienMaster.column6.Clear();
        AlienMaster.column7.Clear();
        AlienMaster.column8.Clear();

        if (currentSet != null)
            Destroy(currentSet);

        yield return new WaitForSeconds(1);

        currentSet = Instantiate(allAlienSets[Random.Range(0, allAlienSets.Length)], spawnPos, Quaternion.identity);

    }
}
