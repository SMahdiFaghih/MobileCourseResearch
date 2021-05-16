using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int numOfEnemies;

    void Awake()
    {
        Instance = this;
        numOfEnemies = GameObject.FindGameObjectsWithTag("enemy").Length;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
