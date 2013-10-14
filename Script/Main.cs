using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Winter;
public class Main : MonoBehaviour {
	
	public static GameObject p1;
	
	void Start () 
	{
	    p1 = Utils.CreateInstance("pre_camera");
	}
}