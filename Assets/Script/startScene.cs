using UnityEngine;
using System.Collections;

public class startScene : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Instance.scenesList[ScenesManager.Instance.scenesList.Count - 1]);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.P))
        {
            //ScenesManager.Instance.LoadScene(ScenesManager.Instance.scenesList[ScenesManager.Instance.scenesList.Count-1]);
        }
	}

    public void OnBtnClick()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Instance.scenesList[ScenesManager.Instance.scenesList.Count - 1]);
    }
}
