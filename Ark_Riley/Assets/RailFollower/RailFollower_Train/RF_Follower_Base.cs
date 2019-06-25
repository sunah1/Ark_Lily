using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace RailFollower
{
    public class RF_Follower_Base : MonoBehaviour
    {
        [Header("※ 시작지점으로 Station 필요")]
        public RF_Linker_Station CurrentStation;//(용준)똑같은 레일취급 하더라도 각 필드가 필요할 거 같아서 결국 못지움
        [Space(10)] //(용준)ReadOnlyAttribute클래스를 Utilities 폴더에 넣어두었음

        //[ReadOnly] public RF_Linker_Station CurrentDestination;//(용준)필요할 것 같아서 만듦
        //길따라 이동하다보면 결국 목적지가 나오는거지
        [Tooltip("지금 타고 움직이는 중인 길을 보여준다.")]
        [ReadOnly] public RF_Linker_Path CurrentPath;

        [Space(10)]
        [Header("※ Current Status ※")]
        [ReadOnly] public bool InAction;
        [ReadOnly] public float ElapsedTime;
        [Tooltip("진행률 0~1")]
        [ReadOnly] public float NormalScalar;


        [Space(10)]
        [Header("※ Status Values ※")]
        [Tooltip("m/s")]
        [Range(0, 50)]
        public float Speed = 1.0f;

        private float MultiplyValue;

        private void Awake()
        {
            transform.position = CurrentStation.transform.position;
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
            if (CurrentPath) return;
            for (int iter = 1; iter <= CurrentStation.PathCount; ++iter)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + iter))
                {
                    SetRail(CurrentStation.transform.GetChild(iter).GetComponent<RF_Linker_Path>());
                    break;
                }
            }

        }

        private void SetRail(RF_Linker_Path _path)
        {
            CurrentPath = _path;
            Debug.Log("PathLength : " + CurrentPath.PathLength);
            if (CurrentPath.PathLength == 0)
                MultiplyValue = 0;
            else
                MultiplyValue = 1 / CurrentPath.PathLength;

            ElapsedTime = 0;

            if (Speed <= 0){
                CurrentPath = null;
            }
            else{
                InAction = true;
            }

        }

        private void Action()
        {
            if (!CurrentPath) return;
            ElapsedTime += Time.deltaTime;

            NormalScalar = ElapsedTime * MultiplyValue * Speed;

            transform.position = CurrentPath.PathIntrpPoint(NormalScalar);

            if (NormalScalar >= 1 || MultiplyValue <= 0)
            {
                CurrentStation = CurrentPath.Next.BelongStation;
                CurrentPath = null;
                InAction = false;
            }

        }


    }
}


