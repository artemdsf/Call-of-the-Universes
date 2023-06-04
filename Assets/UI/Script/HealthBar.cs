using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private BaseEntity _player;

	private Image _healthBar;

	private void Awake()
	{
		_healthBar = GetComponent<Image>();

		if (_player == null)
		{
			Debug.LogError("PlayerStats not assigned to HealthBar");
		}
	}

	private void Update()
	{
		_healthBar.fillAmount = _player.CurrentHealth / (float)_player.MaxHealth;
	}
}
