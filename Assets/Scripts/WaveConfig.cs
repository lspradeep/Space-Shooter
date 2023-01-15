using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create WaveConfig",fileName = "New WaveConfig")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] Transform wavePath;
    [SerializeField] List<GameObject> enemies;

    //Points
    public List<Transform> getAllPoints()
    {
        List<Transform> points = new List<Transform>();

        foreach(Transform t in wavePath)
        {
            points.Add(t);
        }
        return points;
    }

    public Transform getStartPoint()
    {
        return wavePath.GetChild(0);
    }

    public Transform getPointAt(int index)
    {
        return wavePath.GetChild(index);
    }

    public int getPointsCount()
    {
        return wavePath.childCount;
    }
    //Points - end

    //Enemies
    public int getEnemiesCount()
    {
        return enemies.Count;
    }

    public GameObject getEnemiesAt(int index)
    {
        return enemies[index];
    }
    //Enemies - end

}
