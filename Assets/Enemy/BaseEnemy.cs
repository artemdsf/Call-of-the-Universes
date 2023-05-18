using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Parameters")]
	[SerializeField] protected int MaxHealth = 100;
	[SerializeField] protected float MovementSpeed = 3f;

	protected Transform CurrentTarget;
	protected Rigidbody2D Rigidbody2D;
	protected int CurrentHealth;
	protected bool IsAlive = true;

	protected virtual void Awake()
	{
		CurrentHealth = MaxHealth;
		Rigidbody2D = GetComponent<Rigidbody2D>();
		CurrentTarget = GameObject.FindGameObjectWithTag(PlayerConstants.PlayerTag).transform;
	}

	protected virtual void Update()
	{
		Move();
	}

	public virtual void TakeDamage(int damage)
	{
		if (IsAlive)
		{
			CurrentHealth -= damage;

			if (CurrentHealth <= 0)
			{
				Die();
			}
		}
	}

	protected virtual void Move()
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

	protected virtual void Die()
	{
		if (IsAlive)
		{
			IsAlive = false;
			Destroy(gameObject);
		}
	}
}
