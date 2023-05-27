using UnityEngine;

public class EnemyFireElemental : BaseEnemy
{
	[Header("Fire Elemental Parameters")]
	[SerializeField] private float _projectileAttackCooldown = 2f;
	[SerializeField] private float _explosionAttackRadius = 3f;
	[SerializeField] private int _explosionAttackDamage = 20;

	[SerializeField] private GameObject _fireProjectilePrefab;
	[SerializeField] private float _fireProjectileSpeed = 5f;
	[SerializeField] private int _fireProjectileDamage = 10;

	private Transform _currentTarget;
	private float _timeSinceLastProjectileAttack;

	protected override void Awake()
	{
		base.Awake();
		_currentTarget = GameObject.FindGameObjectWithTag(PlayerConstants.PlayerTag).transform;
	}

	protected override void Update()
	{
		base.Update();
		Attack();
	}

	protected override void Move()
	{
		base.Move();
	}

	protected override void Die()
	{
		Explode();
		base.Die();
	}

	private void Attack()
	{
		_timeSinceLastProjectileAttack += Time.deltaTime;

		if (IsAlive)
		{
			if (Vector2.Distance(transform.position, _currentTarget.position) > _explosionAttackRadius)
			{
				if (_timeSinceLastProjectileAttack >= _projectileAttackCooldown)
				{
					ShootFireProjectile();
					_timeSinceLastProjectileAttack = 0f;
				}
			}
			else
			{
				Die();
			}
		}
	}

	private void ShootFireProjectile()
	{
		GameObject fireProjectile = Instantiate(_fireProjectilePrefab, transform.position, Quaternion.identity);
		Rigidbody2D rb = fireProjectile.GetComponent<Rigidbody2D>();

		Vector2 direction = (_currentTarget.position - transform.position).normalized;
		rb.velocity = direction * _fireProjectileSpeed;

		EnemyFireProjectile enemyFireProjectile = fireProjectile.GetComponent<EnemyFireProjectile>();
		enemyFireProjectile.Initialize(_fireProjectileDamage);
	}

	private void Explode()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionAttackRadius);

		foreach (Collider2D collider in colliders)
		{
			if (collider.CompareTag(PlayerConstants.PlayerTag))
			{
				if (collider.TryGetComponent(out PlayerStats playerStats))
				{
					playerStats.TakeDamage(_explosionAttackDamage);
				}
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, _explosionAttackRadius);
	}
}
