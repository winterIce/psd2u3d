namespace Winter
{
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class DragBar : WinterComponent
	{
		private DragDropItem m_DragDropItem;
		private BoxCollider m_BoxCollider;
		
		public DragBar():base()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			m_Entity = new GameObject();
			m_DragDropItem = m_Entity.AddComponent<DragDropItem>() as DragDropItem;
			m_Entity.layer = WinterConst.UILAYER;
		}
		
		
		public override void AfterSkin()
		{
			m_BoxCollider = m_Entity.AddComponent<BoxCollider>();
			m_BoxCollider.isTrigger = true; 
			m_BoxCollider.size = new Vector3(this.width,this.height,1f);
			m_BoxCollider.center = new Vector3(0f,0f,0f);
		}
		
		protected override void ConfigChildren()
		{
			
		}
    }
}
