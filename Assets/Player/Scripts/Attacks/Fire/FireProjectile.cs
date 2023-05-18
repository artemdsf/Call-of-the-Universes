using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class FireProjectile : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;
	private int _damage;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Initialize(Vector2 direction, float speed, float lifeTime, int damage)
	{
		_damage = damage;
		_rigidbody2D.velocity = direction.normalized * speed;
		Destroy(gameObject, lifeTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(EnemyConstants.EnemyTag) && other.TryGetComponent(out BaseEnemy enemy))
		{
			enemy.TakeDamage(_damage);
			Destroy(gameObject);
		}
	}
}
