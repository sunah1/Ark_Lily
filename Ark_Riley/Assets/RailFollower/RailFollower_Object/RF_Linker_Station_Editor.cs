using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RailFollower
{

    [CanEditMultipleObjects]
    [CustomEditor(typeof(RF_Linker_Station))]
    public class Linker_Station_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            RF_Linker_Station station = target as RF_Linker_Station;
            {

                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("※ RailFollower - Link Create");

                    if (GUILayout.Button("ADD Station & Path"))
                        station.AddStation();

                    AddPath_Button(ref station);

                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                    EditorGUILayout.TextArea("", GUI.skin.horizontalSlider);
                }
            }
            AssetDatabase.SaveAssets();
        }

        private void OnSceneGUI()
        {
            RF_Linker_Station station = target as RF_Linker_Station;
            {
                DrawMarkerPostion(ref station);
                DrawPathLines(ref station, DrawMode.Curve);
            }
        }

        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        //OnInspectorGUI()

        //EditorGUI.BeginChangeCheck();
        //if (EditorGUI.EndChangeCheck())

        RF_Linker_Station addStationTarget;
        /// <summary>
        /// 공간을 주고 그곳에 있을경우 추가
        /// </summary>
        void AddPath_Button(ref RF_Linker_Station station)
        {
            EditorGUILayout.BeginHorizontal();
            {
                addStationTarget = (RF_Linker_Station)EditorGUILayout.ObjectField("TargetStation", addStationTarget, typeof(RF_Linker_Station), true);
                EditorGUI.BeginDisabledGroup(!addStationTarget);
                {
                    if (GUILayout.Button("ADD Path"))
                    {
                        EditorUtility.SetDirty(station.AddPath(ref addStationTarget));
                        addStationTarget = null;
                    }
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();
        }


        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        //OnSceneGUI()

        //Handles.Slider(_Line.Base.transform.position, _Line.Tangent);






        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        //static //OnSceneGUI()

        /// <summary>
        /// 스테이션의 시작 중점을 보여주는 용도
        /// </summary>
        static public void DrawMarkerPostion(ref RF_Linker_Station station)
        {
            Handles.color = Color.green;

            Handles.DrawWireDisc(station.transform.position, Vector3.up, ConstValue.PointRadius);
            Handles.DrawLine(station.transform.position, station.transform.position + (Vector3.up * ConstValue.PointHeight));
        }

        /// <summary>
        /// 포인트를 선택했을때 이동하는 길들을 보여주는 용도
        /// </summary>
        static public void DrawPathLines(ref RF_Linker_Station station, DrawMode _mode)
        {
            for (int iter = 1; iter < station.transform.childCount; ++iter)
            {
                var TempLine = station.transform.GetChild(iter).GetComponent<RF_Linker_Path>();
                if (TempLine && TempLine.Next)
                    Linker_Path_Editor.DrawPathData(ref TempLine, _mode, "Path:" + iter);
            }
        }

        /*
         if(EditorUtility.DisplayDialog("Are you sure?"
        ,"The Prefab already exists. Do you want to overwrite it?"
        ,"Yes"
        ,"No"))
             Debug.Log("ok");
         else
             Debug.Log("cancel");


          EditorGUILayout.IntSlider(0, 10, 0);

        void TangentHandle(ref Linker_Line _Line)
        {
            //Vector3 tempPostion = _Line.Base.transform.position + _Line.Tangent;
            Quaternion tempRoatation = Quaternion.identity;
            //_Line.Base.transform.rotation

            EditorGUI.BeginChangeCheck();
            tempRoatation = Handles.DoRotationHandle(tempRoatation, _Line.Base.transform.position);
            if (EditorGUI.EndChangeCheck())
            {
                _Line.Tangent = tempRoatation * _Line.Tangent;
                EditorUtility.SetDirty(_Line);
            }
        }
        */


    }
}
