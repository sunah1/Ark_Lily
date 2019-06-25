using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RailFollower
{
    [System.Serializable]
    [ExecuteInEditMode]
    public class RF_Linker_Station : RF_Linker_Base
    {
        //만들것 딕셔너리
        // 단순히 Path생성&파괴 될때 새로 만들게 하면 됨ㄴ
        // 근데 그러면 2개이상 삭제될때는 어쩐다냐


        public int PathCount
        { //0624(용준)스테이션에 소속된 패스의 개수를 반환하는 프로퍼티
            get { return transform.childCount - 1; }
        }

        protected override void Update()
        {
            base.Update();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                for (int iter = 1; iter < transform.childCount; ++iter)
                {
                    var TempLine = transform.GetChild(iter).GetComponent<RF_Linker_Path>();
                    if (TempLine && TempLine.Next)
                        DestroyImmediate(TempLine.Next.gameObject);
                }
            }
#endif
        }



#if UNITY_EDITOR
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////
        protected override void ChangeTransform()
        {

        }
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////

        const string localPath = "Assets/RailFollower/RailFollower_Object/RAIL_Station.prefab";
        /// <summary>
        /// 스테이션을 추가
        /// </summary>
        public RF_Linker_Station AddStation()
        {
            // AssetDatabase.FindAssets(); 검증하고 싶을때에는 추가
            RF_Linker_Station temp_Station =
                ((GameObject)PrefabUtility.InstantiatePrefab(
                AssetDatabase.LoadAssetAtPath(
                localPath
                , typeof(GameObject))
                )).GetComponent<RF_Linker_Station>();
            temp_Station.transform.SetParent(transform.parent);
            temp_Station.transform.position = transform.position;
            temp_Station.name = temp_Station.name + transform.parent.childCount;
            AddPath(ref temp_Station);

            Selection.activeGameObject = temp_Station.gameObject;
            return temp_Station;
        }

        /// <summary>
        /// 진행 가능 방향 추가
        /// </summary>
        public RF_Linker_Path AddPath()//160624같은 Station에 Path만들때 새로운 Station생기는 문제 해결
        {
            RF_Linker_Path temp_Path = (new GameObject()).AddComponent(typeof(RF_Linker_Path)) as RF_Linker_Path;
            temp_Path.transform.SetParent(transform);
            temp_Path.transform.localPosition = Vector3.zero;
            temp_Path.name = //160623(용준)Station이니까 마지막 글자가 n이면 1번 스테이션으로 간주한다는 거지같은 코드임
                transform.name[transform.name.Length - 1] == 'n' ?
                "Rail_Station1Path" + (transform.childCount-1) :
                "Rail_Station" + transform.name[transform.name.Length - 1] + "Path" + (transform.childCount-1);
            temp_Path.transform.tag = "RAIL_Path";
            return temp_Path;
        }
        public RF_Linker_Path AddPath(ref RF_Linker_Path _Line)
        {
            RF_Linker_Path temp_Path = AddPath();
            temp_Path.Next = _Line;
            return temp_Path;
        }
        public RF_Linker_Path AddPath(ref RF_Linker_Station _Station)
        {
            RF_Linker_Path temp_Path = AddPath();
            temp_Path.Next = _Station.AddPath(ref temp_Path);
            return temp_Path;
        }
#endif
    }

}
