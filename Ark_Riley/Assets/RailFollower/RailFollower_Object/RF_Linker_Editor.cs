using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace RailFollower
{

    [CanEditMultipleObjects]
    [CustomEditor(typeof(RF_Linker_Base))]
    public class Linker_Editor : Editor
    {
       //(용준)시원하게 지워버림
    }
}
#endif