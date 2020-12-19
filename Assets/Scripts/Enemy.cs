using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private int _currentPoint;

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, target.position.x, _speed * Time.deltaTime), 
                                         transform.position.y);

        if (transform.position.x == target.position.x)
        {
            _currentPoint++;

            if(_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.RemoveCoin();
        }
    }
}
