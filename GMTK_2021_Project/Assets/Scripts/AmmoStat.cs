using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoStat : MonoBehaviour
{
    [SerializeField] int maxCapacity = 100;
    [SerializeField] int bulletsLeft = 0;
    
    void Awake()
    {
        if(bulletsLeft > maxCapacity)       // Prevents accidentally putting more bullets than capacity (through editor)
            bulletsLeft = maxCapacity;
    }
    // Try to expend a certain number of bullets from storage
    public bool TryUseBullets(int numBullets)
    {
        if(numBullets > bulletsLeft)
            return false;
        else
        {
            bulletsLeft -= numBullets;
            return true;
        }
    }

    public void AddBullets(int numBullets)
    {
        bulletsLeft += numBullets;
        if(bulletsLeft > maxCapacity)
            bulletsLeft = maxCapacity;
    }
}
