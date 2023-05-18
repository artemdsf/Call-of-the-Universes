using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
	public Element Element { get; protected set; }
	public AttackType AttackType { get; protected set; }
	public int Damage { get; protected set; }
	public float Range { get; protected set; }
	public float Duration { get; protected set; }

	public abstract void Execute(Vector3 targetPosition);
}
