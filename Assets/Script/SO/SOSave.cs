using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOSave : ScriptableObject
{
    public Vector3 currentCheckPoint;

    public List<KeyCode> usedKeyCodes;
}
