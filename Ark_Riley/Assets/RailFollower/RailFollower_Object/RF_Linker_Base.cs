using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RailFollower
{
    [System.Serializable]
    [ExecuteInEditMode]
    public abstract class RF_Linker_Base : MonoBehaviour//190623(용준)대부분 기능 다 지우고 abstract 추가, 이벤트함수는 protected virtual
    {
        // Update is called once per frame
        protected virtual void Update()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                if (transform.hasChanged)
                {
                    ChangeTransform();//190624(선아)ChangeTransform()를 virtual로 만듬
                    transform.hasChanged = false;
                }
            }
#endif
        }
        protected virtual void OnDestroy()
        {

        }
#if UNITY_EDITOR
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        protected virtual void ChangeTransform()
        {

        }
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
#endif
    }

}