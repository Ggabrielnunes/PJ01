using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public BaseEnemy[] enemyList;

	public void MInitialize()
    {
        for(int i = 0; i < enemyList.Length; i++)
        {
            enemyList[i].MInitialize();
        }
    }

    public void MUpdate()
    {
        for (int i = 0; i < enemyList.Length; i++)
        {
            enemyList[i].MUpdate();
        }
    }

    public void UpdateEnemyEmotions(float p_mood)
    {
        for (int i = 0; i < enemyList.Length; i++)
        {
            enemyList[i].UpdateEmotion(p_mood);
        }
    }
}
