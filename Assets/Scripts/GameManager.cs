using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : Singleton<GameManager>
{
    private LevelBase level;
    [SerializeField, BoxGroup("Time GUI")] private TextMeshProUGUI timeText, healthText;
    private float currentTime;
    private int currentHealth = 3;
    private int levelPassedCount = 0;
    void Start()
    {
        
    }

    void Update()
    {
        if (level.hasWon() && currentTime > 0) {
            if (SceneManager.GetActiveScene() != null && !SceneManager.GetActiveScene().name.Equals("Instruction Scene"))
                levelPassedCount++;
            level.won();
        }

        

        //if there's is a time limit    
        if (level.hasTimeLimit) {
            countDown();
            timeText.text = "Time: " + (int)currentTime;
            //if time runs out
            if (currentTime <= 0) {
                currentHealth--;
                SceneManager.LoadScene("Instruction Scene");
            }
        } else {
            timeText.text = "";
        }

        //display health
        if (!SceneManager.GetActiveScene().name.Equals("Start Scene"))
            healthText.text = "Health: "+currentHealth;
        else
            healthText.text = "";

        //when player dies
        if (currentHealth <= 0) {
            if (!PlayerPrefs.HasKey("High Score"))
                PlayerPrefs.SetInt("High Score", levelPassedCount);
            else
                if (levelPassedCount > PlayerPrefs.GetInt("High Score"))
                    PlayerPrefs.SetInt("High Score", levelPassedCount);

            
            currentHealth = 3;
            levelPassedCount = 0;
            SceneManager.LoadScene("Start Scene");
        }
    }

    public void specifyLevel(LevelBase level) {
        this.level = level;
        currentTime = level.maxTimeCount;
    }

    public void countDown() {
        currentTime -= Time.deltaTime;
    }
}
