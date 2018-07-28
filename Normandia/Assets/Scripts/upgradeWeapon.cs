using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeWeapon : MonoBehaviour {

    public System.Type weaponType;
    public Component weapon;
	// Use this for initialization
	void Start () {

        weapon = GetComponentInParent(weaponType);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //weapon.Upgrade();
    }
}
