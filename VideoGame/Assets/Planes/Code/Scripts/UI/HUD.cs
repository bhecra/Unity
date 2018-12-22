using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Slider healtSliderbar;
    public Text scoreTxt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healtSliderbar.value = DataGame.Healt;
        scoreTxt.text = DataGame.Score.ToString();
	}
}
