using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace RailFollower
{
    [CustomEditor(typeof(RF_Linker_Path))]
    public class Linker_Path_Editor : Editor
    {
        private void OnSceneGUI()
        {
            RF_Linker_Path Path = target as RF_Linker_Path;
            {
                DrawPathLine(ref Path, DrawMode.Bezier);
                Handles.color = Color.gray;
                DrawPathTangent(ref Path);
            }

        }
#if UNITY_EDITOR

        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        //OnSceneGUI()






        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        //Static //OnSceneGUI()
        static public void DrawPathTangent(ref RF_Linker_Path _Path)
        {
            if (_Path.transform.localPosition != Vector3.zero)
            {
                Handles.Slider(_Path.transform.parent.position, (_Path.transform.position - _Path.transform.parent.position));
                Handles.DrawLine(_Path.transform.parent.position, _Path.transform.position);
            }
            if (_Path.Next.transform.localPosition != Vector3.zero)
            {
                Handles.Slider(_Path.Next.transform.parent.position, (_Path.Next.transform.position - _Path.Next.transform.parent.position));
                Handles.DrawLine(_Path.Next.transform.parent.position, _Path.Next.transform.position);
            }
        }

        static public void DrawPathData(ref RF_Linker_Path _Path, DrawMode _mode, string _str)
        {
            DrawPathLine(ref _Path, _mode);
            Handles.Label(
                        _Path.transform.parent.position + (_Path.Next.transform.parent.position - _Path.transform.parent.position).normalized
                        , _str + " Len:" + Mathf.Round(_Path.PathLength * 10f) * 0.1f
                        );
        }

        static public void DrawPathLine(ref RF_Linker_Path _Path, DrawMode _mode)
        {
            if(DrawMode.Straight != _mode && (_Path.transform.localPosition != Vector3.zero || _Path.Next.transform.localPosition != Vector3.zero))
                DrawBezierCurve(ref _Path, _mode);
            else
            {
                if(DrawMode.Straight != _mode)
                    Handles.color = Color.yellow;
                Handles.DrawDottedLine(_Path.transform.parent.position, _Path.Next.transform.parent.position, ConstValue.DotLineGap);
            }
        }

        static void DrawBezierCurve(ref RF_Linker_Path _Path, DrawMode _mode)
        {
            Handles.color = Color.yellow;
            Vector3 lineStart = _Path.PathIntrpPoint(0f);
            for (int i = 1; i <= ConstValue.BezierCurveStepPrecision; i++)
            {
                Vector3 lineEnd = _Path.PathIntrpPoint(i / (float)ConstValue.BezierCurveStepPrecision);
                Handles.DrawDottedLine(lineStart, lineEnd, ConstValue.DotLineGap);
                lineStart = lineEnd;
            }
            if(DrawMode.Bezier == _mode)
            Handles.DrawBezier(
                _Path.transform.parent.position
                , _Path.Next.transform.parent.position
                , _Path.transform.position
                , _Path.Next.transform.position
                , Color.green, null, 2
                );
        }
#endif

    }

}

