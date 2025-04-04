


using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public static event Action StaticDestroyEvent;
    public        event Action NotStaticDestroyEvent;
    
    public Transform gunbarrel;
    public Transform RealTarget;
    public GatlingGun gatlingGun;
    
    public UIManager _UIManager;
    
    [Header("PS")]
    public ParticleSystem MuzzelFlash_ParticleSystem;
    public ParticleSystem BulletShells_ParticleSystem;
    public ParticleSystem Traser_ParticleSystem;

    [Header("PS Destroy")]
    public ParticleSystem Destroy_ParticleSystem;
       

    int Damage = 20;   // 살상력
    int HP = 100;      // 생존력,  HP
    float AttackSpeed = 0.5f;  // 자동 공격 모드이므로 배치 후, 공격개시.
    float reloadInterval = 3.0f;  // 20발을 쏘고나서 재장전에 걸리는 시간.
    int BulletCount = 5;

    float lapTime = 0;

    private void Start()
    {
        Destroy_ParticleSystem.Stop();  
        gatlingGun.enabled = false;
        Invoke("DoSomething", 3);
    }

    void DoSomething()
    {
        MuzzelFlash_ParticleSystem.Play();
        BulletShells_ParticleSystem.Play();
        Traser_ParticleSystem.Play();
    }
    public void Fire()
    {
        if (BulletCount <= 0)
        {
            Reload();
            return;
        }
        BulletCount--;
    }

    Transform target = null;

    //1초에 24실행.   
    private void Update()
    {
    #if UNITY_EDITOR  

        if (Input.GetKeyDown(KeyCode.A)) {

            TakeDamage(5);            
        }      
    #endif


        lapTime += Time.deltaTime;  // 1초에 24실행, 0.22

        if(lapTime > 1)
        { 
            Fire();
            lapTime = 0;
        }
        gunbarrel.LookAt(RealTarget);
    }

    public void Reload()
    {
        MuzzelFlash_ParticleSystem.Stop();
        BulletShells_ParticleSystem.Stop();
        Traser_ParticleSystem.Stop();

        BulletCount = 5;
        Invoke("DoSomething", 3);
    }

    void Destroy()
    {   
        // 
        ///DestroyEvent?.Invoke();
        //_UIManager.OneTurretRemove();
        
        transform.gameObject.SetActive(false);   // 사라짐.         
        Destroy_ParticleSystem.Play();   
        // 파티클 이펙트  플레이
    }

    public void TakeDamage(int damage)
    {
        HP = HP - damage;

        if (HP <= 0)
        {
            Destroy();
        }
    }
}
