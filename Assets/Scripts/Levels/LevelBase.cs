using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelBase : MonoBehaviour
{  
    public bool hasTimeLimit = false;
    public float maxTimeCount = 30.0f;
    public abstract bool hasWon();
    public abstract void won();
    
}
