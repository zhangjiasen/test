using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // createXml();
        showXml();
	}
	
    public void showXml()
 	{
 	    string filepath = Application.streamingAssetsPath + @"/my.xml";
 	    if(File.Exists (filepath))
 	    {
 	         XmlDocument xmlDoc = new XmlDocument();
 	         xmlDoc.Load(filepath);
 	         XmlNodeList nodeList=xmlDoc.SelectSingleNode("transforms").ChildNodes;
 	        //遍历每一个节点，拿节点的属性以及节点的内容
 	         foreach(XmlElement xe in nodeList)
 	         {
 	            Debug.Log("Attribute :" + xe.GetAttribute("name"));
 	            Debug.Log("NAME :" + xe.Name);
 	            foreach(XmlElement x1 in xe.ChildNodes)
 	            {
 	                if(x1.Name == "y")
 	                {
 	                    Debug.Log("VALUE :" + x1.InnerText);
 	 
 	                }
 	            }
 	         }
 	         Debug.Log("all = " + xmlDoc.OuterXml);
 	 
 	    }
 	}

    public void createXml()
 	{
 	           //xml保存的路径，这里放在Assets路径 注意路径。
 	    string filepath = Application.dataPath + @"/my.xml";
 	           //继续判断当前路径下是否有该文件
 	    if(!File.Exists (filepath))
 	    {
 	                     //创建XML文档实例
 	         XmlDocument xmlDoc = new XmlDocument();
 	                     //创建root节点，也就是最上一层节点
 	         XmlElement root = xmlDoc.CreateElement("transforms");
 	                      //继续创建下一层节点
 	         XmlElement elmNew = xmlDoc.CreateElement("rotation");
 	                    //设置节点的两个属性 ID 和 NAME
 	         elmNew.SetAttribute("id","0");
 	         elmNew.SetAttribute("name","momo");
 	           //继续创建下一层节点
 	             XmlElement rotation_X = xmlDoc.CreateElement("x");
 	                 //设置节点中的数值
 	                 rotation_X.InnerText = "0";
 	                XmlElement rotation_Y = xmlDoc.CreateElement("y");
 	                rotation_Y.InnerText = "1";
 	                XmlElement rotation_Z = xmlDoc.CreateElement("z");
 	                 rotation_Z.InnerText = "2";
 	                //这里在添加一个节点属性，用来区分。。
 	       rotation_Z.SetAttribute("id","1");
 	 
 	         //把节点一层一层的添加至XMLDoc中 ，请仔细看它们之间的先后顺序，这将是生成XML文件的顺序
 	         elmNew.AppendChild(rotation_X);
 	         elmNew.AppendChild(rotation_Y);
 	         elmNew.AppendChild(rotation_Z);
 	         root.AppendChild(elmNew);
 	         xmlDoc.AppendChild(root);
 	         //把XML文件保存至本地
 	         xmlDoc.Save(filepath);
 	         Debug.Log("createXml OK!");
 	    }
 	}

	// Update is called once per frame
	void Update () {
	
	}
}
