using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlateManager : MonoBehaviour {
    [SerializeField]
    private List<NamePlate> listNamePlate = null;

	private void Awake()
	{
        Debug.Log("rider::NamePlateManager::Awake");
        GameSceneSettingManager.Instance.SetNamePlateManager(this);
	}

	public NamePlate GetEmptyNamePlate()
    {
        foreach(NamePlate plate in listNamePlate)
        {
            if(!plate.gameObject.activeSelf)
            {
                plate.gameObject.SetActive(true);
                return plate;
            }
        }
        return null;
    }
}
