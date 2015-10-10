using UnityEngine;
using System.Collections;
using System;

public class Drinker: MonoBehaviour
{
	//user input required
	public static float bodyMass; //kg
	public static float bodyHeight; //cm
	public static bool isMale;
	public static bool isStomachEmpty = true;

	//calculated by program
	static float liquidMass;
	const float MAX_ALCOHOL_ELIMINATION = 10;
	static float alcoholDrunk = 0;
	static float alcoholAbsorbed = 0;
	static float promils;
	static int absorptionTime; //in minutes
	static int absorptionProgress = 0;
	static float bmi;

	static DateTime soberingTime = new DateTime();

	static float timePassed = 0;
	
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
	


	public static void CalculatePromils()
	{
		promils = alcoholAbsorbed / liquidMass;
		print("Promils = " + promils);
	}

	public static void CalculateAbsorptionTime()
	{
		if (isStomachEmpty)
			absorptionTime = 30;
		else
			absorptionTime = 60;


		print("Absorption Time = " + absorptionTime);
	}
	
	public static void CalculateBMI()
	{
		bmi = bodyMass / ((bodyHeight/100) * (bodyHeight/100));
		print("BMI = " + bmi);
	}

	static void CalculateLiquids()
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

	static float CalculateOverweight()
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

	static void AbsorbAlcohol()
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

	static void EliminateAlcohol()
	{
		float alcoholEliminated = (MAX_ALCOHOL_ELIMINATION * alcoholAbsorbed) / (4.2f + alcoholAbsorbed) / 60.0f;
		alcoholAbsorbed -= alcoholEliminated;
		if (alcoholAbsorbed < 0)
			alcoholAbsorbed = 0;
		print("eliminated " + alcoholEliminated + "remaining " + alcoholAbsorbed);
	}

	static public void Drink(float alcoholQuantity)
	{
		alcoholDrunk += alcoholQuantity;
	}

}