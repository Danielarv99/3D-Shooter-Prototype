using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerController player;
    private TextMeshProUGUI bullets;
    public TextMeshProUGUI reloading;
    public GameObject enemy;
    public TextMeshProUGUI enemiesCount;


    void Awake()
    {
        bullets = GameObject.Find("BulletsText").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        InvokeRepeating("EnemySpawn", 1 , 3);
    }

    void Update()
    {
        ReloadTextManager();
        EnemiesKilledTextManager();

    }

    void EnemySpawn()
    {
        float spawnRangeX = Random.Range(-49,49);
        float spawnRangeZ = Random.Range(-49,49);
        Vector3 spawnPosition = new Vector3(spawnRangeX, 3 ,spawnRangeZ);

        Instantiate(enemy, spawnPosition , enemy.transform.rotation);

    }

    void ReloadTextManager()
    {
        bullets.text = "Bullets: " + player.bulletAmount + "/12";
        if (player.isReloading)
        {
            reloading.gameObject.SetActive(true);
        } else {
            reloading.gameObject.SetActive(false);
        }
    }
    
    void EnemiesKilledTextManager()
    {
        enemiesCount.text = "KillCount: " + Enemy.enemiesKilled;
    }


}
