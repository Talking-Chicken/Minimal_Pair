using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText; 
    void Start()
    {
        
    }

    
    void Update()
    {
        //display high score if there's one
        if (PlayerPrefs.HasKey("High Score"))
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");
        else
            highScoreText.text = "";
    }

    public void startGame() {
        SceneManager.LoadScene("Instruction Scene");
    }

    public void exitGame() {
        Application.Quit();
    }
}
