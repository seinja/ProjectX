using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTest : MonoBehaviour
{
    [SerializeField] private DialogSentencesSO _sentencesSO;
    [SerializeField] private DialogBox _dialogBox;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => _dialogBox.ShowDialog(_sentencesSO));
    }
}
