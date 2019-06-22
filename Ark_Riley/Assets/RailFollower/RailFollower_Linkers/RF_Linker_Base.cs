using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RailFollower
{
    [System.Serializable]
    [ExecuteInEditMode]
    public class RF_Linker_Base : MonoBehaviour
    {
        //[Tooltip("진행 가능 방향들")]

        private void Awake()
        {
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!Application.isPlaying)
            {
                if (transform.hasChanged)
                {
                    //ChangeTransform();
                    //Debug.Log(this.name + " transform has changed!");
                    transform.hasChanged = false;
                }
            }
        }
        void OnDestroy()
        {
            if (!Application.isPlaying)
            {
                for (int iter = 1; iter < transform.childCount; ++iter)
                {
                    var TempLine = transform.GetChild(iter).GetComponent<RF_Linker_Line>();
                    if (TempLine && TempLine.Next)
                        DestroyImmediate(TempLine.Next.gameObject);
                }
                Debug.Log(this.name + " is destroyed");
            }
        }

#if UNITY_EDITOR
        ///////////////////////////////////////////////////////////////////////
        //###################################################################//
        //###################################################################//
        //###################################################################//
        ///////////////////////////////////////////////////////////////////////


        /*
        private void ChangeTransform()
        {
            for (int iter = 1; iter < transform.childCount; ++iter)
            {
                var TempLine = transform.GetChild(iter).GetComponent<RF_Linker_Line>();
                if (TempLine)
                    TempLine.ChangeTransform();
            }
        }
        */


        const string localPath = "Assets/RailFollower/RailFollower_Linkers/RAIL_Point.prefab";
        /// <summary>
        /// 진행 점을 추가
        /// </summary>
        public RF_Linker_Base AddPoint()
        {
            // AssetDatabase.FindAssets(); 검증하고 싶을때에는 추가
            RF_Linker_Base temp_Linker =
                ((GameObject)PrefabUtility.InstantiatePrefab(
                AssetDatabase.LoadAssetAtPath(
                localPath
                , typeof(GameObject))
                )).GetComponent<RF_Linker_Base>();
            temp_Linker.transform.SetParent(transform.parent);
            temp_Linker.transform.position = transform.position;
            temp_Linker.name = "new" + temp_Linker.name + transform.parent.childCount;
            AddPath(ref temp_Linker);

            Selection.activeGameObject = temp_Linker.gameObject;
            //SceneView.FrameLastActiveSceneView();
            return temp_Linker;
        }




        /// <summary>
        /// 진행 가능 방향 추가
        /// </summary>
        public RF_Linker_Line AddPath()
        {
            RF_Linker_Line temp_Path = (new GameObject("NewPath" + transform.childCount)).AddComponent(typeof(RF_Linker_Line)) as RF_Linker_Line;
            temp_Path.transform.SetParent(transform);


            return temp_Path;
        }
        public RF_Linker_Line AddPath(ref RF_Linker_Line _Line)
        {
            RF_Linker_Line temp_Path = AddPath();
            temp_Path.Next = _Line;
            return temp_Path;
        }

        public RF_Linker_Line AddPath(ref RF_Linker_Base _Linker)
        {
            RF_Linker_Line temp_Path = AddPath();
            temp_Path.Next = _Linker.AddPath(ref temp_Path);
            return temp_Path;
        }


        
#endif

    }

}