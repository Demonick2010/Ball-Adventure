using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float _speed;
    float _currentPositionY;
    float _maxYPosition;

    void Start()
    {
        _speed = Random.Range(1f, 4f);
        _currentPositionY = transform.position.y;
        _maxYPosition = _currentPositionY + 3f;
    }

    void Update()
    {
        transform.Translate(0, _speed * Time.deltaTime, 0);

        if (transform.position.y >= _maxYPosition)
            _speed = -_speed;
        if (transform.position.y <= _currentPositionY)
            _speed = Random.Range(1f, 6f);
    }
}