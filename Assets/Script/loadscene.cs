using UnityEngine;
using System.Collections;

public class loadscene : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            ScenesManager.Instance.scenesList.Add("Learn_ChangeScene01");
            Application.LoadLevel("Loading");
        }
	}


    public void OnBtnClick()
    {
        ScenesManager.Instance.scenesList.Add("Learn_ChangeScene01");
        Application.LoadLevel("Loading");
    }
}
