using System.Collections.Generic;
using UnityEngine;

public class HotkeysManager : MonoBehaviour
{
	public static HotkeysManager Instance;

	[SerializeField] private List<ElementHotkey> _elementHotkeys;
	[SerializeField] private List<AttackTypeHotkey> _attackTypeHotkeys;

	private readonly Dictionary<Element, KeyCode> _elementHotkeysDictionary = new();
	private readonly Dictionary<AttackType, KeyCode> _attackTypeHotkeysDictionary = new();
	private readonly KeyCode _attackHotkey = KeyCode.Mouse0;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		foreach (ElementHotkey elementHotkey in _elementHotkeys)
		{
			_elementHotkeysDictionary.Add(elementHotkey.Element, elementHotkey.Hotkey);
		}

		foreach (AttackTypeHotkey attackTypeHotkey in _attackTypeHotkeys)
		{
			_attackTypeHotkeysDictionary.Add(attackTypeHotkey.AttackType, attackTypeHotkey.Hotkey);
		}
	}

	public KeyCode GetElementHotkey(Element element)
	{
		return _elementHotkeysDictionary.GetValueOrDefault(element);
	}

	public KeyCode GetAttackTypeHotkey(AttackType attackType)
	{
		return _attackTypeHotkeysDictionary.GetValueOrDefault(attackType);
	}

	public KeyCode GetAttackHotkey()
	{
		return _attackHotkey;
	}
}

[System.Serializable]
public class ElementHotkey
{
	public Element Element;
	public KeyCode Hotkey;
}

[System.Serializable]
public class AttackTypeHotkey
{
	public AttackType AttackType;
	public KeyCode Hotkey;
}
