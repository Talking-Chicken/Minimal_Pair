using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBoxLevel : LevelBase
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public override bool hasWon()
    {
        return false;
    }

    public override void won()
    {
        SceneManager.LoadScene("Instruction Scene");
    }
}
