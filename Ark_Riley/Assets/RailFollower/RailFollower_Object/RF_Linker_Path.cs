using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace RailFollower
{
    /// <summary>
    /// 부모가 RF_Linker_Base여야 작동을 한다.
    /// </summary>
    [ExecuteInEditMode]
    [System.Serializable]
    public class RF_Linker_Path : MonoBehaviour
    {
        public RF_Linker_Path Next;
        [Space(10)]

        [SerializeField]
        private float Path_Length;// { get; protected set; }
        public float PathLength { get => Path_Length; protected set => Path_Length = value; }


        //public Vector3 Tangent{
        //    set { transform.localPosition = value; }
        //    get { return transform.localPosition; }
        //}

        private void Awake()
        {
            //Debug.Log(transform.parent.name+"의"+name+"Length : " + PathLength);
        }

        void Update()
        {
            if (!Application.isPlaying)
            {
                if (transform.hasChanged)
                {
                    ChangeTransform();
                    transform.hasChanged = false;
                }
            }
        }
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        public Vector3 PathIntrpPoint(float _NormalScalar)
        {
            Vector3 tempVector = transform.parent.position;
            if (Next)
            {
                if (transform.localPosition != Vector3.zero)
                {
                    if (Next.transform.localPosition != Vector3.zero)
                    {
                        tempVector = BezierCurve(_NormalScalar
                            , transform.parent.position, transform.position
                            , Next.transform.parent.position, Next.transform.position);
                    }
                    else
                    {
                        tempVector = BezierCurve(_NormalScalar, transform.parent.position, Next.transform.parent.position, transform.position);
                    }
                }
                else if (Next.transform.localPosition != Vector3.zero)
                {
                    tempVector= BezierCurve(_NormalScalar, transform.parent.position, Next.transform.parent.position, Next.transform.position);
                }
                else
                {
                    tempVector = Vector3.Lerp(
                    transform.parent.position, Next.transform.parent.position
                    , _NormalScalar);
                }
            }
            return tempVector;
        }

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
        public void ChangeTransform(float _Length = -1.0f)
        {
            if (Next)
            {
                if (_Length >= 0)
                    PathLength = _Length;
                else
                {
                    if (transform.localPosition != Vector3.zero || Next.transform.localPosition != Vector3.zero)
                        PathLength = BezierCurveLength();
                    else
                        PathLength = (Next.transform.parent.position - transform.parent.position).magnitude;
                    Next.ChangeTransform(PathLength);
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
            for (int i = 1; i <= ConstValue.BezierCurveStepPrecision; i++)
            {
                lineEnd = PathIntrpPoint(i / (float)ConstValue.BezierCurveStepPrecision);
                length += (lineEnd- lineStart).magnitude;
                lineStart = lineEnd;
            }
            return length;
        }

#endif
    }
}
