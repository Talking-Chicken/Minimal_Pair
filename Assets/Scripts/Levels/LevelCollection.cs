using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelCollection : ScriptableObject
{
    [Serializable]
    public struct level
    {
        public string levelName;
        public List<PairsAudio> pairs;
    }

    [Serializable]
    public struct audioCollection {
        public List<AudioClip> audioClips;
    }

    public List<level> Levels;
}
