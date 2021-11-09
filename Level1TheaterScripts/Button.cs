using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject theText;
	public bool isVisible = false;

	public void ButtonPress() {
		if(isVisible == false){
			theText.SetActive(true);
			isVisible = true;
		}
		else {
			theText.SetActive(false);
			isVisible = false;			
		}
	}

}
