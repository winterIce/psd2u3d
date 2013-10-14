namespace Winter
{
	using System;
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class RadioButton : Button
	{
		private bool _selected = true;
		private string _data;
		public event Action<string> RadioButtonOnPressHandler;
		
		public RadioButton():base()
		{
			Initialize();
		}
		
		public void Initialize()
		{
			RadioButtonOnPressEventListener();
		}
		
		protected void RadioButtonOnPressEventListener()
		{
			UIEventListener.Get(m_Entity).onPress = RadioButtonOnPress;
			UIEventListener.Get(m_Entity).onHover = RadioButtonOnHover;
		}
		
		public void RadioButtonOnPress(GameObject obj, bool isPress)
		{
			if(isPress)
			{
				this.selected = true;
				RadioButtonOnPressHandler(data);
			}		
		}
		
		private void RadioButtonOnHover(GameObject obj, bool isHover)
		{
			if(this.selected == false)
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
		}
		
		
		public bool selected
		{
		    get 
			{
				return this._selected;
			}
			set
			{
				this._selected = value;
				if( value )
				{
					this.state = STATE_DOWN;
				}
				else
				{
					this.state = STATE_NORMAL;
				}
			}
		}
		
		public string data
		{
		    get 
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}
    }
}
