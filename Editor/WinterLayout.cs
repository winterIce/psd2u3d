using Winter;
using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections; 
using System.Text.RegularExpressions;
using LitJson;


public class WinterLayout{  
	
	[@MenuItem("Winter/ScrollBar")]  
    static void WinterLayoutScrollBar()
	{
		GameObject[] arrGameObject = Selection.gameObjects;
		foreach(GameObject obj in arrGameObject)
		{
			JsonData jd = Winter.Utils.Str2Json("ScrollBarSkin.txt");
		    WinterComponent wc = new WinterComponent();
		    wc.m_Entity = obj;
	        wc.skin = jd;
		}
	}
	
	[@MenuItem("Winter/Stepper")]
	static void WinterLayoutStepper()
	{
		GameObject[] arrGameObject = Selection.gameObjects;
		foreach(GameObject obj in arrGameObject)
		{
			JsonData jd = Winter.Utils.Str2Json("StepperSkin.txt");
		    WinterComponent wc = new WinterComponent();
		    wc.m_Entity = obj;
	        wc.skin = jd; 
		}
	}
	
	[@MenuItem("Winter/RadioButtonGroup")]
	static void WinterLayoutRadioButtonGroup()
	{
		GameObject[] arrGameObject = Selection.gameObjects;
		foreach(GameObject obj in arrGameObject)
		{
			JsonData jd = Winter.Utils.Str2Json("RadioButtonGroupSkin.txt");
		    WinterComponent wc = new WinterComponent();
		    wc.m_Entity = obj;
	        wc.skin = jd; 
		}
	}
	
	[@MenuItem("Winter/Button")]
	static void WinterLayoutButton()
	{
		GameObject[] arrGameObject = Selection.gameObjects;
		foreach(GameObject obj in arrGameObject)
		{
			JsonData jd = Winter.Utils.Str2Json("Skin2.txt");
		    WinterComponent wc = new WinterComponent();
		    wc.m_Entity = obj;
	        wc.skin = jd; 
		}
	}
	
}