using UnityEngine;

public class FireProjectileAttack : BaseAttack
{
	protected override void Awake()
	{
		TargetAttackTag = EnemyConstants.EnemyTag;
		Element = Element.Fire;
		AttackType = AttackType.Projectile;
		base.Awake();
	}

	protected override Vector3 GetInstantiatePosition(Vector3 targetPosition)
	{
		return transform.position;
	}
}
