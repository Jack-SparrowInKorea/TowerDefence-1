using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;


public class Player
{

}
public class CubeManager : MonoBehaviour
{
    // 이벤트 선언. 

    public event Action HitEvent;
    
    //GameObject 캔버스가 들어있는
    public GameObject CanvasObj;  

    // class name; 
    public CanvasManager canvasManager;
    public Player player;

    private int power;
    public int Power
    {
        get { return power; }
        set {

            power = value;
        
        }
    }


    public float rotationSpeed = 100f;    
    
    public GameObject AnotherCube;

    private GameObject hiddenCube;

    void Start()
    {
        
    }

    public void HideAndShowAnotherCube()
    {       
        AnotherCube.SetActive(false);       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {

            canvasManager.ShowOneFirstPanel();
            player.Equals(AnotherCube);
        }

        

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);  


    }

    private void OnCollisionEnter(Collision collision)
    {
        HitEvent?.Invoke();
        // 로직 
        Debug.Log("OnCollisionEnter" + collision.ToString());
    }
}
