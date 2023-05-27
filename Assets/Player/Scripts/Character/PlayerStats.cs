using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public string Name { get; set; }
	public int MaxHealth { get; private set; }
	public int Health { get; private set; }
	public int Mana { get; private set; }
	public int Strength { get; private set; }
	public int Intellect { get; private set; }
	public int Agility { get; private set; }
	public int Stamina { get; private set; }
	public int Luck { get; private set; }

	private void Start()
	{
		Name = PlayerConstants.DefaultPlayerName;
		Health = PlayerConstants.InitialHealth;
		Mana = PlayerConstants.InitialMana;
		Strength = PlayerConstants.InitialStrength;
		Intellect = PlayerConstants.InitialIntellect;
		Agility = PlayerConstants.InitialAgility;
		Stamina = PlayerConstants.InitialStamina;
		Luck = PlayerConstants.InitialLuck;

		MaxHealth = Health;
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
	}

	public void Heal(int value)
	{
		Health = Health + value < MaxHealth ? Health + value : MaxHealth;
	}
}
