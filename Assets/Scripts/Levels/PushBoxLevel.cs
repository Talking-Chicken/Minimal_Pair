using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PushBoxLevel : LevelBase
{
    [SerializeField] private BlockHolder blockHolder;
    void Start()
    {
        SoundManager.Instance.playTimeSound();
    }

    
    void Update()
    {
        
    }

    public override bool hasWon()
    {
        return blockHolder.checkAllCharacterMatch();
    }

    public override void won()
    {
        SceneManager.LoadScene("Instruction Scene");
    }
}
