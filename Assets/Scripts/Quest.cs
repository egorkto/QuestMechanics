using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool Completed => _completed;

    [SerializeField] private ItemsCollector _collector;
    [SerializeField] private Transform _itemPont;
    [SerializeField] private QuestItem _item;

    private QuestItem _currentItem;
    private bool _completed = false;

    public void Activate()
    {
        _completed = false;
        _currentItem = Instantiate(_item, _itemPont.position, Quaternion.identity).GetComponent<QuestItem>();
    }

    public void Disactivate()
    {
        if(_currentItem != null)
        {
            Destroy(_currentItem.gameObject);
            _collector.PutItem();
        }
    }

    private void OnEnable()
    {
        _collector.ItemCollected += TryComplete;
    }

    private void OnDisable()
    {
        _collector.ItemCollected -= TryComplete;
    }

    private void TryComplete(QuestItem item)
    {
        if (_currentItem != null && item == _currentItem)
            _completed = true;
    }
}
