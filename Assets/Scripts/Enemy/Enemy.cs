using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //과제:
    //교전상황: 타워도 발사,  에너미도 발사. 
    // 파워가 먼저 0도달하면 파괴, 
    // UI, 


    public static event Action OnDestroyEnemy;

    int HP = 100;

    public void CheckHP(int damage)
    {
        HP = HP - damage;
        if (HP <= 0)
        {
            OnDestroyEnemy?.Invoke();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision bullet)
    {
        CheckHP(10);
        Debug.Log("OnCollisionEnter!!!!!" + bullet.gameObject.name);
    }


    private void OnTriggerEnter(Collider other)
    {
        CheckHP(10);
        Debug.Log("OnTriggerEnter!!!!!");
    }


}
