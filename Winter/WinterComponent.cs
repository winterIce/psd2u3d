namespace Winter
{
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class WinterComponent : DisplayObject , ISkinable
	{
		protected JsonData _skin; 
		
		public Dictionary<string, DisplayObject> children = new Dictionary<string, DisplayObject>();
		
		protected void AddChild(DisplayObject child)
		{
			child.m_Entity.transform.parent = this.m_Entity.transform;
		    this.children.Add(child.wName, child);
			/**
			 * 为什么按钮设置其父对象后会默认放大240scale?只是按钮是这样吗?添加到父对象后，需要重新设置localPosition, localScale
			 */ 
			if(child is Button || child is DragBar || child is MyDragDropRoot || child is Container) 
			{
				child.m_Entity.transform.localScale = new Vector3(1f, 1f, 1f); 
			}
			child.fx = -this.width/2 + child.x + child.width/2;
			child.fy = this.height/2 - child.y - child.height/2;
			child.m_Entity.transform.localPosition = new Vector3(child.fx,child.fy,-1f);
		}
		
		public override JsonData skin
		{
			get
			{
				return this._skin;
			}
			set
			{
				this._skin = value; 
				this.m_Entity.name = this._skin["name"].ToString();
				this.x = float.Parse(this._skin["x"].ToString());
				this.y = float.Parse(this._skin["y"].ToString());
				this.width = float.Parse(this._skin["width"].ToString());
				this.height = float.Parse(this._skin["height"].ToString());
				
				this.m_Entity.transform.localPosition = new Vector3(x, y, 0f);
				this.wName = this._skin["name"].ToString();
				if(_skin["children"] != null)
				{
					CreateChildren(_skin);
				}
				ConfigChildren();
			}
		}
		
	    private void CreateChildren(JsonData skin)
		{
			JsonData jd = skin["children"];
			int len = jd.Count;
			for(int i = len - 1 ; i >= 0 ; i--)
			{
				JsonData childSkin = jd[i];
				ISkinable child = ComponentFactory.createComponentByType(childSkin["type"].ToString());
				if(child != null)
				{
					DisplayObject c = child as DisplayObject;
					Debug.Log("nimei" + c);
					c.wName = childSkin["name"].ToString();
					
					child.skin = childSkin;
						
					child.AfterSkin();
					
					this.AddChild(c);
				}
			}
		}
		
		protected virtual void ConfigChildren()
		{
		}
    }
}
