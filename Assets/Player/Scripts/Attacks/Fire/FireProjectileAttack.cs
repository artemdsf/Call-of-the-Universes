using UnityEngine;

public class FireProjectileAttack : BaseAttack
{
	[Header("Fire Projectile Parameters")]
	[SerializeField] private int _damage = 10;
	[SerializeField] private float _fireProjectileSpeed = 10f;
	[SerializeField] private float _fireProjectileLifeTime = 5f;
	[SerializeField] private float _cooldownTime = 1f;
	[SerializeField] private GameObject _fireProjectilePrefab;

	private float _timeSinceLastFireball;

	private void Awake()
	{
		Element = Element.Fire;
		AttackType = AttackType.Projectile;
	}

	private void Update()
	{
		_timeSinceLastFireball += Time.deltaTime;
	}
	
	public override void Execute(Vector3 targetPosition)
	{
		if (_timeSinceLastFireball >= _cooldownTime)
		{
			Fire(targetPosition);
			_timeSinceLastFireball = 0f;
		}
	}

	private void Fire(Vector3 targetPosition)
	{
		GameObject fireball = Instantiate(_fireProjectilePrefab, transform.position, Quaternion.identity);
		FireProjectile fireProjectile = fireball.GetComponent<FireProjectile>();

		Vector2 direction = (targetPosition - transform.position).normalized;

		fireProjectile.Initialize(direction, _fireProjectileSpeed, _fireProjectileLifeTime, _damage);
	}
}
