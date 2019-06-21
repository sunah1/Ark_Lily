using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RailFollower
{
    [CustomEditor(typeof(RF_Linker_Base))]
    public class Linker_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            RF_Linker_Base linker = target as RF_Linker_Base;

            if (linker)
            {
                {
                    EditorGUILayout.LabelField("※ Rail Linker - Create");
                    EditorGUILayout.Space();

                    EditorGUILayout.LabelField("LEFT-Linker");
                    LinkerInspector(linker.LeftLink, RailAction.LEFT);

                    EditorGUILayout.LabelField("RIGHT-Linker");
                    LinkerInspector(linker.RightLink, RailAction.RIGHT);

                    if (GUILayout.Button("Cut - Link"))
                        linker.AddLink( RailAction.STOP );

                    EditorGUI.EndDisabledGroup();


                    //EditorGUILayout.IntSlider(0, 10, 0);
                }
            }

        }

        void LinkerInspector(Linker_Line _linker, RailAction _action)
        {
            EditorGUILayout.BeginHorizontal();
            {
                if(null == _linker.Next)
                    EditorGUILayout.ObjectField(null, typeof(RF_Linker_Base), false);
                else
                    EditorGUILayout.ObjectField(_linker.Next.Base, typeof(RF_Linker_Base), false);

                EditorGUI.BeginDisabledGroup(null != _linker.Next);
                {
                    if (GUILayout.Button("ADD-POINT"))
                        _linker.Base.AddLink(_action);
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                EditorGUI.BeginDisabledGroup(null == _linker.Next);
                {
                    _linker.Tangent = EditorGUILayout.Vector3Field("Tangent", _linker.Tangent);
                    if (GUILayout.Button("RESET"))
                        _linker.Tangent = Vector3.zero;
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndHorizontal();
        }



        private void OnSceneGUI()
        {
            RF_Linker_Base linker_object = target as RF_Linker_Base;
            if(linker_object)
            {

                DrawMarkerPostion(linker_object, Color.green);
                Handles.color = Color.white;

                DrawLine(linker_object.LeftLink);
                DrawLine(linker_object.RightLink);



            }

        }

        // https://answers.unity.com/questions/1139985/gizmosdrawline-thickens.html // 선두껍게 하려면 참조해서 코드 변경
        void DrawMarkerPostion(in RF_Linker_Base _object, Color _color)
        {
            if(_object.transform.GetChild(0)){
                Handles.color = _color;
                Handles.DrawLine(_object.transform.position, _object.transform.GetChild(0).position);
            }

        }
        const float LineGaps = 10.0f;
        void DrawLine(Linker_Line _Line)
        {
            if (null == _Line.Next)
                return;
            DrawMarkerPostion(_Line.Next.Base, Color.red);

            Handles.color = Color.yellow;
            if (_Line.Tangent != Vector3.zero)
            {
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
            }
            else
            {
                Handles.color = Color.white;
                Handles.DrawDottedLine(_Line.Next.Base.transform.position, _Line.Base.transform.position, LineGaps);
            }


            //Handles.DrawLine();
        }





    }
}
