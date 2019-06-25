using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
namespace RailFollower
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RF_Follower_Base),true)]
    public class Follower_Editor : Editor
    {
        private void OnSceneGUI()
        {
            RF_Follower_Base Follower = target as RF_Follower_Base;
            {
                if (Application.isPlaying)
                {

                    if (Follower.InAction)
                        ViewPath(ref Follower);
                    else
                    Linker_Station_Editor.DrawPathLines(ref Follower.CurrentStation,DrawMode.Curve);
                    ViewFollowerData(ref Follower);
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        void ViewFollowerData(ref RF_Follower_Base _Follower)
        {
            Handles.Label(_Follower.transform.position + (Vector3.up*3.0f), "Speed:" + _Follower.Speed + "m/s", StaticValue.LabelStyle);
        }

        void ViewPath(ref RF_Follower_Base _Follower)
        {
            Linker_Path_Editor.DrawPathData(ref _Follower.CurrentPath, DrawMode.Curve, "이동경로");

            Handles.color = Color.white;
            Handles.DrawDottedLine(
                _Follower.transform.position
                , _Follower.CurrentPath.Next.StationPosition
                , ConstValue.DotLineGap);

            Handles.color = Color.green;
            Handles.DrawDottedLine(
                _Follower.transform.position
                , _Follower.CurrentPath.StationPosition
                , ConstValue.DotLineGap);

            Handles.Label(_Follower.transform.position + (Vector3.up * 4.0f), "Distance:" + Mathf.Round(_Follower.NormalScalar*10000f)*0.01f + "%", StaticValue.LabelStyle);
        }


    }

}
#endif
