using System;
using UnityEngine;

public class QuestPerformer : MonoBehaviour
{
    public event Action QuestAccepted;
    public event Action QuestFinished;
    public event Action<KeyCode> QuestHolderEnter;
    public event Action QuestHolderExit;

    [SerializeField] private KeyCode _interractKey;

    private QuestHolder _currentHolder = null;
    private bool _isAccepted = false;

    private void Update()
    {
        if (Input.GetKeyDown(_interractKey) && _currentHolder != null)
        {
            if (_isAccepted)
            {
                if(_currentHolder.TryFinishQuest())
                {
                    QuestFinished?.Invoke();
                    _isAccepted = false;
                    _currentHolder = null;
                }
            }
            else
            {
                _currentHolder.AcceptQuest();
                QuestAccepted?.Invoke();
                _isAccepted = true;
                _currentHolder = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out QuestHolder holder) && _currentHolder == null)
        {
            QuestHolderEnter?.Invoke(_interractKey);
            _currentHolder = holder;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out QuestHolder holder) && holder == _currentHolder)
        {
            QuestHolderExit?.Invoke();
            _currentHolder = null;
        }
    }
}
