using UnityEngine;
using System.Collections;

public class TestButtonMessage : MonoBehaviour {
	void Start()
	{
		gameObject.GetComponent<UICamera>().eventReceiverMask = -1;
	}
}
