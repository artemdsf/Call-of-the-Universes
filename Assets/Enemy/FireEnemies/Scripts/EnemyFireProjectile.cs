using UnityEngine;

public class EnemyFireProjectile : MonoBehaviour
{
	private int _damage;

	public void Initialize(int damage)
	{
		_damage = damage;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(PlayerConstants.PlayerTag))
		{
			collision.GetComponent<PlayerStats>().TakeDamage(_damage);
			Destroy(gameObject);
		}
	}
}
