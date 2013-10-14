namespace Winter
{
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class MyDragDropRoot : WinterComponent
	{
		private UIPanel m_UIPanel;
		private DragDropRoot m_DragDropRoot;
		public MyDragDropRoot():base()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			m_Entity = new GameObject();
			m_UIPanel = m_Entity.AddComponent<UIPanel>() as UIPanel;
			m_DragDropRoot = m_Entity.AddComponent<DragDropRoot>() as DragDropRoot;
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
