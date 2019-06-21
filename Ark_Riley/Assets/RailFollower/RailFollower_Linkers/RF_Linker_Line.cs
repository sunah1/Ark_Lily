using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace RailFollower
{
    [System.Serializable]
    public class Linker_Line
    {
        //private float _Length;
        //public float Length { get => _Length; protected set => _Length = value; }
        public RF_Linker_Base Base;
        public Linker_Line Next;
        public Vector3 Tangent = Vector3.zero;

        public Linker_Line(RF_Linker_Base _base)
        {
            Base = _base;
            Tangent = Vector3.zero;
        }
        public void Reset()
        {
            Next = null;
            Tangent = Vector3.zero;
        }

        public void SetLink_Left(RF_Linker_Base _src, ref RF_Linker_Base _dest)
        {
            Next = _dest.LeftLink;
            _dest.RightLink.Next = _src.LeftLink;
            Tangent = Vector3.zero;
        }
        public void SetLink_Right(RF_Linker_Base _src, ref RF_Linker_Base _dest)
        {
            Next = _dest.RightLink;
            _dest.LeftLink.Next = _src.RightLink;
            Tangent = Vector3.zero;
        }




    }
    [CustomEditor(typeof(RF_Linker_Base))]
    public class Linker_Line_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            RF_Linker_Base linker = target as RF_Linker_Base;


            EditorGUILayout.LabelField("※ Rail ");
            EditorGUILayout.BeginHorizontal();

            //EditorGUI.BeginDisabledGroup(linker.LeftLink.Next);


        }



    }


}
