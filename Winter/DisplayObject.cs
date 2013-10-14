namespace Winter
{
    using UnityEngine;
	using LitJson;

    public class DisplayObject : MonoBehaviour , ISkinable
    {
		public float x;
		public float y;
		public float fx;
		public float fy;
		public float width;
		public float height;
		public GameObject m_Entity;
		public string wName;
		public virtual JsonData skin{ get; set;}
		public virtual void AfterSkin(){}
    }
}

