namespace Winter
{
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class Button : Container
	{
		private BoxCollider m_BoxCollider;
		private UIEventListener m_UIEventListener;
		private UIButtonMessage m_UIButtonMessage = null;
		private bool _enabled; 
		
		/*
		private UIButton m_UIButton;
		private UIButtonScale m_UIButtonScale;
		private UIButtonOffset m_UIButtonOffset;
		private UIButtonSound m_UIButtonSound;
		private TweenScale m_TweenScale;
		private TweenPosition m_TweenPosition;
		*/
		private string _state;
		public const string STATE_NORMAL = "normal";
		public const string STATE_OVER = "over";
		public const string STATE_DOWN = "down";
		public const string STATE_DISABLE = "disable";
		
		private Label m_label;
		private Image m_image;
		
		public Button():base()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			m_Entity = new GameObject();
			AddComonent();
			this.enabled = true;
		}
		
		public void AddComonent()
		{
			m_UIEventListener = m_Entity.AddComponent<UIEventListener>();
			/*
			m_UIButton = m_Entity.AddComponent<UIButton>();
			m_UIButtonScale = m_Entity.AddComponent<UIButtonScale>();
			m_UIButtonOffset = m_Entity.AddComponent<UIButtonOffset>();
			m_UIButtonSound = m_Entity.AddComponent<UIButtonSound>();
			m_TweenScale = m_Entity.AddComponent<TweenScale>();
			m_TweenPosition = m_Entity.AddComponent<TweenPosition>();
			*/
			
			/**
			 * 层级关系很重要，不然点击不了按钮，跟整套UI要一致
			 */ 
			m_Entity.layer = WinterConst.UILAYER;
		}
		
		public override void AfterSkin()
		{
			m_BoxCollider = m_Entity.AddComponent<BoxCollider>();
			m_BoxCollider.isTrigger = true; 
			m_BoxCollider.size = new Vector3(this.width,this.height,1f);
			m_BoxCollider.center = new Vector3(0f,0f,-0.5f);
			m_BoxCollider.transform.position = new Vector3(0f,0f,0f);
		}
		
		
		public void OnPress(GameObject obj, bool isPress)
		{		
			if(isPress)
			{
				this.state = STATE_DOWN;
			}
			else
			{
				this.state = STATE_OVER;
			}
		}
		
		public void OnHover(GameObject obj, bool isHover)
		{ 
			if(isHover)
			{
				this.state = STATE_OVER;
			}
			else
			{
				this.state = STATE_NORMAL;
			}
		}
		
		public void AddEventListener()
		{
			UIEventListener.Get(m_Entity).onPress = OnPress;
		    UIEventListener.Get(m_Entity).onHover = OnHover;
		}
		
		
		public void AddEventListener(UIButtonMessage.Trigger type, string func, GameObject obj, string s)
		{
			m_UIButtonMessage = m_Entity.AddComponent<UIButtonMessage>();
	        m_UIButtonMessage.trigger = type;
		    m_UIButtonMessage.functionName = func;
			m_UIButtonMessage.target = obj;
			m_UIButtonMessage.parameterString = s;
		}
		
		private void RemoveEventListener()
		{
			if(m_UIButtonMessage)
			{
			    Destroy(m_UIButtonMessage);
			    m_UIButtonMessage = null;
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
				foreach (var item in children)   
				{
					IStateChangeable child = item.Value as IStateChangeable;
					if(child != null)
					{
						child.state = this._state;
					}
				}
            }
        }
		
		
		public bool enabled
		{
		    get 
			{
				return this._enabled;
			}
			set
			{
				this._enabled = value;
				if( value )
				{
					AddEventListener();
					this.state = STATE_NORMAL;
				}
				else
				{
					RemoveEventListener();
					this.state = STATE_DISABLE;
				}
			}
		}
		
		protected override void ConfigChildren()
		{
			foreach (var item in children)   
			{
				DisplayObject child = item.Value;
				if(child is Label)
				{
					m_label = child as Label;
				}
				else if(child is Image)
				{
					m_image = child as Image;
				}
			}
		}
    }
}
