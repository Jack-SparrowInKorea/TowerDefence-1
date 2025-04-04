using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasManager : MonoBehaviour
{
   

   

    Car myCar = new Car();
    

    public GameObject panelBegin;
    public GameObject panelPopup;
    public GameObject panelEnd;

    // Start is called before the first frame update
    void Start()
    {
        // »ó¼Ó ¿¹. 
        myCar.Drive();

        panelBegin.SetActive(false);
        panelPopup.SetActive(false);
        panelEnd.SetActive(false);
    }


    public void ShowOneFirstPanel()
    {
        panelBegin.SetActive(true);
        panelPopup.SetActive(false);
        panelEnd.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
