using System;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections; 
using System.Text.RegularExpressions;
 
//文件名和类名字和方法可以随便写

public class WinterAtlas{  
	
	[@MenuItem("build/WinterAtlas")]  
    static void BuildSprite()
	{
		GameObject[] arrGameObject = Selection.gameObjects;
		foreach(GameObject obj in arrGameObject)
		{
			/*
			 * css文件
			 */ 
			StreamReader sr = File.OpenText(Application.dataPath + @"/StreamingAssets/StepperCss.txt"); 
            string line; 
			/*
			 * 格式如下
			 * .sprite-background{ background-position: 0 0; width: 200px; height: 200px; } 
			 */
			string spName = "";
			string left = "";
			string top = "";
			string width = "";
			string height = "";
			int index;
			UIAtlas ua = obj.GetComponent<UIAtlas>();
            while ((line = sr.ReadLine()) != null) 
            { 
                Debug.Log(line);	 
					
                Regex regex = new Regex(@"(.*)background-position:\s{1}(.*?)\s{1}(.*?);\s{1}width:\s{1}(.*?);\s{1}height:\s{1}(.*?);"); 
                MatchCollection matches = regex.Matches(line); 
				
				foreach(Match m in matches) 
                {
					foreach(string name in regex.GetGroupNames()) 
                    { 
                        Debug.Log(name+"==="+m.Groups[name].Value);
						index = int.Parse(name);
						switch (index)
						{
							case 1:
							    spName = m.Groups[name].Value.Replace(".","").Replace("{","");
							break;
						    case 2:
							    left = m.Groups[name].Value.Replace("px","").Replace("-","");
							break;
							case 3:
							    top = m.Groups[name].Value.Replace("px","").Replace("-","");
							break;
							case 4:
							    width = m.Groups[name].Value.Replace("px","").Replace("-","");
							break;
							case 5:
							    height = m.Groups[name].Value.Replace("px","").Replace("-","");
							break;
						}
					}
                }
				Debug.Log(obj.name);
			    UIAtlas.Sprite us = new UIAtlas.Sprite();
			    us.name = spName;
			    us.outer = new Rect(float.Parse(left), float.Parse(top), float.Parse(width), float.Parse(height));
			    us.inner = new Rect(0f, 0f, float.Parse(width), float.Parse(height));
		 	    ua.spriteList.Add(us);
			}
            sr.Close();
		}
	}
}