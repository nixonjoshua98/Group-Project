using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnergyManager : MonoBehaviour
{
	/* - - - - CONSTANTS - - - - */
	private const float MAX_ENERGY = 100;


	/* - - - - INTERNAL PRIVATES - - - - */
	private float _currentEnergy;


	/* - - - - INSPECTOR - - - - */
	[Header("Energy Exhaustion Rate (sec)")]
	[Range(0, MAX_ENERGY)]
	[SerializeField]
	private float energyLostSecond = 1.0f; // Total energy lost per second


	/* - - - - ACCESS RESTRICTIONS - - - - */
	public float currentEnergy
	{
		get
		{
			return _currentEnergy; // ...
		}
		set
		{
			// Restricts the energy between 0 - <MAX_ENERGY>
			_currentEnergy = Mathf.Max(0, Mathf.Min(MAX_ENERGY, value));
		}
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
	}


	// Deducts the natural energy lost over time
	private void UpdateEnergy()
	{
		currentEnergy -= (Time.fixedDeltaTime * energyLostSecond);  // Independant of FPS

#if UNITY_EDITOR
		Debug.Log(currentEnergy);
#endif
	}


	/* - - - - HELPER METHODS - - - - */
	public bool HasEnergy() { return currentEnergy > 0; }
	public bool OutOfEnergy() { return !HasEnergy(); }
	public int GetIntEnergy() { return Mathf.CeilToInt(currentEnergy); }
}
