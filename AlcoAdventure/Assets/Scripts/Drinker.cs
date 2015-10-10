using UnityEngine;
using System.Collections;
using System;

public class Drinker//: //MonoBehaviour
{
	public static bool isInitialized = false;

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
	
	public static string Initialize(float newBodyMass, float newBodyHeight, bool newIsMale, bool newIsStomachEmpty)
	{
		string message = "";

		bodyMass = newBodyMass;
		bodyHeight = newBodyHeight;
		isMale = newIsMale;
		isStomachEmpty = newIsStomachEmpty;
		message += CalculateBMI();
		message += CalculateAbsorptionTime();
		message += CalculateLiquids();

		isInitialized = true;

		return message;
	}

	public static string UpdateStatus()
	{
		string message = "";
		timePassed += Time.deltaTime;
		if (timePassed >= 1)
		{
			timePassed = 0;
			if (alcoholDrunk > 0)
				message += AbsorbAlcohol();
			if (alcoholAbsorbed > 0)
				message += EliminateAlcohol();
		}
		return message;
	}

	public static string CalculatePromils()
	{
		promils = alcoholAbsorbed / liquidMass;
		return ("Promils = " + promils);
	}

	public static string CalculateAbsorptionTime()
	{
		if (isStomachEmpty)
			absorptionTime = 30;
		else
			absorptionTime = 60;


		return("Absorption Time = " + absorptionTime);
	}
	
	public static string CalculateBMI()
	{
		bmi = bodyMass / ((bodyHeight/100) * (bodyHeight/100));
		return ("BMI = " + bmi);
	}

	static string CalculateLiquids()
	{
		float multiplier;
		if (isMale)
			multiplier = 0.7f;
		else
			multiplier = 0.6f;

		float overweight = CalculateOverweight();
		float liquidExcess = 0.15f * overweight;

		liquidMass = multiplier * (bodyMass - overweight) + liquidExcess;
		return (bodyMass - overweight + " " + liquidMass);
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

	static string AbsorbAlcohol()
	{
		if (absorptionProgress < absorptionTime)
		{
			alcoholAbsorbed += alcoholDrunk / (absorptionTime - absorptionProgress);
			alcoholDrunk -= alcoholDrunk / (absorptionTime - absorptionProgress);
			++absorptionProgress;
		}
		else
			absorptionProgress = 0;
		return("absorbed " + alcoholAbsorbed + " \nProgress" + absorptionProgress);
	}

	static string EliminateAlcohol()
	{
		float alcoholEliminated = (MAX_ALCOHOL_ELIMINATION * alcoholAbsorbed) / (4.2f + alcoholAbsorbed) / 60.0f;
		alcoholAbsorbed -= alcoholEliminated;
		if (alcoholAbsorbed < 0)
			alcoholAbsorbed = 0;
		return("eliminated " + alcoholEliminated + "remaining " + alcoholAbsorbed);
	}

	static public void Drink(float alcoholQuantity)
	{
		alcoholDrunk += alcoholQuantity;
	}

}