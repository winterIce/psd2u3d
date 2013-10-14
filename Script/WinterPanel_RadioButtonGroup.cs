using UnityEngine;
using System.Collections;
using Winter;
using LitJson;
public class WinterPanel_RadioButtonGroup : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	    JsonData jd = Winter.Utils.Str2Json("skin3.txt");
		WinterComponent wc = new WinterComponent();
		wc.m_Entity = GameObject.Find("wPanel");
	    wc.skin = jd;
		Container c = wc.children["RadioButtonGroup"] as Container;
		RadioButtonGroup r = c.children["tabs"] as RadioButtonGroup;
	    r.RadioButtonGroupDispatch += DoSomething;
	}
	private void DoSomething(int i)
	{
		Debug.Log("outer" + i);
	}
}
