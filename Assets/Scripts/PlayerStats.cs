﻿using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	//We might move Health here.
	//These are just the stat names from the prototype.
	public float precisionGuns;
	public float powerGuns;
	public float sharpWeapon;
	public float bluntWeapon;
	public float charm;
	public float intimidate;
	public float movement;
	public float medical;
	public float crafting;
	public float repairing;
	public float[] inv;
	public float currDam;
	public float bestWep;
	public float bestDef;
	// Use this for initialization
	void Start () {
		//Change these once we set up persistant stat levels.
		precisionGuns = powerGuns = sharpWeapon = bluntWeapon
			= charm = intimidate = movement = medical = crafting
				= repairing = 20;
		if (PlayerPrefs.GetInt("Talent0") == 1) {
			precisionGuns += 10;
			powerGuns += 10;
			sharpWeapon += 10;
			bluntWeapon += 10;
		}
		inv = new float[15];
		currDam = 10;

		//fill the player's inventory with persistent items
		for (int i = 0; i<inv.Length; i++){
			inv [i] = PlayerPrefs.GetFloat("Inventory " + i.ToString());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InvCheck() {
		//Inv check: Checks inventory for strongest weapon/defense
		//Inv codes:
		//1 = Wood Spear
		//2 = Stone Spear
		//3 = Wood Shield
		//4 = Stone Shield
		bestWep = 0;
		for (int i = 0; i < 14; i++) {
			if((inv[i] == 1 || inv[i] == 2) && inv[i] > bestWep)
				bestWep = inv[i];
		}
		if (bestWep == 0)
						currDam = 10;
				else if (bestWep == 1)
						currDam = 20;
				else if (bestWep == 2)
						currDam = 40;
	}
}
