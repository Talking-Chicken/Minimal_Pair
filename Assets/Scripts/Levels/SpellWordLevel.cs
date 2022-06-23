using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SpellWordLevel : LevelBase
{
    [SerializeField] private string answer;
    private char[] answers;
    private WordBlock[] wordBlocks;
    void Start()
    {
        wordBlocks = FindObjectsOfType<WordBlock>();
        answers = answer.ToCharArray();
        wordBlocks = wordBlocks.OrderBy(blockName=>blockName.name).ToArray();
        Debug.Log(wordBlocks[0].name);
    }

    
    void Update()
    {
        
    }

    public override bool hasWon()
    {
        if (GameManager.Instance.currentTime <= 1f) {
            for (int i = 0; i < answers.Length; i++) {
                if (!answers[i].Equals(wordBlocks[i].Word))
                    return false;
            }
            return true;
        }
        return false;
    }

    public override void won()
    {
        SceneManager.LoadScene("Instruction Scene");
    }
}
