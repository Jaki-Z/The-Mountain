using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TrashCategory;

public class TrashSelector : MonoBehaviour
{
    public TrashManager trashManager; // 引用 TrashManager
    public Button[] trashButtons; // 垃圾类型按钮
    private Trash selectedTrash; // 当前选择的垃圾

    private void Start()
    {
        // 为每个按钮添加点击事件
        for (int i = 0; i < trashButtons.Length; i++)
        {
            int index = i; // 局部变量防止闭包问题
            trashButtons[i].onClick.AddListener(() => SelectTrash(index));
        }
    }

    public void SelectTrash(int index)
    {
        if (index >= 0 && index < trashManager.trashList.Count)
        {
            selectedTrash = trashManager.trashList[index]; // 设置当前选择的垃圾
            Debug.Log($"Selected Trash: {selectedTrash.name}");
        }
    }

    public Trash GetSelectedTrash()
    {
        return selectedTrash; // 返回当前选择的垃圾
    }
}
