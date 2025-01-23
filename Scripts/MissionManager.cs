using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<GameObject> missions = new List<GameObject>();
    public List<RectTransform> targets = new List<RectTransform>();

    public void Start()
    {
        LoadMissions();
    }

    public void LoadMissions()
    {
        for(int i = 0; i < 3; i++)
        {
            Instantiate(missions[Random.Range(0, missions.Count)], targets[i]);
        }
    }    
}
