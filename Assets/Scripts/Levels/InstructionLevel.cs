using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class PairsAudio
{
    [SerializeField, BoxGroup("Info")] private string audioName;
    [SerializeField, BoxGroup("Info")] private AudioClip clip;
    [SerializeField, BoxGroup("Info")] private AudioClip[] clips;

    public string AudioName {get=>audioName;set=>audioName=value;}
    public AudioClip Clip {get=>clip;set=>clip=value;} 
    public AudioClip[] Clips {get=>clips;set=>clips=value;}
    public PairsAudio() {
        AudioName = "no name yet";
        Clip = null;
    }

    public PairsAudio(string audioName, AudioClip clip) {
        AudioName = audioName;
        Clip = clip;
    }
}

public class InstructionLevel : LevelBase
{
    [SerializeField, ResizableTextArea, BoxGroup("Info")] private string instruction;
    [SerializeField, BoxGroup("GUI")] private TextMeshProUGUI instructionText;
    [SerializeField, BoxGroup("Info")] private List<PairsAudio> pairsAudios;
    [SerializeField, BoxGroup("Levels")] private LevelCollection levelCollection;
    private string nextLevelName;
    private int currentAudioClip = 0;
    private bool isAllAudioFinished = false, isStartedPlayingIntruction = false, timeToNextLevel = false, isCorotineRuning = false;
    void Start()
    {
        //ramdomly choose a scene
        int randomLevelIndex = UnityEngine.Random.Range(0, levelCollection.Levels.Count);
        nextLevelName = levelCollection.Levels[randomLevelIndex].levelName;
        pairsAudios.Clear();
        pairsAudios.AddRange(levelCollection.Levels[randomLevelIndex].pairs);

        SoundManager.Instance.playBGM(null);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isStartedPlayingIntruction && !isAllAudioFinished)
            isStartedPlayingIntruction = true;

        // if (isStartedPlayingIntruction)
        //     if (!SoundManager.Instance.UIAudioSource.isPlaying) {
        //         SoundManager.Instance.playUISound(pairsAudios[currentAudioClip].Clip);
        //         currentAudioClip = Mathf.Min(currentAudioClip+1, pairsAudios.Count);
        //     }
        
        //play audio instruction, the speed is acoording to how many level player passed
        if (isStartedPlayingIntruction) {
            switch (GameManager.Instance.levelPassedCount) {
                case 0:
                case 1:
                case 2:
                    if (!SoundManager.Instance.UIAudioSource.isPlaying) {
                        SoundManager.Instance.playUISound(pairsAudios[currentAudioClip].Clips, 0);
                        currentAudioClip = Mathf.Min(currentAudioClip+1, pairsAudios.Count);
                    }
                    break;

                case 3:
                case 4:
                case 5:
                    if (!SoundManager.Instance.UIAudioSource.isPlaying) {
                        SoundManager.Instance.playUISound(pairsAudios[currentAudioClip].Clips, 1);
                        currentAudioClip = Mathf.Min(currentAudioClip+1, pairsAudios.Count);
                    }
                    break;
                
                case 6:
                case 7:
                case 8:
                    if (!SoundManager.Instance.UIAudioSource.isPlaying) {
                        SoundManager.Instance.playUISound(pairsAudios[currentAudioClip].Clips, 2);
                        currentAudioClip = Mathf.Min(currentAudioClip+1, pairsAudios.Count);
                    }
                    break;
                
                default:
                    if (!SoundManager.Instance.UIAudioSource.isPlaying) {
                        SoundManager.Instance.playUISound(pairsAudios[currentAudioClip].Clips, 2);
                        currentAudioClip = Mathf.Min(currentAudioClip+1, pairsAudios.Count);
                    }
                    break;
            }
        }


        if (currentAudioClip >= pairsAudios.Count) {
            isAllAudioFinished = true;
            isStartedPlayingIntruction = false;
        }

        showInstruction();
            
    }

    public override bool hasWon() {
        if (isAllAudioFinished && !isCorotineRuning)
            StartCoroutine(waitToStart());
        return timeToNextLevel;
    }

    public override void won()
    {
        SceneManager.LoadScene(nextLevelName + " Scene");
    }

    /* both show text and play audios */
    public void showInstruction() {
        switch (nextLevelName) {
            case "Game1_1":
            case "Game1_2":
            case "Game1_3":
                instruction = "Find The Way Out!";
            break;

            case "Game2_1":
            case "Game2_2":
            case "Game2_3":
                instruction = "Push Box To Form Word!";
            break;

            case "Game3_1":
            case "Game3_2":
            case "Game3_3":
                instruction = "Spell The Word And Wait!";
            break;
        }
        instructionText.text = instruction;
    }

    IEnumerator waitToStart() {
        isCorotineRuning = true;
        yield return new WaitForSeconds(0.5f);
        timeToNextLevel = true;
    }
}
