using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour {
    private Text textName = null;
    private RectTransform ownRectTfm;
    private Camera targetCamera = null;
    private Transform targetTfm = null;
    private Vector3 offset = new Vector3(0.0f, 1.2f, 0);

	// Use this for initialization
	void Start ()
    {
        ownRectTfm = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((targetTfm == null) || (targetCamera == null)) { return; }

        textName.enabled = IsVisiblePlate();
        if (!textName.enabled) { return; }
        ownRectTfm.position
            = RectTransformUtility.WorldToScreenPoint(targetCamera, targetTfm.position + offset);
	}

    public void SetupTarget(string name, Transform tfm)
    {
        targetCamera = GameSceneSettingManager.Instance.GetMainCamera();
        textName = GetComponent<Text>();
        textName.text = name;
        targetTfm = tfm;
    }

    private bool IsVisiblePlate()
    {
        Matrix4x4 V = targetCamera.worldToCameraMatrix;
        Matrix4x4 P = targetCamera.projectionMatrix;
        Matrix4x4 VP = P * V;


        var p = targetTfm.position;
        Vector4 pos = VP * new Vector4(p.x, p.y, p.z, 1.0f);

        if (pos.w == 0.0f)
        {
            return true;
        }

        float x = pos.x / pos.w;
        float y = pos.y / pos.w;
        float z = pos.z / pos.w;


        if (x < -1.0f)
        {
            return false;
        }
        if (x > 1.0f)
        {
            return false;
        }

        if (y < -1.0f)
        {
            return false;
        }
        if (y > 1.0f)
        {
            return false;
        }

        if (z < -1.0f)
        {
            return false;
        }

        if (z > 1.0f)
        {
            return false;
        }

        return true;
    }

}
