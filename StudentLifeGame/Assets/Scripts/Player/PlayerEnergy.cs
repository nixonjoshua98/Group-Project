using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
	/* - - - - CONSTANTS - - - - */
	private const float MAX_ENERGY = 100;


	/* - - - - INTERNAL PRIVATES - - - - */
	private float _currentEnergy;


	/* - - - - INSPECTOR PRIVATES- - - - */
	[Header("Energy Exhaustion Rate (sec)"), Range(0, MAX_ENERGY), SerializeField]
	private float energyLostSecond; // Total energy lost per second


	/* - - - - INSPECTOR GAMEOBJECTS - - - - */
	[SerializeField]
	Slider energySlider;


	/* - - - - ACCESS RESTRICTIONS - - - - */
	public float currentEnergy {
		get { return _currentEnergy; }
		set { _currentEnergy = Mathf.Max(0, Mathf.Min(MAX_ENERGY, value)); }
	}


	// Sets attributes to default values
	public void Awake()
	{
		currentEnergy = MAX_ENERGY;
	}


	// Called every fixed period of time
	public void FixedUpdate()
	{
		UpdateEnergy();

		energySlider.value = GetIntEnergy();
	}


	// Deducts the natural energy lost over time
	private void UpdateEnergy()
	{
		currentEnergy -= (Time.fixedDeltaTime * energyLostSecond);  // Independant of FPS
	}


	/* - - - - HELPER METHODS - - - - */
	public bool HasEnergy() { return currentEnergy > 0; }
	public bool OutOfEnergy() { return !HasEnergy(); }
	public float GetFloatEnergy() { return currentEnergy; }
	public int GetIntEnergy() { return Mathf.CeilToInt(currentEnergy); }
}
