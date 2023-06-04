using System;
using UnityEngine;

public class ElementsController : MonoBehaviour
{
	private HotkeysManager _hotkeysManager;

	public Element CurrentElement { get; private set; }
	public AttackType CurrentAttackType { get; private set; }

	private void Start()
	{
		_hotkeysManager = HotkeysManager.Instance;
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
		Debug.Log(element);
		CurrentElement = element;
	}

	public void SetAttackType(AttackType attackType)
	{
		Debug.Log(attackType);
		CurrentAttackType = attackType;
	}
}
