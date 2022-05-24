using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private Text _dialogText;
    [SerializeField] private Text _nameText;

    [SerializeField] private GameObject _dialogContainer;

    private readonly float _typeSpeed = 0.065f;

    private DialogStructure[] _dialog;
    private int _dialogIndex;
    
    private Coroutine _typeCoroutine;

    public void ShowDialog(DialogSentencesSO sentences)
    {
        _dialogContainer.SetActive(true);
        _dialog = sentences.Sentences;
        
        ResetDialogBox();
        
        _typeCoroutine = StartCoroutine(TypeSentence(_dialog[_dialogIndex].Sentence));
    }

    private void ResetDialogBox()
    {
        _dialogText.text = string.Empty;
        _nameText.text = _dialog[_dialogIndex].Name;
    }

    private void HideDialog()
    {
        _dialogContainer.SetActive(false);
    }

    public void TryStartNextSentence()
    {
        if (_typeCoroutine != null)
        {
            StopCoroutine(_typeCoroutine);
            _typeCoroutine = null;
            _dialogText.text = _dialog[_dialogIndex].Sentence;
            return;
        }

        if (_dialogIndex == _dialog.Length - 1)
        {
            _dialogIndex = 0;
            HideDialog();
            return;
        }
        
        _dialogIndex++;
        ResetDialogBox();
        _typeCoroutine = StartCoroutine(TypeSentence(_dialog[_dialogIndex].Sentence));
    }

    private IEnumerator TypeSentence(string text)
    {
        foreach (var letter in text)
        {
            _dialogText.text += letter;
            yield return new WaitForSeconds(_typeSpeed);
        }

        _typeCoroutine = null;
    }
}