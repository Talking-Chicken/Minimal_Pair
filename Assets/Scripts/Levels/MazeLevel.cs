using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeLevel : LevelBase
{
    [SerializeField] Exit exit;
    private GameManager gameManager;
    

    void Start()
    {
        SoundManager.Instance.playTimeSound();
    }

    
    void Update()
    {
        
    }

    public override bool hasWon()
    {
        return exit.PlayerEntered;
    }

    public override void won()
    {
        SceneManager.LoadScene("Instruction Scene");
    }
}
