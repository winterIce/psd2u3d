namespace Winter
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
	using System.IO;
	using LitJson;
    public class Utils : MonoBehaviour
	{
	    public static Dictionary<string, Object> map = new Dictionary<string, Object> ();
	    public static GameObject CreateInstance(string path)
        {
		    UnityEngine.Object obj = null;
		    if (!map.ContainsKey (path)) 
	        { 
	            obj = Resources.Load (path);
		        map[path] = obj;
		    } 
		    else 
		    {
			    obj = map [path];
		    }
		    if(obj == null)
		    {
			    return null;
		    }
		    GameObject ins = GameObject.Instantiate (obj) as GameObject;	
		    DontDestroyOnLoad(ins);
		    return ins;
        }
		
		
		public static JsonData Str2Json(string skin)
		{
			#if UNITY_EDITOR  
                string filepath = Application.dataPath +"/StreamingAssets/"+skin;  
            #elif UNITY_IPHONE  
                string filepath = Application.dataPath +"/Raw/"+skin;  
            #endif  
		
		    StreamReader sr  = File.OpenText(filepath);  
            string  strLine = sr.ReadToEnd();
            JsonData jd = JsonMapper.ToObject(strLine); 
		    return jd;
		}
		
		public static DisplayObject GetDescendant(WinterComponent obj, string nameChain)
		{
			Debug.Log(obj.children.ContainsKey("winterButton"));
			foreach(var item in obj.children)
			{
				Debug.Log(item.Key);
			}
			string[] nameList = nameChain.Split('/');
			WinterComponent curContainer = obj;
			DisplayObject curObj = null;
			string curName;
			
			for(int i = 0 , len = nameList.Length ; i < len ; i++)
			{
				curName = nameList[i];
				curObj = curContainer.children[curName];
				if(curObj == null)
				{
					Debug.Log (curName+" not exsist");
					return null;
				}
				if( i < len-1 )
				{
					curContainer = curObj as WinterComponent;
					if(curContainer == null)
					{
						Debug.Log(curName+" not a container");
						return null;
					}
				}
			}
			return curObj;
		}
		/*
		public function getDescendant(nameChain:String):DisplayObject
		{
			var nameList:Array = nameChain.split("/");
			var currentContainer:DisplayObjectContainer = this;
			var currentName:String;
			var currentObj:DisplayObject;
			while(nameList.length > 0)
			{
				currentName = nameList.shift();
				currentObj = currentContainer.getChildByName(currentName);
				if(currentObj == null)
				{
					handleError("显示对象 " + currentName + " 不存在!");
					return null;
				}
				if(nameList.length > 0)
				{
					currentContainer = currentObj as DisplayObjectContainer;
					if(currentContainer == null)
					{
						handleError("显示对象 " + currentName + " 不是容器");
						return null;
					}
				}
			}
			return currentObj;
		}
		*/
		
		
    }
}
