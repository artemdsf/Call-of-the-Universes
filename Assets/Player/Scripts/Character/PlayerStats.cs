using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public string Name { get; set; }
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
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
	}
}
