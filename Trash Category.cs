using System.Collections.Generic;
using UnityEngine;

public class TrashCategory : MonoBehaviour
{
    

public enum TrashType
{
    Type1, // 纸张
    Type2, // 塑料
    Type3, // 金属
    Type4,  // 玻璃
    None
    }

[System.Serializable]
public class Trash
{
    public TrashType type;
    public string name;
    public Sprite icon;
}

public class TrashGame : MonoBehaviour
{
    private TrashType[] container = new TrashType[4];
    private int filledSlots = 0;

    public void PickupTrash(Trash trash)
    {
        if (filledSlots < 4)
        {
            container[filledSlots] = trash.type;
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
            if (container[i] == container[i + 1] && container[i] == container[i + 2] && container[i] != TrashType.None)
            {
                Debug.Log("Matched! Removing trash...");
                RemoveTrash(i);
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
                container[index + i] = TrashType.None;
            }
        }
        UpdateContainer();
    }

    private void UpdateContainer()
    {
        int writeIndex = 0;
        for (int i = 0; i < filledSlots; i++)
        {
            if (container[i] != TrashType.None)
            {
                container[writeIndex] = container[i];
                writeIndex++;
            }
        }
        for (int i = writeIndex; i < 4; i++)
        {
            container[i] = TrashType.None;
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
}
