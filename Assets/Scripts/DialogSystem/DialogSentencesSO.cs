using UnityEngine;

[CreateAssetMenu(menuName = "Create DialogSentencesSO", fileName = "DialogSentencesSO", order = 0)]
public class DialogSentencesSO : ScriptableObject
{
    [SerializeField] private DialogStructure[] _sentences;

    public DialogStructure[] Sentences => _sentences;
}