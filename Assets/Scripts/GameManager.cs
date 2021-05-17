using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject EndGameCanvas_GO;

    [HideInInspector]
    public int NumOfEnemies;

    void Awake()
    {
        Instance = this;
        NumOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AfterEnemyDied()
    {
        NumOfEnemies--;
        if (NumOfEnemies == 0)
        {
            PlayerController.IsLevelCompleted = true;
            EndGameCanvas_GO.SetActive(true);
        }
    }
}
