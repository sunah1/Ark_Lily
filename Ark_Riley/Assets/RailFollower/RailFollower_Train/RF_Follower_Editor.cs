using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace RailFollower
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(RF_Follower_Base),true)]
    public class RF_Follower_Editor : Editor
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
                    Linker_Editor.DrawPathLines(ref Follower.ThisRail,DrawMode.Bezier);
                    ViewFloowerData(ref Follower);
                }
            }
        }
#if UNITY_EDITOR
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        void ViewFloowerData(ref RF_Follower_Base _Follower)
        {
            Handles.Label(_Follower.transform.position + (Vector3.up*2f), "Speed:" + _Follower.Speed + "m/s");
        }

        void ViewPath(ref RF_Follower_Base _Follower)
        {
            Linker_Path_Editor.DrawPathData(ref _Follower.TakeRail, DrawMode.Curve,"이동중인 경로");

            Handles.color = Color.white;
            Handles.DrawDottedLine(
                _Follower.transform.position
                , _Follower.TakeRail.Next.transform.parent.position
                , ConstValue.DotLineGap);

            Handles.color = Color.green;
            Handles.DrawDottedLine(
                _Follower.transform.position
                , _Follower.TakeRail.transform.parent.position
                , ConstValue.DotLineGap);


            Handles.Label(_Follower.transform.position + (Vector3.up * 1.5f), "ElapsedTime:" + _Follower.ElapsedTime + "s");
            Handles.Label(_Follower.transform.position + (Vector3.up * 2.5f), "Distance:" + Mathf.Round(_Follower.NormalScalar*10000f)*0.01f + "%");
        }


#endif
    }

}
