using UnityEngine;
using System.Collections;

public class TestUIEventListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    UIEventListener uel = gameObject.AddComponent("UIEventListener") as UIEventListener;
	    UIEventListener.Get(gameObject).onClick = OnPress;
	}
	
	public void OnPress(GameObject obj) 
	{
		Debug.Log("fuck123");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
