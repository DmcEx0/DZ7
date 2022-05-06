using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private bool _isFacingRight = true;

    private const string _speedInAnimator = "Speed";

    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float translate = Input.GetAxis("Horizontal") * _speed;
        transform.Translate(translate, 0, 0);

        _animator.SetFloat(_speedInAnimator, Mathf.Abs(translate));

        if (translate > 0 && _isFacingRight == false)
            Flip();
        else if (translate < 0 && _isFacingRight == true)
            Flip();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce(Vector2.up * _jumpForce);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
