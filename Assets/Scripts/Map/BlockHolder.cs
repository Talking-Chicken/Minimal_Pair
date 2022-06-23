using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHolder : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private string answer;
    private char[] characters;
    private bool[] characterMatches;
    private bool isOverloaded = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = new Color(0,0,0,0);

        //seperate answer to each characters
        characters = answer.ToCharArray();
        characterMatches = new bool[characters.Length];
        for (int i = 0; i < characterMatches.Length; i++) {
            characterMatches[i] = false;
        }
    }

    
    void Update()
    {
    }

    public bool checkAllCharacterMatch() {
        if (isOverloaded)
            return false;
        foreach (bool match in characterMatches) {
            if (!match)
                return false;
        }
        return true;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<WordBlock>() != null) {
            for (int i = 0; i < characters.Length; i++) {
                if (characters[i].Equals(collider.GetComponent<WordBlock>().Word) && !characterMatches[i]) {
                    characterMatches[i] = true;
                    return;
                }
            }
            isOverloaded = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider) {
        if (collider.GetComponent<WordBlock>() != null) {
            for (int i = 0; i < characters.Length; i++) {
                if (characters[i].Equals(collider.GetComponent<WordBlock>().Word) && !characterMatches[i]) {
                    characterMatches[i] = true;
                    return;
                }
            }
        }
    }

    void OnTriggerExit2D (Collider2D collider) {
        if (collider.GetComponent<WordBlock>() != null) {
            for (int i = 0; i < characters.Length; i++) {
                if (characters[i].Equals(collider.GetComponent<WordBlock>().Word) && characterMatches[i]) {
                    characterMatches[i] = false;
                    return;
                }
            }
            isOverloaded = false;
        }
    }
}
