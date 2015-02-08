﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	Animator optionsAnim;
	public Text xAxis_Text;
	public Text yAxis_Text;

	// Use this for initialization
	void Start () {
	
		Screen.lockCursor = false;
		optionsAnim = GameObject.FindGameObjectWithTag ("OptionsPanel").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetMouseX(float xAxis){
		
		PlayerPrefs.SetFloat("xAxis", xAxis);
		xAxis_Text.text = xAxis.ToString();
	}
	
	public void SetMouseY(float yAxis){
		
		PlayerPrefs.SetFloat("yAxis", yAxis);
		yAxis_Text.text = yAxis.ToString();
	}

	public void ShowOptions(){
		optionsAnim.SetBool ("Show", true);
	}

	public void HideOptions(){
		optionsAnim.SetBool ("Show", false);
	}

	public void QuitGame(){
		
		Application.Quit();
	}
}
