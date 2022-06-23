using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchableWordBlock : WordBlock
{
    [SerializeField] private char[] words;
    private int currentWordIndex = 0;
    private bool isInCoolDown = false;
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider.GetComponent<PlayerControl>() != null && !isInCoolDown)
            if (hit.distance <= 1.3f)
                switchWord(ref currentWordIndex);
    }

    public void switchWord(ref int index) {
        index++;
        if (index >= words.Length)
            index = 0;
        Word = words[index];
        isInCoolDown = true;
        StartCoroutine(waitToCoolDown(0.5f));
    }

    IEnumerator waitToCoolDown(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        isInCoolDown = false;
    }
}
