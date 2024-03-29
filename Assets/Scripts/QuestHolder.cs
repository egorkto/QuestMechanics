using UnityEngine;

public class QuestHolder : MonoBehaviour
{
    [SerializeField] private Quest _quest;

    public void AcceptQuest()
    {
        _quest.Activate();
    }

    public bool TryFinishQuest()
    {
        if(_quest.Completed)
        {
            _quest.Disactivate();
            return true;
        }
        return false;
    }
}
