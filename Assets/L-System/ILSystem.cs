using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public interface ILSystem
{
    uint Iterration();
    string FirstValue();

    List<Rules> Rules();

    void ReadResult();

}
