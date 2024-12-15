using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0; // 当前分数
    public int scoreThreshold = 10; // 胜利分数阈值
    private bool gameEnded = false; // 游戏是否结束

    public void AddScore()
    {
        if (!gameEnded)
        {
            score++;
            CheckForWin();
        }
    }

    public void CheckForWin()
    {
        if (score >= scoreThreshold)
        {
            EndGame(true); // 胜利
        }
    }

    public void CheckForLoss(bool hasCompletedPath)
    {
        if (!gameEnded && hasCompletedPath)
        {
            EndGame(false); // 失败
        }
    }

    private void EndGame(bool isWin)
    {
        gameEnded = true;

        if (isWin)
        {
            Debug.Log("You Win! Score: " + score);
            // 处理胜利逻辑，例如显示胜利画面
        }
        else
        {
            Debug.Log("You Lose! Final Score: " + score);
            // 处理失败逻辑，例如显示失败画面
        }
        // 这里可以添加重启游戏或返回主菜单的逻辑
    }
}
