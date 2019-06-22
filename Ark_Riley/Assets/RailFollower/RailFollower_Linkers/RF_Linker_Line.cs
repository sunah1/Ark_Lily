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
    public class RF_Linker_Line : MonoBehaviour
    {
        //private float Path_Length;
        //public float PathLength { get => Path_Length; protected set => Path_Length = value; }
        public float PathLength { get; protected set; }

        public RF_Linker_Line Next;
        public Vector3 Tangent{
            set { transform.position = value; }
            get { return transform.position; }
        }

        void Update()
        {
            if (!Application.isPlaying)
            {
                if (transform.hasChanged)
                {
                    ChangeTransform();
                    Debug.Log(this.name + " transform has changed!");
                    transform.hasChanged = false;
                }
            }
        }

#if UNITY_EDITOR
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        public void ChangeTransform(float _Length = -1.0f)
        {
            if(Next)
            {
                if (_Length >= 0)
                    PathLength = _Length;
                else
                {
                    PathLength = (Next.transform.parent.position - transform.parent.position).magnitude;
                    Next.ChangeTransform(PathLength);
                }
            }
        }

#endif
    }
}
