using UnityEngine;
using System.Collections;
using System;

public class Drinker: MonoBehaviour
{
	//user input required
	public float bodyMass; //kg
	public float bodyHeight; //cm
	public bool isMale;
	public bool isStomachEmpty = true;

	//calculated by program
	float liquidMass;
	const float MAX_ALCOHOL_ELIMINATION = 10;
	public float alcoholDrunk = 0;
	float alcoholAbsorbed = 0;
	float promils;
	int absorptionTime; //in minutes
	int absorptionProgress = 0;
	float bmi;

	float timePassed = 0;
	
	void Start () 
	{
		CalculateBMI();
		CalculateAbsorptionTime();
		CalculateLiquids();
	}
	
	void Update () 
	{
		timePassed += Time.deltaTime;
		if(timePassed >= 1)
		{
			timePassed = 0;
			if(alcoholDrunk > 0)
				AbsorbAlcohol();
			if (alcoholAbsorbed > 0)
				EliminateAlcohol();
		}
	}
	


	public void CalculatePromils()
	{
		promils = alcoholAbsorbed / liquidMass;
		print("Promils = " + promils);
	}

	public void CalculateAbsorptionTime()
	{
		if (isStomachEmpty)
			absorptionTime = 30;
		else
			absorptionTime = 60;


		print("Absorption Time = " + absorptionTime);
	}
	
	public void CalculateBMI()
	{
		bmi = bodyMass / ((bodyHeight/100) * (bodyHeight/100));
		print("BMI = " + bmi);
	}

	void CalculateLiquids()
	{
		float multiplier;
		if (isMale)
			multiplier = 0.7f;
		else
			multiplier = 0.6f;

		float overweight = CalculateOverweight();
		float liquidExcess = 0.15f * overweight;

		liquidMass = multiplier * (bodyMass - overweight) + liquidExcess;
		print(bodyMass - overweight);
		print(liquidMass);
	}

	float CalculateOverweight()
	{
		float bmiDifference;
		if (bmi > 25)
			bmiDifference = bmi - 25;
		else if (bmi < 18.5)
			bmiDifference = bmi - 18.5f;
		else
			bmiDifference = 0;

		return bmiDifference * ((bodyHeight / 100) * (bodyHeight / 100));
    }

	void AbsorbAlcohol()
	{
		if (absorptionProgress < absorptionTime)
		{
			alcoholAbsorbed += alcoholDrunk / (absorptionTime - absorptionProgress);
			alcoholDrunk -= alcoholDrunk / (absorptionTime - absorptionProgress);
			++absorptionProgress;
		}
		else
			absorptionProgress = 0;
		print("absorbed " + alcoholAbsorbed + " \nProgress" + absorptionProgress);
	}

	void EliminateAlcohol()
	{
		float alcoholEliminated = (MAX_ALCOHOL_ELIMINATION * alcoholAbsorbed) / (4.2f + alcoholAbsorbed) / 60.0f;
		alcoholAbsorbed -= alcoholEliminated;
		if (alcoholAbsorbed < 0)
			alcoholAbsorbed = 0;
		print("eliminated " + alcoholEliminated + "remaining " + alcoholAbsorbed);
	}

	public void Drink(float alcoholQuantity)
	{
		alcoholDrunk += alcoholQuantity;
	}

}