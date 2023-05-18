using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ElementsController))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private List<BaseAttack> _attacks;

	private ElementsController _elementsController;
	private HotkeysManager _hotkeysManager;

	private void Awake()
	{
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
