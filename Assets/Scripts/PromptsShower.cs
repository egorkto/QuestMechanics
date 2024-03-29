using TMPro;
using UnityEngine;

public class PromptsShower : MonoBehaviour
{
    [SerializeField] private QuestPerformer _performer;
    [SerializeField] private TMP_Text _promptText;

    private void OnEnable()
    {
        _performer.QuestHolderEnter += ShowPrompt;
        _performer.QuestHolderExit += HidePrompt;
        _performer.QuestAccepted += HidePrompt;
        _performer.QuestFinished += HidePrompt;
    }

    private void OnDisable()
    {
        _performer.QuestHolderEnter -= ShowPrompt;
        _performer.QuestHolderExit -= HidePrompt;
        _performer.QuestAccepted -= HidePrompt;
        _performer.QuestFinished -= HidePrompt;
    }

    public void ShowPrompt(KeyCode acceptKey)
    {
        _promptText.text = acceptKey.ToString();
    }

    public void HidePrompt()
    {
        _promptText.text = "";
    }
}
