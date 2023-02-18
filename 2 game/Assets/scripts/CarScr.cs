using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScr : MonoBehaviour
{
    public Transform CarSpawn;
    public Transform CarSpawn2;
    public GameObject Carl;
    public GameObject Carl2;
    public void Car()
    {
        Transform _sp = CarSpawn;
        
    Instantiate(Carl, _sp.position, _sp.rotation);
        
    } 
    public void Car2()
    {
          Transform io = CarSpawn2;
        Instantiate(Carl2, io.position, io.rotation);
    }
}
