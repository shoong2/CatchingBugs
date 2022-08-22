using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class testJson : MonoBehaviour
{
     void Start() {
        testClass testclass = new testClass();
        testclass.m_nLevel = 12;
        testclass.m_vecPosition = new Vector3(3.4f, 5.6f, 7.8f);

        string str = JsonUtility.ToJson(testclass);

        Debug.Log("ToJson : " + str);

        testClass testclass2 = JsonUtility.FromJson<testClass>(str);
        testclass2.printData();


        //file save

        testClass testclass3 = new testClass(); 
        testclass3.m_nLevel = 99;
        testclass3.m_vecPosition = new Vector3(8.1f, 9.2f, 7.2f);

        File.WriteAllText(Application.dataPath + "/plzJson.json", JsonUtility.ToJson(testclass3)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class testClass
{
    public int m_nLevel;
    public Vector3 m_vecPosition;

    public void printData()
    {
        Debug.Log("Level : " + m_nLevel);
        Debug.Log("Position : " + m_vecPosition);
    }
}
