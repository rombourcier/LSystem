using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapGenerator : MonoBehaviour ,ILSystem
{
    [SerializeField] string m_sFirsValue;
    [SerializeField] uint m_iIterration;
    [SerializeField] Vector3 m_StartPos;
    [SerializeField] float m_DistanceBetweenCube = 1;
    [SerializeField] GameObject m_RoomPrefab;
    [SerializeField] Color m_Color =Color.white;
    
    Vector3 m_currentPos;
    Vector3 m_Direction;
    List<Vector3> PosSaved = new List<Vector3>();
    [SerializeField] List<Rules> m_Rules = new List<Rules>();
    [SerializeField] List<GameObject> m_Rooms = null;
    public string FirstValue() => m_sFirsValue;

    public uint Iterration() => m_iIterration;

    public void ReadResult()
    {
        if(m_Rooms.Count > 0)
            ClearMap();
        m_currentPos = m_StartPos;
        m_Direction = Vector3.forward;
        RB_LSystem.InterpolateResult(this);
    }

    public List<Rules> Rules() => m_Rules;
    public void Start()
    {
        ReadResult();
    }
    public void InstantiateCube()
    {
        m_RoomPrefab.GetComponent<MeshRenderer>().sharedMaterial.color = m_Color;
        m_Rooms.Add(Instantiate(m_RoomPrefab, m_currentPos + m_Direction * m_DistanceBetweenCube, new Quaternion()));
        m_currentPos += m_Direction * m_DistanceBetweenCube;
    }
    public void RotateDir(int angleDegree)
    {
        float angle = angleDegree * Mathf.Deg2Rad;
        float _x = m_Direction.x * Mathf.Cos(angle) - m_Direction.z * Mathf.Sin(angle);
        float _y = m_Direction.x * Mathf.Sin(angle) + m_Direction.z * Mathf.Cos(angle);
        m_Direction.x = _x;
        m_Direction.z = _y;
    }
    public void AddRed(float R)
    {
        m_Color += new Color(R,0,0);
    }
    public void AddBlue(float B)
    {
        m_Color += new Color(0, 0, B);
    }
    public void AddGreen(float G)
    {
        m_Color += new Color(0, G, 0);
    }
    public void SaveCurrentPos()
    {
        PosSaved.Add(m_currentPos);
    }
    public void GoToLaseSavePos()
    {
        m_currentPos = PosSaved[PosSaved.Count - 1];
        PosSaved.RemoveAt(PosSaved.Count - 1);
    }
    public void ChangeAltitude(float _Value)
    {
        m_currentPos.y += _Value;
    }
    public void AvancerCurrentPos()
    {
        m_currentPos += m_Direction * m_DistanceBetweenCube;
    }
    public void ClearMap()
    {
        while (m_Rooms.Count > 0)
        {
            GameObject toDestroy = m_Rooms[0];
            m_Rooms.RemoveAt(0);
            DestroyImmediate(toDestroy);
        }
    }


}
