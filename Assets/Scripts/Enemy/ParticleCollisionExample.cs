using UnityEngine;

public class ParticleCollisionExample : MonoBehaviour
{
    public ParticleSystem particleSystem; 

    void Start()
    {
        var collision = particleSystem.collision;
        collision.enabled = true;
        collision.type = ParticleSystemCollisionType.World;
        //collision.collidesWith = LayerMask.GetMask("Default");
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("other.name " +  other.name);

        // ���� �ǰݵǾ����� ��� �Ǵ��ұ�? 
        // ���� �ǰ� Ȥ�� ���� �ִ� �ǹ��� �ǰ� �� ���� �����ϱ�.
        // 
        if (other.GetComponent<Enemy>() != null)
        {
            Debug.Log("Enemy hit");
            other.GetComponent<Enemy>().CheckHP(1000);
        }
    }
}