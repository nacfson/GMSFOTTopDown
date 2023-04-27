using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/UI/ResolutionListSO")]
public class ResolutionListSO : ScriptableObject
{
    public List<int> width = new List<int>();
    public List<int> height = new List<int>();
}
