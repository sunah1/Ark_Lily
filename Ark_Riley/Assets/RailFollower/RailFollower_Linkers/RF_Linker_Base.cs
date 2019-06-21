using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RailFollower
{
    [InitializeOnLoad]
 public class RF_Linker_Base : MonoBehaviour
{
    private Linker_Line left_link;
    public Linker_Line LeftLink
        {
            get {
                if (null == left_link)
                    left_link = new Linker_Line(this);
                return left_link; }
            set {
                left_link = value;
            }
        }
//[SerializeField]
    private Linker_Line right_link;
    public Linker_Line RightLink
        {
            get {
                if (null == right_link)
                    right_link = new Linker_Line(this);
                return right_link; }
            set{
                right_link = value;
            }
        }

    private void Awake()
    {
        LeftLink.Base = this;
        RightLink.Base = this;
    }

        void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    const string localPath = "Assets/RailFollower/RailFollower_Linkers/RAIL_Point.prefab";
    public void AddLink(RailAction _action)
    {
        Debug.Log("버튼이 눌려부렸으");
            switch (_action)
            {
                case RailAction.STOP:/*
                    if(EditorUtility.DisplayDialog("Are you sure?",
                   "The Prefab already exists. Do you want to overwrite it?",
                   "Yes",
                   "No"))
                        Debug.Log("ok");
                    else
                        Debug.Log("cancel");
                        */
                    if (null != LeftLink.Next)
                        LeftLink.Next.Reset();
                    if (null != RightLink.Next)
                        RightLink.Next.Reset();
                    LeftLink.Reset();
                    RightLink.Reset();
                    break;
                case RailAction.LEFT:
                    {
                        RF_Linker_Base temp = CreateLink();
                        temp.transform.SetParent(transform.parent);

                        LeftLink.SetLink_Left(this,ref temp);

                        //this.Left_Link.Next = temp;
                        //temp.Right_Link.Next = this;
                    }
                    break;
                case RailAction.RIGHT:
                    {
                        RF_Linker_Base temp = CreateLink();
                        temp.transform.SetParent(transform.parent);

                        RightLink.SetLink_Right(this, ref temp);

                        //this.Right_Link.Next = temp;
                        //temp.Left_Link.Next = this;
                    }
                    break;
                default:
                    break;
            }


        }
        //out ref 둘다 할당한채로 넘겨 받아야 혀
        private RF_Linker_Base CreateLink()
        {
            return ((GameObject)PrefabUtility.InstantiatePrefab(
            AssetDatabase.LoadAssetAtPath(
                 localPath
                 , typeof(GameObject))
                 )).GetComponent<RF_Linker_Base>();
            /*
            //var temp = AssetDatabase.FindAssets();
            var prefab = AssetDatabase.LoadAssetAtPath(
                localPath
                , typeof(GameObject));// as RailFollower_Linker;
            GameObject objSource = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            //GameObject obj = PrefabUtility.SaveAsPrefabAsset(objSource, localPath);
            return objSource.GetComponent<RailFollower_Linker>();
            */
        }


    }

}