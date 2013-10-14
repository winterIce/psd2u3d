namespace Winter
{
	using System;
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class ScrollBar : Container
	{
		private GameObject m_objScrollBar = null;
		public ScrollBar():base()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			
		}
		
		protected override void ConfigChildren()
		{
			m_objScrollBar = new GameObject();
			m_objScrollBar.transform.parent = this.m_Entity.transform;
			m_objScrollBar.name = "sb";
			m_objScrollBar.layer = WinterConst.UILAYER;
			UIScrollBar usb = m_objScrollBar.AddComponent<UIScrollBar>();
			UIPanel upn = m_objScrollBar.AddComponent<UIPanel>();
			
		    foreach (var item in children) 
			{
                DisplayObject obj = item.Value;
				if(obj.wName == "viewport")
				{
					UIPanel uipanel = obj.m_Entity.AddComponent<UIPanel>();
					uipanel.clipping = UIDrawCall.Clipping.SoftClip;
					uipanel.clipRange = new Vector4(0, 0, obj.width, obj.height);
					uipanel.clipSoftness = new Vector2(10f, 10f);
					
					UIDraggablePanel udp = obj.m_Entity.AddComponent<UIDraggablePanel>();
					udp.scale = new Vector3(1f, 0f, 0f);
					udp.scrollWheelFactor = -2f;
					udp.verticalScrollBar = m_objScrollBar.GetComponent<UIScrollBar>();
					obj.m_Entity.transform.localScale = new Vector3(-1f, -1f, -1f);
					obj.m_Entity.layer = WinterConst.UILAYER;
				}
			}
			
			/* 
			 * 运行时赋值给UIScrollBar的foreground和background会使原来的gameobject失效,shit!!
			  
			GameObject ti = GameObject.Find("thumb/thumbImage");
			UISprite uitb = ti.GetComponent<UISprite>();
			usb.foreground = uitb;
			uitb.depth = 3;
			uitb.pivot = UIWidget.Pivot.Center;
			
			UISprite uitk = GameObject.Find("track/gundongdiban").GetComponent<UISprite>();
			usb.background = uitk;
			uitk.depth = 2;
			uitk.pivot = UIWidget.Pivot.Center;
			
			usb.direction = UIScrollBar.Direction.Vertical;
			usb.alpha = 1f;
			usb.barSize = 0.2f;
			usb.scrollValue = 0f;
			*/
			
		}
    }
}
