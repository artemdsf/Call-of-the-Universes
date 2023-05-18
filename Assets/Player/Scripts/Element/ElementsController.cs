using System;
using UnityEngine;

public class ElementsController : MonoBehaviour
{
	private HotkeysManager _hotkeysManager;

	public Element CurrentElement { get; private set; }
	public AttackType CurrentAttackType { get; private set; }

	private void Awake()
	{
		_hotkeysManager = HotkeysManager.Instance;
	}

	private void Start()
	{
		SetElement(Element.Fire);
		SetAttackType(AttackType.Projectile);
	}

	private void Update()
	{
		if (_hotkeysManager != null)
		{
			foreach (Element element in Enum.GetValues(typeof(Element)))
			{
				KeyCode key = _hotkeysManager.GetElementHotkey(element);

				if (Input.GetKeyDown(key))
				{
					SetElement(element);
					break;
				}
			}

			foreach (AttackType attackType in Enum.GetValues(typeof(AttackType)))
			{
				KeyCode key = _hotkeysManager.GetAttackTypeHotkey(attackType);

				if (Input.GetKeyDown(key))
				{
					SetAttackType(attackType);
					break;
				}
			}
		}
	}

	public void SetElement(Element element)
	{
		CurrentElement = element;
	}

	public void SetAttackType(AttackType attackType)
	{
		CurrentAttackType = attackType;
	}
}
