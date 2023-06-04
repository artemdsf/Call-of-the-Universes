using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseEntity : MonoBehaviour
{
	public int MaxHealth { get; protected set; }
	public int CurrentHealth { get; protected set; }
	public int MaxMana { get; protected set; }
	public int CurrentMana { get; protected set; }
	public float Speed { get; protected set; }

	protected Rigidbody2D Rigidbody2D;
	protected bool IsAlive = true;

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

	public bool TryUseMana(int value)
	{
		if (value <= CurrentMana)
		{
			CurrentMana -= value;
			return true;
		}

		return false;
	}

	public void RestoreMana(int value)
	{
		CurrentMana = CurrentMana + value < MaxMana ? CurrentMana + value : MaxMana;
	}

	protected virtual void Awake()
	{
		Rigidbody2D = GetComponent<Rigidbody2D>();
		CurrentHealth = MaxHealth;
		CurrentMana = MaxMana;
	}

	protected virtual void FixedUpdate()
	{
		Move();
	}

	public abstract void Die();
	protected abstract void Move();
}
