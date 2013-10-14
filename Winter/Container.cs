namespace Winter
{
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class Container : WinterComponent
	{
		public Container():base()
		{
			Initialize();
		}
		
		public void Initialize()
		{
			m_Entity = new GameObject();
			m_Entity.layer = WinterConst.UILAYER;
		}
		
		public override void AfterSkin()
		{

		}
		
		protected override void ConfigChildren()
		{
			
		}
    }
}
