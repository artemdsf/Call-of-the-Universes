using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[Header("Movement Parameters")]
	[SerializeField] private float _speed = 5f;

	private Rigidbody2D _rigidbody2D;
	private Vector2 _movementInput;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		_movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
	}

	private void FixedUpdate()
	{
		_rigidbody2D.velocity = _movementInput * _speed;
	}
}
