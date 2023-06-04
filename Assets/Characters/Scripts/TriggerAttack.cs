using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class TriggerAttack : MonoBehaviour
{
	private List<BaseEntity> _targets = new();
	private Rigidbody2D _rigidbody2D;
	private string _targetAttackTag;
	private int _damage;
	private bool _isDestroyable;
	private float _timePerDamagingTick = 0;
	private float _currrentTime = 0;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_currrentTime = _timePerDamagingTick;
	}

	public void Initialize(string targetAttackTag, bool isDestroyable, int damage, float timePerTick)
	{
		_targetAttackTag = targetAttackTag;
		_isDestroyable = isDestroyable;
		_damage = damage;
		_timePerDamagingTick = timePerTick;
	}

	public void Initialize(string targetAttackTag, bool isDestroyable, int damage, float timePerTick, float lifeTime)
	{
		_targetAttackTag = targetAttackTag;
		_isDestroyable = isDestroyable;
		_damage = damage;
		_timePerDamagingTick = timePerTick;
		Destroy(gameObject, lifeTime);
	}

	public void Initialize(string targetAttackTag, bool isDestroyable, int damage, float timePerTick, Vector2 direction, float speed)
	{
		_targetAttackTag = targetAttackTag;
		_isDestroyable = isDestroyable;
		_damage = damage;
		_timePerDamagingTick = timePerTick;
		_rigidbody2D.velocity = direction.normalized * speed;
	}

	public void Initialize(string targetAttackTag, bool isDestroyable, int damage, float timePerTick, Vector2 direction, float speed, float lifeTime)
	{
		_targetAttackTag = targetAttackTag;
		_isDestroyable = isDestroyable;
		_damage = damage;
		_timePerDamagingTick = timePerTick;
		_rigidbody2D.velocity = direction.normalized * speed;
		Destroy(gameObject, lifeTime);
	}

	private void Update()
	{
		_currrentTime += Time.deltaTime;

		if (_currrentTime > _timePerDamagingTick)
		{
			for (int i = 0; i < _targets.Count; i++)
			{
				Debug.Log(_damage);
				_targets[i].TakeDamage(_damage);

				if (_isDestroyable)
				{
					Destroy(gameObject);
				}
			}

			_currrentTime = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(_targetAttackTag))
		{
			_targets.Add(collision.GetComponent<BaseEntity>());
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(_targetAttackTag))
		{
			_targets.Remove(collision.GetComponent<BaseEntity>());
		}
	}
}
