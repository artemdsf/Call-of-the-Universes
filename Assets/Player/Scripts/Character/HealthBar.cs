using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private PlayerStats _playerStats;

	private Image _healthBar;

	private void Awake()
	{
		_healthBar = GetComponent<Image>();

		if (_playerStats == null)
		{
			Debug.LogError("PlayerStats not assigned to HealthBar");
		}
	}

	private void Update()
	{
		_healthBar.fillAmount = _playerStats.Health / (float)_playerStats.MaxHealth;
	}
}
