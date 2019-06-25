using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace RailFollower
{
    /// <summary>
    /// 부모 게임오브젝트가 RF_Linker_Station이어야 작동을 한다.
    /// </summary>
    [ExecuteInEditMode]
    [System.Serializable]
    public class RF_Linker_Path : RF_Linker_Base
    {
        //190624(선아)매번 GetComponent으로 호출하기에는 문제가 있다고 판단해 제작
        [SerializeField][ReadOnly]
        private RF_Linker_Station Belong_Station;
        public RF_Linker_Station BelongStation
        {
            get
            {
                if (!Belong_Station)
                    Belong_Station = transform.parent.GetComponent<RF_Linker_Station>();
                return Belong_Station;
            }
            set => Belong_Station = value;
        }

        public Vector3 StationPosition{ get => BelongStation.transform.position; }

        public Vector3 NextStationDirection{
            get => (Next.StationPosition - StationPosition).normalized;
        }
        public Vector3 NextPathDirection
        {
            get => (IsCurve ?
               (PathIntrpPoint(ConstValue.BezierCurvePrecision)-PathIntrpPoint(0.0f)).normalized
                : NextStationDirection);
        }
        public Vector3 PathCenter
        {
            get => (IsCurve ? PathIntrpPoint(0.5f)
                : StationPosition+(NextStationDirection* PathLength * 0.5f));
        }

        public bool IsCurve{
            get {
                if(Next){
                    if (Vector3.zero != transform.localPosition || Vector3.zero != Next.transform.localPosition)
                        return true;
                }
                return false;
            }
        }


        [Space(10)]
        [Tooltip("더블클릭시 반대편의 대상을 Hierarchy창에서 보여준다.")]
        [ReadOnly]
        public RF_Linker_Path Next;
        [SerializeField][ReadOnly]
        private float Path_Length;
        public float PathLength { get => Path_Length; protected set => Path_Length = value; }

        [Header("출입로의 상태 표시")]
        public bool temp;


        protected override void Update()
        {
            base.Update();
        }
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        public Vector3 PathIntrpPoint(float _NormalScalar)
        {
            Vector3 tempVector = StationPosition;
            if (Next)
            {
                if (transform.localPosition != Vector3.zero)
                {
                    if (Next.transform.localPosition != Vector3.zero)
                    {
                        tempVector = BezierCurve(_NormalScalar
                            , StationPosition, transform.position
                            , Next.StationPosition, Next.transform.position);
                    }
                    else
                    {
                        tempVector = BezierCurve(_NormalScalar, StationPosition, Next.StationPosition, transform.position);
                    }
                }
                else if (Next.transform.localPosition != Vector3.zero)
                {
                    tempVector= BezierCurve(_NormalScalar, StationPosition, Next.StationPosition, Next.transform.position);
                }
                else
                {
                    tempVector = Vector3.Lerp(
                    StationPosition, Next.StationPosition
                    , _NormalScalar);
                }
            }
            return tempVector;
        }

        //연산량을 줄이기 위해 다른 수식 사용
        private Vector3 BezierCurve(float scalar, Vector3 start, Vector3 startTan, Vector3 end, Vector3 endTan)
        {
            float cT = Mathf.Clamp01(scalar);
            float mT = 1f - cT;
            return
            (mT * mT * mT * start)
            + (3f * mT * mT * cT * startTan)
            + (3f * mT * cT * cT * endTan)
            + (cT * cT * cT * end);
        }
        private Vector3 BezierCurve(float scalar, Vector3 start, Vector3 end, Vector3 Tangent )
        {
            float cT = Mathf.Clamp01(scalar);
            float mT = 1f - cT;
            return
            (mT * mT * start)
            + (2f * mT * cT * Tangent)
            + (cT * cT * end);
        }

#if UNITY_EDITOR
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        protected override void ChangeTransform()
        {
            ChangePathLength();
        }
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        //ChangeTransform()

        public void ChangePathLength(float _Length = -1.0f)
        {
            if (Next)
            {
                if (_Length >= 0)//연산량을 줄이기 위해 받아오는 방식으로
                    PathLength = _Length;
                else
                {
                    if (IsCurve)
                        PathLength = BezierCurveLength();
                    else
                        PathLength = (Next.StationPosition - StationPosition).magnitude;
                    Next.ChangePathLength(PathLength);
                }
            }
            else
                PathLength = 0;
            EditorUtility.SetDirty(this);
        }

        private float BezierCurveLength()
        {
            float length = 0;
            Vector3 lineStart = PathIntrpPoint(0f);
            Vector3 lineEnd = Vector3.zero;
            for (int i = 1; i <= ConstValue.BezierCurvePrecisionStep; i++)
            {
                lineEnd = PathIntrpPoint(i * ConstValue.BezierCurvePrecision);
                length += (lineEnd- lineStart).magnitude;
                lineStart = lineEnd;
            }
            return length;
        }

#endif
    }
}
