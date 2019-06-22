using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RailFollower
{

    [CanEditMultipleObjects]
    [CustomEditor(typeof(RF_Linker_Base))]
    public class Linker_Editor : Editor
    {
        private void Awake()
        {
        }
        void OnEnable()
        {
        }
        void OnDisable()
        {
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            RF_Linker_Base linker = target as RF_Linker_Base;
            {
                //do this first to make sure you have the latest version
                //serializedObject.Update();
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.LabelField("※ RailFollower - Link Create");

                    if (GUILayout.Button("ADD Point & Path"))
                        linker.AddPoint();

                    AddPath_Button(ref linker);
                }
            }
            AssetDatabase.SaveAssets();
        }

        private void OnSceneGUI()
        {
            RF_Linker_Base linker = target as RF_Linker_Base;
            {
                DrawMarkerPostion(ref linker);
                DrawPathLines(ref linker);
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

        RF_Linker_Base addPointTarget;
        /// <summary>
        /// 공간을 주고 그곳에 있을경우 추가
        /// </summary>
        void AddPath_Button(ref RF_Linker_Base linker)
        {
            EditorGUILayout.BeginHorizontal();
            {
                addPointTarget = (RF_Linker_Base)EditorGUILayout.ObjectField("TargetPoint", addPointTarget, typeof(RF_Linker_Base), true);
                EditorGUI.BeginDisabledGroup( !addPointTarget );
                {
                    if (GUILayout.Button("ADD Path"))
                    {
                        EditorUtility.SetDirty( linker.AddPath(ref addPointTarget) );
                        addPointTarget = null;
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
        private static readonly float c_LineGaps = 8.0f;
        private static readonly float c_PointHeight = 2.0f;
        private static readonly float c_PointRadius = 0.7f;
        //Handles.Slider(_Line.Base.transform.position, _Line.Tangent);


        /// <summary>
        /// 포인트를 선택했을때 시작 중점을 보여주는 용도
        /// </summary>
        void DrawMarkerPostion(ref RF_Linker_Base linker)
        {
            Handles.color = Color.green;

            Handles.DrawWireDisc(linker.transform.position, Vector3.up, c_PointRadius);
            Handles.DrawLine(linker.transform.position, linker.transform.position + (Vector3.up * c_PointHeight));
        }


        /// <summary>
        /// 포인트를 선택했을때 이동하는 길들을 보여주는 용도
        /// </summary>
        void DrawPathLines(ref RF_Linker_Base linker)
        {
            Handles.color = Color.white;

            for (int iter = 1; iter < linker.transform.childCount; ++iter)
            {
                var TempLine = linker.transform.GetChild(iter).GetComponent<RF_Linker_Line>();
                if (TempLine)
                if (TempLine.Next)
                {
                    Handles.DrawDottedLine(linker.transform.position, TempLine.Next.transform.parent.position, c_LineGaps);
                    Handles.Label(
                        linker.transform.position + (TempLine.Next.transform.parent.position- linker.transform.position).normalized
                        , "Path:" + iter + " Len:"+ TempLine.PathLength
                        );
                }
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


          Handles.Slider(_Line.Base.transform.position, _Line.Tangent);

                    Handles.DrawBezier(
                        _Line.Base.transform.position
                        , _Line.Next.Base.transform.position
                        , _Line.Tangent
                        , _Line.Next.Tangent
                        , Color.white
                        , null
                        , 1
                        );

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
