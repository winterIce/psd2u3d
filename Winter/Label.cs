namespace Winter
{
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class Label : DisplayObject , ISkinable , IStateChangeable
	{
		private UILabel m_UILabel;
		private JsonData _skin;
		private string _state;
		private const string DEFAULT_STATE = "normal";
		
		public Label():base()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			m_Entity = new GameObject();
			m_UILabel = m_Entity.AddComponent("UILabel") as UILabel;
			GameObject ft = Utils.CreateInstance(WinterConst.FONT);
			m_UILabel.font = ft.GetComponent<UIFont>();
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
			this.m_Entity.transform.localPosition = new Vector3(fx, fy, -1f);
			this.m_Entity.transform.localScale = new Vector3(20f, 20f, 1f);//控制字体大小
			m_UILabel.text = obj["content"].ToString();
	    }
		
		public override void AfterSkin()
		{
			
		}
    }
}
