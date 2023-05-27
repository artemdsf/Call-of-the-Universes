using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ElementsController), typeof(PlayerStats))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private List<BaseAttack> _attacks;

	private PlayerStats _playerStats;
	private ElementsController _elementsController;
	private HotkeysManager _hotkeysManager;
	private bool _isAlive = true;

	private void Awake()
	{
		_playerStats = GetComponent<PlayerStats>();
		_elementsController = GetComponent<ElementsController>();
	}

	private void Start()
	{
		_hotkeysManager = HotkeysManager.Instance;
	}

	private void Update()
	{
		if (Input.GetKeyDown(_hotkeysManager.GetAttackHotkey()))
		{
			Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetPosition.z = transform.position.z;
			ExecuteCurrentAttack(targetPosition);
		}

		if (_playerStats.Health <= 0 && _isAlive)
		{
			Death();
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

	private void Death()
	{
		_isAlive = false;

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
