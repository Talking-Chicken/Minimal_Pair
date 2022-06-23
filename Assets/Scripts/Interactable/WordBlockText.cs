using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordBlockText : MonoBehaviour
{
    private TextMeshProUGUI wordText;
    private WordBlock wordBlock;
    void Start()
    {
        wordText = GetComponent<TextMeshProUGUI>();
        wordBlock = GetComponentInParent<WordBlock>();
    }

    void Update()
    {
        wordText.text = wordBlock.Word + "";
    }
}
