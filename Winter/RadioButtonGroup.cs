namespace Winter
{
	using System;
    using UnityEngine;
    using System.Collections;
	using System.Collections.Generic;
	using LitJson;
	
    public class RadioButtonGroup : Container
	{
		List<RadioButton> m_btnList = new List<RadioButton>();
		private int m_selectedIndex;
		private bool _enabled;
		public event Action<int> RadioButtonGroupDispatch;
		
		public RadioButtonGroup():base()
		{
			Initialize();
		}
		
		private void Initialize()
		{
			m_btnList = new List<RadioButton>();
		}
		
		protected override void ConfigChildren()
		{
			int i = 0;
			foreach (var item in children) 
			{
                RadioButton child = item.Value as RadioButton;
				child.RadioButtonOnPressHandler += RadioButtonOnPressHandler;
				child.data = i.ToString();
				if(i==0)
				{
					child.selected = true;
					m_selectedIndex = 0;
				}
				m_btnList.Add(child);
				++i;
			}
		}
		
		private void RadioButtonOnPressHandler(string d)
		{
			this.m_selectedIndex = int.Parse(d);
			for(int i = 0,len = m_btnList.Count ; i < len ; i++)
			{
				if(i==this.m_selectedIndex)
				{
					continue;
				}
				m_btnList[i].selected = false;
			}
		    RadioButtonGroupDispatch(this.m_selectedIndex);	
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
				foreach(RadioButton item in m_btnList)
				{
					item.enabled = value;
				}
			}
		}
    }
}
