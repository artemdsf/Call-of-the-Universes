using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyFireElementalAttack : BaseAttack
{
	[Header("Fire Elemental Explosion Parameters")]
	[SerializeField] private float _explosionAttackRadius = 3f;
	[SerializeField] private int _explosionAttackDamage = 2;

	private EnemyController _enemyController;
	private Transform _currentTarget;

	protected override void Awake()
	{
		TargetAttackTag = PlayerConstants.PlayerTag;
		_enemyController = GetComponent<EnemyController>(); 
		_enemyController.OnDeath.AddListener(Explode);
		_currentTarget = GameObject.FindGameObjectWithTag(PlayerConstants.PlayerTag).transform;
		base.Awake();
	}

	protected override void Update()
	{
		if (Vector2.Distance(transform.position, _currentTarget.position) > _explosionAttackRadius)
		{
			Execute(_currentTarget.position);
		}
		else
		{
			_enemyController.Die();
		}

		base.Update();
	}

	protected override Vector3 GetInstantiatePosition(Vector3 targetPosition)
	{
		return transform.position;
	}

	private void Explode()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosionAttackRadius);

		foreach (Collider2D collider in colliders)
		{
			if (collider.CompareTag(TargetAttackTag) && collider.TryGetComponent(out BaseEntity baseEntity))
			{
				baseEntity.TakeDamage(_explosionAttackDamage);
			}
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, _explosionAttackRadius);
	}
}
