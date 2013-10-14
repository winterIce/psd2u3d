namespace Winter
{
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class Image : DisplayObject , ISkinable  , IStateChangeable
	{
		private UISprite m_UISprite;
		private JsonData _skin;
		private string _state;
		private const string DEFAULT_STATE = "normal";
		
		public Image():base()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			m_Entity = new GameObject();
			m_UISprite = m_Entity.AddComponent("UISprite") as UISprite;
			GameObject al = Utils.CreateInstance(WinterConst.ATLAS);
			m_UISprite.atlas = al.GetComponent<UIAtlas>();
			fx = 0;
			fy = 0;
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
				this._state = DEFAULT_STATE;
				this.m_Entity.name = this._skin["name"].ToString();
				UpdateState();
			}
		}
		
		public string state
        {
            get
            {
                return this._state; 
            }
            set
            {
                this._state = value;
				UpdateState();
            }
        }
		
	    public void UpdateState()
	    {
	        JsonData obj = _skin[_state];
			this.x = float.Parse(_skin["x"].ToString()) + float.Parse(obj["x"].ToString());
			this.y = float.Parse(_skin["y"].ToString()) + float.Parse(obj["y"].ToString());
			this.width = float.Parse(obj["width"].ToString());
			this.height = float.Parse(obj["height"].ToString());
			this.m_Entity.transform.localScale = new Vector3(width, height, 1f);
			this.m_Entity.transform.localPosition = new Vector3(x,y,-1f);
			
			m_UISprite.spriteName = obj["link"].ToString();
			m_UISprite.type = UISprite.Type.Sliced;
	    }
		
		public override void AfterSkin()
		{
			
		}
    }
}
