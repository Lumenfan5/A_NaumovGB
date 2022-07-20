using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBomb : MonoBehaviour
{
    [SerializeField] private Bomb bombprefab;
    [SerializeField] public Transform mineSpawnPlace;
    //private GameObject Player;
    void Update()
    {
        Bomb();
                
    }

    void Bomb()
    {
          
                    
      if (Input.GetKeyUp(KeyCode.F))
      
       //var Bomb = Instantiate(bombprefab, parent.transform.forward, Quaternion.identity);
       //mineSpawnPlace = Player.transform;
        Instantiate(bombprefab, mineSpawnPlace.position, mineSpawnPlace.rotation);
       
         
    }
    


}

