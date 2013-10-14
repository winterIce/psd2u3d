using UnityEngine;
using System.Collections;
using Winter;
using LitJson;
public class WinterPanel_Stepper : MonoBehaviour 
{
	void Start () 
	{
	    JsonData jd = Winter.Utils.Str2Json("StepperSkin.txt");
		WinterComponent wc = new WinterComponent();
		wc.m_Entity = GameObject.Find("wPanel");
	    wc.skin = jd;
	}
}
