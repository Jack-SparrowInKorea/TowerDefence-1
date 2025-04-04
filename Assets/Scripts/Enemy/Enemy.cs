using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //����:
    //������Ȳ: Ÿ���� �߻�,  ���ʹ̵� �߻�. 
    // �Ŀ��� ���� 0�����ϸ� �ı�, 
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
