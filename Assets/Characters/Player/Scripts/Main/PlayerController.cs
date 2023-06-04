using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ElementsController))]
public class PlayerController : BaseEntity
{
	[SerializeField] private List<BaseAttack> _attacks;

	private ElementsController _elementsController;
	private HotkeysManager _hotkeysManager;
	private Vector2 _movementInput;

	public override void Die()
	{
		IsAlive = false;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	protected override void Move()
	{
		_movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		Rigidbody2D.velocity = _movementInput * Speed;
	}

	protected override void Awake()
	{
		MaxHealth = PlayerConstants.InitialHealth;
		MaxMana = PlayerConstants.InitialMana;
		Speed = PlayerConstants.InitialSpeed;
		_elementsController = GetComponent<ElementsController>();
		base.Awake();
	}

	private void Start()
	{
		_hotkeysManager = HotkeysManager.Instance;
	}

	private void Update()
	{
		if (Input.GetKey(_hotkeysManager.GetAttackHotkey()))
		{
			Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPosition.z = transform.position.z;
			ExecuteCurrentAttack(targetPosition);
		}

		if (CurrentHealth <= 0 && IsAlive)
		{
			Die();
		}
	}

	private void ExecuteCurrentAttack(Vector3 targetPosition)
	{
		foreach (var attack in _attacks)
		{
			if (attack.Element == _elementsController.CurrentElement && attack.AttackType == _elementsController.CurrentAttackType)
			{
				attack.Execute(targetPosition);
				break;
			}
		}
	}
}
