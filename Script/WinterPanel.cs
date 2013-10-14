using UnityEngine;
using System.Collections;
using Winter;
using LitJson;
public class WinterPanel : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	    JsonData jd = Winter.Utils.Str2Json("skin2.txt");
		WinterComponent wc = new WinterComponent();
		wc.m_Entity = GameObject.Find("wPanel");
	    wc.skin = jd;
		//DisplayObject obj = Utils.GetDescendant(wc, "winterButton/winterImage");
		//Debug.Log(obj);
		WinterComponent bb = wc.children["winterContainer"] as WinterComponent;
	    Button _bb = bb.children["winterButton"] as Button;
		_bb.AddEventListener(UIButtonMessage.Trigger.OnClick, "OnClickHandler", gameObject, "winter");
		
		WinterComponent bb2 = wc.children["winterContainer"] as WinterComponent;
	    Button _bb2 = bb2.children["summerButton"] as Button;
		_bb2.AddEventListener(UIButtonMessage.Trigger.OnClick, "OnClickHandler", gameObject, "summer");
	}
	
	public void OnClickHandler(string s)
	{
		Debug.Log(s);
	}
}
