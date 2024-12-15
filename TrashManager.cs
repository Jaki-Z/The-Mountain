using System;
using System.Collections.Generic;
using UnityEngine;
using static TrashCategory;

public class TrashManager : MonoBehaviour
{
    public List<Trash> trashList; // 在Inspector中配置

    private TrashGame trashGame; // 引用 TrashGame 脚本

    void Start()
    {
        trashGame = GetComponent<TrashGame>();
    }

    public void SpawnTrash(int index)
    {
        // 根据索引生成垃圾
        if (index >= 0 && index < trashList.Count)
        {
            Trash trash = trashList[index];
            trashGame.PickupTrash(trash); // 将垃圾传递给 TrashGame
        }
    }

    internal void SpawnTrash(Trash trash)
    {
        throw new NotImplementedException();
    }
}
