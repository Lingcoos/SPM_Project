using UnityEngine;

using System.IO;

using System.Xml;

public class XmlTest : MonoBehaviour
{



    void Start()
    {

        CreateXml();

    }



    private void CreateXml()
    {


        string path = Application.dataPath + "/XmlData.xml";


        if (File.Exists(path) == false)
        {


            XmlDocument xml = new XmlDocument();



            XmlElement root = xml.CreateElement("Object");



            XmlElement element = xml.CreateElement("Message");

            element.SetAttribute("Id", "1");



            XmlElement elementChild1 = xml.CreateElement("Contents");

            elementChild1.SetAttribute("Name", "Any");

            elementChild1.InnerText = "One More Try!";


            XmlElement elementChild2 = xml.CreateElement("Mission");

            elementChild2.SetAttribute("Task", "First");

            elementChild2.InnerText = "Just Do It!";



            element.AppendChild(elementChild1);

            element.AppendChild(elementChild2);

            root.AppendChild(element);

            xml.AppendChild(root);

            xml.Save(path);

            Debug.Log("Xml 创建成功!");

        }

    }

}
