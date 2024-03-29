using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;

    private Vector2 _moveDirectionl;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private void Update()
    {
        _moveDirectionl = new Vector2(Input.GetAxis(horizontal), Input.GetAxis(vertical));
        _controller.Move(_moveDirectionl * _speed * Time.deltaTime);
    }
}
