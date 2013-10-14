using System.IO;
using UnityEngine;
using UnityEditor;
using System.Collections; 

//文件名和类名字和方法可以随便写

public class BuildSceneEditor
{
    [@MenuItem("build/BuildWebplayerStreamed")]  
    static void Build(){  
        string[] levels = new string[]{"Assets/Scene/abc.unity"};  
        BuildPipeline.BuildStreamedSceneAssetBundle(levels,"abc.unity3d",BuildTarget.WebPlayer);  
    }
	
	[MenuItem("build/Create AssetBunldes Main")]
    static void CreateAssetBunldesMain ()
    {
	    Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

	    foreach (Object obj in SelectedAsset) 
	    {
		    string sourcePath = AssetDatabase.GetAssetPath (obj);
		    /*
		     * 本地测试：建议最后将Assetbundle放在StreamingAssets文件夹下，如果没有就创建一个，因为移动平台下只能读取这个路径
		       StreamingAssets是只读路径，不能写入
		       服务器下载：就不需要放在这里，服务器上客户端用www类进行下载。
		    */
		    string targetPath = Application.dataPath + "/StreamingAssets/" + obj.name + ".assetbundle";
		    if (BuildPipeline.BuildAssetBundle (obj, null, targetPath, BuildAssetBundleOptions.CollectDependencies)) 
			{
 				Debug.Log(obj.name +"资源打包成功");
		    } 
		    else 
		    {
				Debug.Log(obj.name +"资源打包失败");
		    }
	     }
	     //刷新编辑器
	     AssetDatabase.Refresh ();
    }
	
	 [MenuItem("build/Create AssetBunldes ALL")]
     static void CreateAssetBunldesALL ()
     {
	     Caching.CleanCache ();
	     string Path = Application.dataPath + "/StreamingAssets/ALL.assetbundle";
	     Object[] SelectedAsset = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
	     foreach (Object obj in SelectedAsset) 
	     {
		    Debug.Log ("Create AssetBunldes name :" + obj);
	     }
	     
	     if (BuildPipeline.BuildAssetBundle (null, SelectedAsset, Path, BuildAssetBundleOptions.CollectDependencies))
		 {
		    AssetDatabase.Refresh ();
	     } 
		 else 
		 {
	     }
     }
}