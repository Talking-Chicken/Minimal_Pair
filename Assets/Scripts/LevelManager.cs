using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LevelBase level;

    void Awake() {
        GameManager.Instance.specifyLevel(level);
    }

    void Start()
    {
            
    }

    
    void Update()
    {
        
    }
}
