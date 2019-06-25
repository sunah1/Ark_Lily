using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RailFollower
{
    public class RailFollower_Using : MonoBehaviour
    {

    }

    public static class ConstValue
    {
        public const float DotLineGap = 8.0f;
        public const float PointHeight = 2.0f;
        public const float PointRadius = 0.7f;
        public const int BezierCurvePrecisionStep = 12;
        public const float BezierCurvePrecision = 1/(float)BezierCurvePrecisionStep;


    }

    public static class StaticValue
    {
        private static GUIStyle Label_Style;
        public static GUIStyle LabelStyle
        {
            get
            {
                if (Label_Style == null)
                {
                    Label_Style = new GUIStyle
                    {
                        fontSize = 18
                        ,alignment = TextAnchor.MiddleCenter
                    };
                }
                return Label_Style;
            }
        }
    }

    public enum DrawMode
    {
        Straight, Curve, Bezier

    }

}

