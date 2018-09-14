using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class DebugUI : MonoBehaviour {
    [SerializeField]
    private Text textArea = null;

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {

        MotorCycleController ctrl = GameSceneSettingManager.Instance.GetMortorcycleController();
        string data = "";
        if(ctrl != null)
        {
            data = string.Format("Target Speed = {0}\nCurrent Speed = {1}", ctrl.TargetMoveSpeed, ctrl.CurrentMoveSpeed);   
        }
        textArea.text = data;
    }

}
