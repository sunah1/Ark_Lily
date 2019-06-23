using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace RailFollower
{
    public class RF_Follower_Base : MonoBehaviour
    {
        [Tooltip("시작지점으로 반드시 필요")]
        public RF_Linker_Base ThisRail;
        [Space(10)]
        [ReadOnly(false)]
        public RF_Linker_Path TakeRail;
        public float ElapsedTime;

        public bool InAction;

        [Space(10)]
        [Header("※ Status ※")]
        [Range(0, 50)]
        public float Speed = 1.0f;

        private float MultiplyValue;
        [HideInInspector] public float NormalScalar;

        private void Awake()
        {
            transform.position = ThisRail.transform.position;
            InAction = false;
        }

        // Update is called once per frame
        void Update()
        {
            GetEvent();
            Action();
        }



        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        //Update // Get Event

        private void GetEvent()
        {
            if (TakeRail) return;
            for (int iter = 1; iter < ThisRail.transform.childCount; ++iter)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + iter))
                {
                    SetRail(ThisRail.transform.GetChild(iter).GetComponent<RF_Linker_Path>());
                    break;
                }
            }

        }

        private void SetRail(RF_Linker_Path _path)
        {
            TakeRail = _path;
            Debug.Log("PathLength : " + TakeRail.PathLength);
            if (TakeRail.PathLength == 0)
                MultiplyValue = 0;
            else
                MultiplyValue = 1 / TakeRail.PathLength;

            ElapsedTime = 0;


            if (Speed <= 0)
                TakeRail = null;
            else
                InAction = true;

        }

        private void Action()
        {
            if (!TakeRail) return;
            ElapsedTime += Time.deltaTime;

            NormalScalar = ElapsedTime * MultiplyValue * Speed;

            transform.position = TakeRail.PathIntrpPoint(NormalScalar);

            if (NormalScalar >= 1 || MultiplyValue <= 0)
            {
                ThisRail = TakeRail.Next.transform.parent.GetComponent<RF_Linker_Base>();
                TakeRail = null;
                InAction = false;
            }

        }


    }
}


