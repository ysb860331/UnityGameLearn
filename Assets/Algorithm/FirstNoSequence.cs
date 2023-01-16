using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FirstNoSequence : MonoBehaviour
{
    List<int> m_nolist = new List<int>();
    private string m_randomCount = "10";
    private int m_totleCount = 10;
    int MaxCount = 15;

    private void OnGUI()
    {
        m_randomCount = GUI.TextField(new Rect(0, 0, 100, 60), m_randomCount);
        if (GUI.Button(new Rect(0, 70, 100, 60), "创建"))
        {
            RandomNumbers();
            PrintAllNo();
        }
        
        if (GUI.Button(new Rect(0, 130, 100, 60), "添加"))
        {
            AddNew();
            PrintAllNo();
        }
    }

    private void RandomNumbers()
    {
        int[] randomTest = { 3,4,5,6,10,11,12,13,14,15};
        m_nolist.AddRange(randomTest);
        // m_nolist.Clear();
        // int m_totleCount = int.Parse(m_randomCount);
        // int randomCount = 0;
        // while (randomCount < m_totleCount)
        // {
        //     int nValue = Random.Range(0, MaxCount);
        //     if (m_nolist.Contains(nValue))
        //         continue;
        //     m_nolist.Add(nValue);
        //     randomCount++;
        // }
        // m_nolist.Sort();
    }
    
    public static int Sh(int le, int r, int[] arr)
    {
        if (le + 1 == r)
            return arr[le];
 
        int mid = (le + r) / 2;
 
        if (arr[mid] == mid)
            return Sh(mid, r, arr);
 
        if (arr[mid] != mid)
            return Sh(0, mid, arr);
 
        return mid;
    }

    private void AddNew()
    {
        int nNewValue = Sh(0, m_nolist.Count-1, m_nolist.ToArray()) + 1;
        Debug.Log("newvalue: " + nNewValue);
        m_nolist.Add(nNewValue);
        m_nolist.Sort();
    }


    private void AddOne()
    {
        int nValue = 1;
        while (true)
        {
            nValue = Random.Range(1, MaxCount);
            if (!m_nolist.Contains(nValue))
            {
                m_nolist.Add(nValue);
                break;
            }
        }
        m_nolist.Sort();
        Debug.Log("AddOne: " + nValue);
    }

    private void PrintAllNo()
    {
        string noValues = "";
        for (int i = 0; i < m_nolist.Count; i++)
        {
            noValues += m_nolist[i] + ", ";
        }
        Debug.Log("noValues: " + noValues);
    }
}
