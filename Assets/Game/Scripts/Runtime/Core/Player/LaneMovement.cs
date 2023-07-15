using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _laneDistance;

    private int _currentLane = 1;

    public void MoveForward()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }

    public void MoveLeft() => ChangeLane(-1);

    public void MoveRight() => ChangeLane(1);

    private void ChangeLane(int direction)
    {
        int newLane = _currentLane + direction;

        if (newLane >= 0 && newLane <= 2)
        {
            _currentLane = newLane;

            var newPosition = transform.position;
            newPosition.x = (_currentLane - 1) * _laneDistance;

            transform.position = newPosition;
        }
    }
}