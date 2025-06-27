using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInfo", menuName = "InfoToOtherScript/Info")]
public class WeaponData : ScriptableObject
{
    public string stringInfo;
    public int intInfo;
    public GameObject gameObjectInfo;
    public bool boolInfo;
}
