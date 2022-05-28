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

    public string AudioName {get=>audioName;set=>audioName=value;}
    public AudioClip Clip {get=>clip;set=>clip=value;} 
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

        if (isStartedPlayingIntruction)
            if (!SoundManager.Instance.UIAudioSource.isPlaying) {
                SoundManager.Instance.playUISound(pairsAudios[currentAudioClip].Clip);
                currentAudioClip = Mathf.Min(currentAudioClip+1, pairsAudios.Count);
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
        instructionText.text = instruction;
    }

    IEnumerator waitToStart() {
        isCorotineRuning = true;
        yield return new WaitForSeconds(0.5f);
        timeToNextLevel = true;
    }
}
