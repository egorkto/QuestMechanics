using System;
using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    public event Action<QuestItem> ItemCollected;

    [SerializeField] private Transform _bringPoint;
    [SerializeField] private KeyCode _bringKey;

    private QuestItem _currentItem;
    private bool _canCollect = true;

    public void PutItem()
    {
        _canCollect = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(_bringKey) && _canCollect && _currentItem != null)
        {
            _currentItem.transform.SetParent(_bringPoint.transform, false);
            _currentItem.transform.position = _bringPoint.position;
            ItemCollected?.Invoke(_currentItem);
            _canCollect = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out QuestItem item))
            _currentItem = item;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out QuestItem item))
            _currentItem = null;
    }
}