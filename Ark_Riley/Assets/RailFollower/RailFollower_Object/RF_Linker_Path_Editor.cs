using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace RailFollower
{
    [CustomEditor(typeof(RF_Linker_Path))]
    public class Linker_Path_Editor : Editor
    {
        private void OnSceneGUI()
        {
            RF_Linker_Path Path = target as RF_Linker_Path;
            {
                DrawPathData(ref Path, DrawMode.Bezier, name);
                DrawPathTangent(ref Path);
                var temp = Path.BelongStation;
                Linker_Station_Editor.DrawMarkerPostion(ref temp);
                temp = Path.Next.BelongStation;
                Linker_Station_Editor.DrawMarkerPostion(ref temp);
            }

        }

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
            Handles.color = Color.gray;
            if (_Path.transform.localPosition != Vector3.zero)
            {
                Handles.Slider(_Path.StationPosition, _Path.transform.localPosition);
                Handles.DrawLine(_Path.StationPosition, _Path.transform.position);
            }
            if (_Path.Next.transform.localPosition != Vector3.zero)
            {
                Handles.Slider(_Path.Next.StationPosition, _Path.Next.transform.localPosition);
                Handles.DrawLine(_Path.Next.StationPosition, _Path.Next.transform.position);
            }
        }

        // 베지어 곡선일때 위치 설정을 바꿔주는 기능이 필요한 상태
        static public void DrawPathData(ref RF_Linker_Path _Path, DrawMode _mode, string _str)
        {
            DrawPathLine(ref _Path, _mode);
            DrawPathName(ref _Path, _str);

            Handles.Label(
                        _Path.PathCenter
                        , "Len:" + Mathf.Round(_Path.PathLength * 10f) * 0.1f
                        , StaticValue.LabelStyle);
        }
        static private void DrawPathName(ref RF_Linker_Path _Path, string _str)
        {
            Handles.Label(
                       _Path.StationPosition + _Path.NextPathDirection*0.5f
                       , _str, StaticValue.LabelStyle);
        }

        static public void DrawPathLine(ref RF_Linker_Path _Path, DrawMode _mode)
        {
            if (DrawMode.Straight != _mode && _Path.IsCurve)
                DrawBezierCurve(ref _Path, _mode);
            else
            {
                if (DrawMode.Straight != _mode)
                    Handles.color = Color.yellow;
                else
                    Handles.color = Color.white;
                Handles.DrawDottedLine(_Path.StationPosition, _Path.Next.StationPosition, ConstValue.DotLineGap);
            }
        }

        static private void DrawBezierCurve(ref RF_Linker_Path _Path, DrawMode _mode)
        {
            Handles.color = Color.yellow;
            Vector3 lineStart = _Path.PathIntrpPoint(0.0f);
            for (int i = 1; i <= ConstValue.BezierCurvePrecisionStep; i++)
            {
                Vector3 lineEnd = _Path.PathIntrpPoint(i* ConstValue.BezierCurvePrecision);
                Handles.DrawDottedLine(lineStart, lineEnd, ConstValue.DotLineGap);
                lineStart = lineEnd;
            }
            if (DrawMode.Bezier == _mode)
                Handles.DrawBezier(
                    _Path.StationPosition
                    , _Path.Next.StationPosition
                    , _Path.transform.position
                    , _Path.Next.transform.position
                    , Color.green, null, 1
                    );
        }



    }

}
#endif

