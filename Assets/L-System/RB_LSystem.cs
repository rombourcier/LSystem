using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
public static class RB_LSystem
{
    [SerializeField] static uint m_Iterration = 1;
    [SerializeField] static List<Rules> m_Rules = null;
    [SerializeField] static string m_Start = null;
    // Start is called before the first frame update
    public static string GetResult()
    {
        string _current = m_Start;
        for (int i = 0; i < m_Iterration; i++)
        {
            _current = GetCurrentItteration(_current);
        }
        return _current;
    }
    static string GetResult(ILSystem _ISystem)
    {
        m_Iterration = _ISystem.Iterration();
        m_Rules = _ISystem.Rules();
        m_Start = _ISystem.FirstValue();
        return GetResult();
    }
    public static void InterpolateResult(ILSystem _System)
    {
        string _Result = GetResult(_System);
        for(int i = 0; i < _Result.Length;i++)
        {
            CallEvent(_Result[i].ToString());
        }
    }
    static void CallEvent(string _LetterEvent)
    {
        for (int i = 0; i < m_Rules.Count; i++)
            if (_LetterEvent == m_Rules[i].Letter())
            {
                m_Rules[i].m_OnRulesRead.Invoke();
                return;
            }
    }
    static string GetCurrentItteration(string _Current)
    {
        string _out = "";
        for (int i = 0; i < _Current.Length; i++)
            _out += GetResult(_Current[i].ToString());
        return _out;
    }
    static string GetResult(string _Entry)
    {
        for (int i = 0; i < m_Rules.Count; i++)
        {
            if (m_Rules[i].Letter() == _Entry)
                return m_Rules[i].Result();
        }
        return _Entry;
    }
}
[Serializable]
public struct Rules
{
    [SerializeField]
    string m_Letter;
    public string Letter() => m_Letter;

    [SerializeField]
    string m_Result;
    public string Result() => m_Result;

    [Serializable]
    public class RuleEvent : UnityEvent { }
    [FormerlySerializedAs("RuleEvent")]
    [SerializeField]
    public RuleEvent m_OnRulesRead;
}
