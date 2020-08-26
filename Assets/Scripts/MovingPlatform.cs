using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float _speed;
    float _currentPositionY;
    float _maxYPosition;

    void Start()
    {
        _speed = Random.Range(0.5f, 4f);
        _currentPositionY = transform.position.y;
        _maxYPosition = _currentPositionY + 2.5f;
    }

    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);

        if (transform.position.y >= _maxYPosition)
            _speed = -_speed;
        if (transform.position.y <= _currentPositionY)
            _speed = Random.Range(0.5f, 4f);
    }

    private void OnCollisionEnter(Collision other)
    {
        other.gameObject.transform.parent = gameObject.transform;
    }

    private void OnCollisionExit(Collision other)
    {
        other.gameObject.transform.parent = null;
    }
}