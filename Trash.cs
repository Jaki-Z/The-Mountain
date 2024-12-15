using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TrashCategory;

public class garbage_ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<Trash> trashList; // 在Inspector中配置

    public void SpawnTrash(int index)
    {
        // 根据索引生成垃圾
        Trash trash = trashList[index];
        // 处理生成垃圾的逻辑（例如，实例化游戏对象等）
    }
}
