using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using LitJson;
public class MyEditor : Editor
{
	//将所有游戏场景导出为XML格式
	[MenuItem ("GameObject/ExportXML")]
	static void ExportXML ()
	{
	    string filepath = Application.dataPath + @"/StreamingAssets/my.xml";
		if(!File.Exists (filepath))
		{
			File.Delete(filepath);
		}
		
		XmlDocument xmlDoc = new XmlDocument();
		XmlElement root = xmlDoc.CreateElement("gameObjects");
		//遍历所有的游戏场景
		Debug.Log (UnityEditor.EditorBuildSettings.scenes.Length);
		foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
			Debug.Log (S.path);
            if (S.enabled)
            {
                string name = S.path;
                //打开这个关卡
				EditorApplication.OpenScene(name);
				XmlElement scenes = xmlDoc.CreateElement("scenes");
		        scenes.SetAttribute("name",name);
				foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
				{
    				if (obj.transform.parent == null)
    				{
						 XmlElement gameObject = xmlDoc.CreateElement("gameObjects");
						 gameObject.SetAttribute("name",obj.name);

						 gameObject.SetAttribute("asset",obj.name + ".prefab");
						 XmlElement transform = xmlDoc.CreateElement("transform");
						 XmlElement position = xmlDoc.CreateElement("position");
		 				 XmlElement position_x = xmlDoc.CreateElement("x");
		 				 position_x.InnerText = obj.transform.position.x+"";
	   					 XmlElement position_y = xmlDoc.CreateElement("y");
						 position_y.InnerText = obj.transform.position.y+"";
						 XmlElement position_z = xmlDoc.CreateElement("z");
						 position_z.InnerText = obj.transform.position.z+"";
						 position.AppendChild(position_x);
		 				 position.AppendChild(position_y);
						 position.AppendChild(position_z);

						 XmlElement rotation = xmlDoc.CreateElement("rotation");
						 XmlElement rotation_x = xmlDoc.CreateElement("x");
		 				 rotation_x.InnerText = obj.transform.rotation.eulerAngles.x+"";
	   	 				 XmlElement rotation_y = xmlDoc.CreateElement("y");
		 				 rotation_y.InnerText = obj.transform.rotation.eulerAngles.y+"";
						 XmlElement rotation_z = xmlDoc.CreateElement("z");
		 				 rotation_z.InnerText = obj.transform.rotation.eulerAngles.z+"";
		 				 rotation.AppendChild(rotation_x);
		 				 rotation.AppendChild(rotation_y);
						 rotation.AppendChild(rotation_z);

		 				 XmlElement scale = xmlDoc.CreateElement("scale");
		 				 XmlElement scale_x = xmlDoc.CreateElement("x");
						 scale_x.InnerText = obj.transform.localScale.x+"";
	   					 XmlElement scale_y = xmlDoc.CreateElement("y");
		 				 scale_y.InnerText = obj.transform.localScale.y+"";
		 				 XmlElement scale_z = xmlDoc.CreateElement("z");
						 scale_z.InnerText = obj.transform.localScale.z+"";

		 				 scale.AppendChild(scale_x);
		 				 scale.AppendChild(scale_y);
		 				 scale.AppendChild(scale_z);

		 				 transform.AppendChild(position);
		 				 transform.AppendChild(rotation);
		 				 transform.AppendChild(scale);	

		 				 gameObject.AppendChild(transform);
     	 				 scenes.AppendChild(gameObject);
						 root.AppendChild(scenes);
         				 xmlDoc.AppendChild(root);
         				 xmlDoc.Save(filepath);

    				}
				}
            }
        }
        //刷新Project视图， 不然需要手动刷新哦
		 AssetDatabase.Refresh();
	}

	//将所有游戏场景导出为JSON格式
	[MenuItem ("GameObject/ExportJSON")]
	static void ExportJSON ()
	{
		string filepath = Application.dataPath + @"/StreamingAssets/json.txt";
      	FileInfo t = new FileInfo(filepath);
		if(!File.Exists (filepath))
		{
			File.Delete(filepath);
		}
        StreamWriter sw = t.CreateText();

		StringBuilder sb = new StringBuilder ();
        JsonWriter writer = new JsonWriter (sb);
		writer.WriteObjectStart ();
		writer.WritePropertyName ("GameObjects");
		writer.WriteArrayStart ();

		foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            if (S.enabled)
            {
                string name = S.path;
				EditorApplication.OpenScene(name);
				writer.WriteObjectStart();
				writer.WritePropertyName("scenes");
 				writer.WriteArrayStart ();
				writer.WriteObjectStart();
				writer.WritePropertyName("name");
				writer.Write(name);
				writer.WritePropertyName("gameObject");
				writer.WriteArrayStart ();

				foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
				{
    				if (obj.transform.parent == null)
    				{
						writer.WriteObjectStart();
						writer.WritePropertyName("name");
						writer.Write(obj.name);

						writer.WritePropertyName("position");
				        writer.WriteArrayStart ();
						writer.WriteObjectStart();
						writer.WritePropertyName("x");
						writer.Write(obj.transform.position.x.ToString("F5"));
						writer.WritePropertyName("y");
						writer.Write(obj.transform.position.y.ToString("F5"));
						writer.WritePropertyName("z");
						writer.Write(obj.transform.position.z.ToString("F5"));
						writer.WriteObjectEnd();
						writer.WriteArrayEnd();

						writer.WritePropertyName("rotation");
				        writer.WriteArrayStart ();
						writer.WriteObjectStart();
						writer.WritePropertyName("x");
						writer.Write(obj.transform.rotation.eulerAngles.x.ToString("F5"));
						writer.WritePropertyName("y");
						writer.Write(obj.transform.rotation.eulerAngles.y.ToString("F5"));
						writer.WritePropertyName("z");
						writer.Write(obj.transform.rotation.eulerAngles.z.ToString("F5"));
						writer.WriteObjectEnd();
						writer.WriteArrayEnd();

						writer.WritePropertyName("scale");
				        writer.WriteArrayStart ();
						writer.WriteObjectStart();
						writer.WritePropertyName("x");
						writer.Write(obj.transform.localScale.x.ToString("F5"));
						writer.WritePropertyName("y");
						writer.Write(obj.transform.localScale.y.ToString("F5"));
						writer.WritePropertyName("z");
						writer.Write(obj.transform.localScale.z.ToString("F5"));
						writer.WriteObjectEnd();
						writer.WriteArrayEnd();

						writer.WriteObjectEnd();
					}
				}

				writer.WriteArrayEnd();
				writer.WriteObjectEnd();
				writer.WriteArrayEnd();
				writer.WriteObjectEnd();
			}
		}
		writer.WriteArrayEnd();
		writer.WriteObjectEnd ();

		sw.WriteLine(sb.ToString());
        sw.Close();
        sw.Dispose();
		AssetDatabase.Refresh();
	}
	
	[MenuItem ("GameObject/BINARY")]
    static void XMLJSONTOBinary ()
    {
        string filepath = Application.dataPath + @"/StreamingAssets/binary.txt";
        if(File.Exists (filepath))
        {
            File.Delete(filepath);
        }
		
        FileStream  fs = new FileStream(filepath, FileMode.Create);

        BinaryWriter bw = new BinaryWriter(fs);

        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            if (S.enabled)
            {

                string name = S.path;
                EditorApplication.OpenScene(name);
 
                foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
                {
                    if (obj.transform.parent == null)
                    {
                        bw.Write(name);
                        bw.Write(obj.name);
                        short posx = (short)(obj.transform.position.x * 100);
                        bw.Write(posx);
                        bw.Write((short)(obj.transform.position.y * 100.0f));
                        bw.Write((short)(obj.transform.position.z * 100.0f));
                        bw.Write((short)(obj.transform.rotation.eulerAngles.x * 100.0f));
                        bw.Write((short)(obj.transform.rotation.eulerAngles.y * 100.0f));
                        bw.Write((short)(obj.transform.rotation.eulerAngles.z * 100.0f));
                        bw.Write((short)(obj.transform.localScale.x * 100.0f));
                        bw.Write((short)(obj.transform.localScale.y * 100.0f));
                        bw.Write((short)(obj.transform.localScale.z * 100.0f));
                    }
                }
            }
        }
        bw.Flush();
        bw.Close();
        fs.Close();
    }

}