using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private bool currentlyplacing;
    private bool currentlydeleting;

    private BuildingPreset curBuildingPreset;

    private float indicatorUpdateTime = 0.05f;
    private float lastUpdateTime;
    private Vector3 curIndicatorPos;

    public GameObject placementIndicator;
    public GameObject deleteIndicator;

    public void BeginNewBuildingPlacement(BuildingPreset preset)
    {
        /*if(City.instance.money<preset.cost)
        {
            return;
        }*/

        currentlyplacing = true;
        curBuildingPreset = preset;
        placementIndicator.SetActive(true);
    }

    void CancelBuildingPlacement()
    {
        currentlyplacing = false;
        placementIndicator.SetActive(false);
    }

    public void ToggleDelete()
    {
        currentlydeleting = !currentlydeleting;
        deleteIndicator.SetActive(currentlydeleting);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CancelBuildingPlacement();
        }

        if(Time.time-lastUpdateTime>indicatorUpdateTime)
        {
            lastUpdateTime = Time.time;
            curIndicatorPos = Selector.instance.GetCurTilePosition();

            if(currentlyplacing)
            {
                placementIndicator.transform.position = curIndicatorPos;
            }else if(currentlydeleting)
            {
                deleteIndicator.transform.position = curIndicatorPos;
            }
        }

        if(Input.GetMouseButtonDown(0) && currentlyplacing)
        {
            PlaceBuilding();
        }else if(Input.GetMouseButtonDown(0) && currentlydeleting)
        {
            DeleteBuilding();
        }
    }

    void PlaceBuilding()
    {
        GameObject buildingObj = Instantiate(curBuildingPreset.prefab, curIndicatorPos, Quaternion.identity);
        City.instance.OnPlaceBuilding(buildingObj.GetComponent<Building>());
        CancelBuildingPlacement();
    }

    void DeleteBuilding()
    {
        Building buildingToDestroy = City.instance.buildings.Find(x => x.transform.position == curIndicatorPos);
        if(buildingToDestroy!=null)
        {
            City.instance.OnRemoveBuilding(buildingToDestroy);
        }
    }
}
