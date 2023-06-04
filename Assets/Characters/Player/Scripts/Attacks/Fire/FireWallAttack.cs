using UnityEngine;

public class FireWallAttack : BaseAttack
{
	protected override void Awake()
	{
		TargetAttackTag = EnemyConstants.EnemyTag;
		Element = Element.Fire;
		AttackType = AttackType.Wall;
		base.Awake();
	}

	protected override Vector3 GetInstantiatePosition(Vector3 targetPosition)
	{
		return targetPosition;
	}
}
