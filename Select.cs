using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TrashCategory;

public class Select : MonoBehaviour
{
    private Trash[] container = new Trash[4]; // 存储垃圾实例
    private int filledSlots = 0;

    public void PickupTrash(Trash trash)
    {
        if (filledSlots < 4)
        {
            container[filledSlots] = trash; // 存储垃圾实例
            filledSlots++;
            CheckForMatches();
            CheckForGameOver();
        }
        else
        {
            Debug.Log("Game Over: Container is full!");
        }
    }
    private void CheckForMatches()
    {
        for (int i = 0; i < filledSlots - 2; i++)
        {
            if (container[i] != null && container[i + 1] != null && container[i + 2] != null &&
                container[i].type == container[i + 1].type && container[i].type == container[i + 2].type)
            {
                Debug.Log("Matched! Removing trash...");
                RemoveTrash(i);
                gameManager.AddScore(); // 增加分数
                return;
            }
        }
    }
    private void RemoveTrash(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            if (index + i < filledSlots)
            {
                container[index + i] = null; // 使用 null 表示垃圾已被移除
            }
        }
        UpdateContainer();
    }
    private void UpdateContainer()
    {
        int writeIndex = 0;
        for (int i = 0; i < filledSlots; i++)
        {
            if (container[i] != null) // 检查是否为 null
            {
                container[writeIndex] = container[i];
                writeIndex++;
            }
        }
        for (int i = writeIndex; i < 4; i++)
        {
            container[i] = null; // 清空多余的槽位
        }
        filledSlots = writeIndex;
    }
    private void CheckForGameOver()
    {
        if (filledSlots == 4)
        {
            Debug.Log("Game Over: Container is full! You failed.");
        }
    }
}

