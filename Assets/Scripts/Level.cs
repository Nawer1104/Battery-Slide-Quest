using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> gameObjects;

    public void FindTarget(GameObject batterty)
    {
        foreach(GameObject go in gameObjects)
        {
            if (go.GetComponent<Base>().type == batterty.GetComponent<Batterty>().type && go.GetComponent<Base>().isTargeted == false)
            {
                batterty.GetComponent<Batterty>().SetTarget(go.transform);
                go.GetComponent<Base>().isTargeted = true;
                CheckFinish();
                return;
            }
        }
    }

    public void CheckFinish()
    {
        foreach (GameObject go in gameObjects)
        {
            if (go.GetComponent<Base>().isTargeted == false)
            {
                return;
            }
        }
        GameManager.Instance.CheckLevelUp();
    }

    public static List<GameObject> GetAllChilds(GameObject Go)
    {
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < Go.transform.childCount; i++)
        {
            list.Add(Go.transform.GetChild(i).gameObject);
        }
        return list;
    }
}
