        public override bool Equals(object obj)
        {
            return this == null;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
  bool operator() (const CObject *pObject1, const CObject *pObject2) const
        {
                if ( pObject1->GetCurY() < pObject2->GetCurY() )
                        return TRUE;

                return FALSE;
        }




방향설정 셋팅을 했으니 좀 휘게 해주자.
해당지역을 추적하게
using Linker = RailFollower_Linker;

C++ 개발자를 위한 C#
https://docs.microsoft.com/ko-kr/previous-versions/visualstudio/visual-studio-2008/yyaad03b(v=vs.90)


https://silisian.tistory.com/70


https://docs.unity3d.com/kr/current/Manual/editor-EditorWindows.html

https://docs.unity3d.com/kr/current/Manual/ModifyingSourceAssetsThroughScripting.html

https://docs.unity3d.com/kr/current/Manual/FormatDescription.html

https://ateliersera.blog.me/220734981159

# C# 기본

[마소 문서 - 한정자 모음](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/)

string.IsNullOrEmpty(문자열)

잡
https://ntbda.tistory.com/16
https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/using-directive

https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords

https://hidingzz.tistory.com/618

c# ref return dictionary




에셋DB
https://docs.unity3d.com/ScriptReference/AssetDatabase.LoadAssetAtPath.html
https://docs.unity3d.com/ScriptReference/AssetDatabase.FindAssets.html
https://docs.unity3d.com/kr/current/Manual/LoadingResourcesatRuntime.html



[저장 찾은곳](https://forum.unity.com/threads/solved-creating-prefab-variant-with-script.546358/) + [다른방법](https://answers.unity.com/questions/27626/how-to-create-prefabs-from-editor-scripts.html)

[프리팹 변경점 - ](https://openlevel.postype.com/post/2984016)

[프리팹 에셋 저장](https://docs.unity3d.com/ScriptReference/PrefabUtility.SaveAsPrefabAsset.html)

https://docs.unity3d.com/ScriptReference/PrefabUtility.html

https://docs.unity3d.com/Manual/CreateDestroyObjects.html


https://m.blog.naver.com/PostView.nhn?blogId=yoohee2018&logNo=220700239540&proxyReferer=https%3A%2F%2Fwww.google.com%2F


https://docs.unity3d.com/kr/530/Manual/DirectionDistanceFromOneObjectToAnother.html

# 호출법

       var prefab = AssetDatabase.LoadAssetAtPath(
                            localPath
                            , typeof(GameObject));// as RailFollower_Linker;

                        GameObject objSource = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                        GameObject obj = PrefabUtility.SaveAsPrefabAsset(objSource, localPath);


//https://sites.google.com/site/unity3dstudy/home/unity3d-curriculum/unity---c/4

https://docs.unity3d.com/kr/current/Manual/class-Skybox.html