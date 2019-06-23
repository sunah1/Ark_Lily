# 할것
- 빌보딩 심화
1. 단순 빌보딩 셋팅 설정기능 제작, xz회전 방지 : 일단 패스
2. 일정거리 유지하며 회전 시키기 : 대충 Arm스타일로 처리 가능
3. 카메라와 평행하게 X
- Path 강화
1. 베지어 곡선 추가
2. 베지어 곡선 이동
3. 이동 패스, 이동시간, 위치 등 표시+ Transform반환으로 변환



# 유니티 속성 - 속성(Attributes)
[데브코리아 목차](http://www.devkorea.co.kr/reference/Documentation/ScriptReference/20_class_hierarchy.Attributes.html)

# PropertyAttribute - 인스펙터 정리
[원본 깃허브](https://github.com/dbrizov/NaughtyAttributes)
    [이친굴](https://docs.unity3d.com/ScriptReference/PropertyAttribute.html)

[나름](https://blog.naver.com/kch8246/220699888329)
[아주조금](https://mentum.tistory.com/223)
[조금](https://rbals1101.tistory.com/72)

# PropertyDrawers

[원본 깃허브 - 일본어](https://anchan828.github.io/editor-manual/web/property_drawer.html)
[번역+괜춘함10](https://blog.naver.com/hammerimpact/220775187161)
[에디터9](http://blog.naver.com/hammerimpact/220775012493)
 28까지 있음

[2018.1 기준=한글](https://docs.unity3d.com/kr/2018.1/Manual/editor-PropertyDrawers.html)
[2019.1](https://docs.unity3d.com/ScriptReference/PropertyDrawer.html)

[그래도 한국](https://rbals1101.tistory.com/75)

[질문+누가 좀한것 ](https://forum.unity.com/threads/draw-a-field-only-if-a-condition-is-met.448855/)
https://answers.unity.com/questions/1445734/drag-and-drop-into-custom-inspector-objectfield-no.html


# 에디터 
[유니티 핸들들 - 에디터 기능추가 핵심](https://docs.unity3d.com/ScriptReference/Handles.html)

[포커싱되는 부가기능](https://docs.unity3d.com/ScriptReference/SceneView.FrameLastActiveSceneView.html)
GUIStyle 검색
EditorGUILayout

[Application.isPlaying](https://docs.unity3d.com/ScriptReference/Application-isPlaying.html)
를 이용하면 Play 상태가 아닌 에디터 상태에서 판정가능




[SerializedObject .Update](https://docs.unity3d.com/ScriptReference/SerializedObject.Update.html)
[SerializedObject . Apply](https://docs.unity3d.com/ScriptReference/SerializedObject.ApplyModifiedProperties.html)
[SerializedObject .FindProperty](https://docs.unity3d.com/ScriptReference/SerializedObject.FindProperty.html)


[SerializeField](https://docs.unity3d.com/ScriptReference/SerializeField.html)

[EditorSceneManager .MarkSceneDirty](https://docs.unity3d.com/ScriptReference/SceneManagement.EditorSceneManager.MarkSceneDirty.html)
[세이브 되게 EditorUtility.SetDirty / GetDirtyCount, IsDirty.](https://docs.unity3d.com/ScriptReference/EditorUtility.SetDirty.html)

[Undo 만드려면](https://docs.unity3d.com/ScriptReference/Undo.RecordObject.html)


C++ 개발자를 위한 C#
https://docs.microsoft.com/ko-kr/previous-versions/visualstudio/visual-studio-2008/yyaad03b(v=vs.90)


https://silisian.tistory.com/70


https://docs.unity3d.com/kr/current/Manual/editor-EditorWindows.html

https://docs.unity3d.com/kr/current/Manual/ModifyingSourceAssetsThroughScripting.html

https://docs.unity3d.com/kr/current/Manual/FormatDescription.html

https://ateliersera.blog.me/220734981159

# C# 기본

[유니티 - 전처리기](https://bluemeta.tistory.com/12)
 +[플렛폼 의존 컴파일](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html)
[유니티 - XML 주석](http://blog.naver.com/lyw94k/221132464639)

[마소 문서 - 한정자 모음](https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/)

[상수 정의 법](https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/classes-and-structs/how-to-define-constants)

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




=======================
https://docs.unity3d.com/ScriptReference/SerializedProperty.html
https://docs.unity3d.com/ScriptReference/SerializedObject.html



https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/statements-expressions-operators/how-to-define-valueequality-for-a-type
https://docs.microsoft.com/ko-kr/dotnet/csharp/programming-guide/classes-and-structs/using-properties




https://docs.unity3d.com/kr/current/Manual/RunningEditorCodeOnLaunch.html
https://docs.unity3d.com/kr/current/Manual/script-Serialization.html
https://docs.unity3d.com/kr/current/ScriptReference/SerializeField.html

https://chameleonstudio.tistory.com/56


# 에디터

[에디터](https://docs.unity3d.com/kr/current/ScriptReference/Editor.html)

[선두껍게 하려면 참조해서 코드 변경](https://answers.unity.com/questions/1139985/gizmosdrawline-thickens.html)


# 잡다한거

[널 레퍼런스 참조](https://docs.unity3d.com/kr/current/Manual/NullReferenceException.html)



# 찾아볼만한거 많은 곳들


https://killu.tistory.com/12


[외국 블로그](http://www.ryan-meier.com/blog/?p=67)
[정리만 해둔 플로그](https://smilejsu.tistory.com/1001)


[깃 언어별 설정 모음](https://github.com/github/gitignore)
[깃설정 도움](https://wnsgml972.github.io/git/git_gitignore.html)



transform.LookAt(Camera.main.transform.position, -Vector3.up);

myTransform.forward = -myCameraTransform.forward;
sprite.transform.rotation = Camera.main.transform.rotation;

transform.LookAt(Camera.main.transform.position);


  bool operator() (const CObject *pObject1, const CObject *pObject2) const
        {
                if ( pObject1->GetCurY() < pObject2->GetCurY() )
                        return TRUE;

                return FALSE;
        }
