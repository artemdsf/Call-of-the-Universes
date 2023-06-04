using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
	[Header("Base Parameters")]
	[SerializeField] private GameObject _prefab;
	[SerializeField] private int _damage = 10;
	[SerializeField] private float _cooldownTime = 1f;
	[SerializeField] private float _timePerDamagingTick = 0.5f;
	[SerializeField] private float _speed = 10f;
	[SerializeField] private float _lifeTime = 5f;
	[SerializeField] private bool _isDestroyable;

	protected string TargetAttackTag;
	private float _timeSinceLastAttack;

	public Element Element { get; protected set; }
	public AttackType AttackType { get; protected set; }

	public void Execute(Vector3 targetPosition)
	{
		if (_timeSinceLastAttack > _cooldownTime)
		{
			Fire(targetPosition);
			_timeSinceLastAttack = 0f;
		}
	}

	protected virtual void Awake()
	{
		_timeSinceLastAttack = _cooldownTime;
	}

	protected virtual void Update()
	{
		_timeSinceLastAttack += Time.deltaTime;
	}

	protected abstract Vector3 GetInstantiatePosition(Vector3 targetPosition);

	private void Fire(Vector3 targetPosition)
	{
		GameObject gameObject = Instantiate(_prefab, GetInstantiatePosition(targetPosition), Quaternion.identity);
		TriggerAttack triggerAttack = gameObject.GetComponent<TriggerAttack>();
		Vector2 direction = (targetPosition - transform.position).normalized;
		triggerAttack.Initialize(TargetAttackTag, _isDestroyable, _damage, _timePerDamagingTick, direction, _speed, _lifeTime);
	}
}
