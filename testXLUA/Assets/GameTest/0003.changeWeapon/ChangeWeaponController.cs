using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponController : MonoBehaviour {

    public GameObject handObj;

    public GameObject liandaoPrefab;
    public GameObject swordPrefab;

    private GameObject currentWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeToSword()
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon);
        }

        GameObject swrod = Instantiate(swordPrefab, handObj.transform);
        //swrod.transform.SetParent(handObj.transform);
        this.currentWeapon = swrod;
    }

    public void ChangeToLiandao()
    {
        if (currentWeapon)
        {
            Destroy(currentWeapon);
        }

        GameObject liandao = Instantiate(liandaoPrefab, handObj.transform);
        //liandao.transform.SetParent(handObj.transform);
        this.currentWeapon = liandao;

    }



}
