using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigibody2D;
    private float _movementX;
    private bool _isGrounded;

    private int _coins;

    public float Speed => Mathf.Abs(_rigibody2D.velocity.x);
    public float JumpDirection => _rigibody2D.velocity.y;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movementX = Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;

        _rigibody2D.velocity = new Vector2(_movementX, _rigibody2D.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        _isGrounded = hit;

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigibody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        if (_movementX != 0)
            transform.localRotation = Quaternion.Euler(0, _movementX > 0 ? 0 : 180, 0);
    }

    public void AddCoin()
    {
        _coins++;
    }

    public void RemoveCoin()
    {
        _coins--;
    }
}
