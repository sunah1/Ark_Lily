using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RailFollower
{


    public class RailFollower_Using : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public static class ConstValue
    {
        public const float DotLineGap = 8.0f;
        public const float PointHeight = 2.0f;
        public const float PointRadius = 0.7f;
        public const int BezierCurveStepPrecision = 12;
    }

    public enum DrawMode
    {
        Straight, Curve, Bezier

    }

}

