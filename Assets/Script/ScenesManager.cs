using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    [HideInInspector]
    public List<string> scenesList = new List<string>();

    private ScenesManager() { }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(Instance == null)
        {
            Instance = this;
        }
        scenesList.Add(SceneManager.GetActiveScene().name);
    }


    /// <summary>
    /// 根据名称加载
    /// </summary>
    /// <param name="strSceneName"></param>
    public void LoadScene(string strSceneName)
    {
        try
        {
            Scene nextScene = SceneManager.GetSceneByName(strSceneName);

            if(nextScene!= null &&  nextScene != SceneManager.GetActiveScene())
            {
                StartCoroutine(AsyncLoading(strSceneName));
            }
            else
            {
                throw new Exception("The Scene Wanted is not Found, or you Load Current Scene Again!");
            }
      
        }
        catch(Exception message)
        {
            Debug.LogWarning(message);
        }
  
    }

    /// <summary>
    /// 根据索引加载
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void LoadScene(int sceneIndex)
    {
        try
        {
            if (sceneIndex < 0 || sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                throw new Exception("The Scene Wanted is not Found , Index Is Out Of Range");
            }

            Scene nextScene = SceneManager.GetSceneAt(sceneIndex);

            string nextSceneName = nextScene.name;

            if (SceneManager.GetSceneByName(nextSceneName) != null)
            {
                LoadScene(nextSceneName);
            }
        }
        catch(Exception message)
        {
            Debug.LogWarning(message);
        }
           
    }


    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    IEnumerator AsyncLoading(string sceneName)
    {
        yield return new  WaitForEndOfFrame();
        int displayProgress = 0;
        int toProgress = 0;

        AsyncOperation asyncOpera = SceneManager.LoadSceneAsync(sceneName);

        asyncOpera.allowSceneActivation = false;

        while(asyncOpera.progress < 0.9f)
        {
            toProgress = (int)asyncOpera.progress * 100;

            while(displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercent(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }

        toProgress = 100;
        while(displayProgress < toProgress )
        {
            ++displayProgress;
            SetLoadingPercent(displayProgress);
            yield return new WaitForEndOfFrame();
        }

        asyncOpera.allowSceneActivation = true;
    }

    
    /// <summary>
    /// 进度
    /// </summary>
    /// <param name="percent"></param>
    void SetLoadingPercent(int percent)
    {
        sliderPercent.Instance.SetSliderValue(percent);
    }

}//End Class
