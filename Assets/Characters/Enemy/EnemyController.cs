using UnityEngine;
using UnityEngine.Events;

public class EnemyController : BaseEntity
{
	[Header("Enemy Parameters")]
	[SerializeField] protected int Health = 100;
	[SerializeField] protected float MovementSpeed = 3f;

	public UnityEvent OnDeath;
	protected Transform CurrentTarget;

	protected override void Move()
	{
		if (IsAlive)
		{
			Vector2 direction = (CurrentTarget.position - transform.position).normalized;
			Rigidbody2D.velocity = direction * MovementSpeed;
		}
		else
		{
			Rigidbody2D.velocity = Vector2.zero;
		}
	}

	public override void Die()
	{
		if (IsAlive)
		{
			IsAlive = false;
			OnDeath.Invoke();
			Destroy(gameObject);
		}
	}

	protected override void Awake()
	{
		MaxHealth = Health;
		Speed = MovementSpeed;
		CurrentTarget = GameObject.FindGameObjectWithTag(PlayerConstants.PlayerTag).transform;
		base.Awake();
	}
}
