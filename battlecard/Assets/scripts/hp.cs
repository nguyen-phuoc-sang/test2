using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    private int heal = 6;

    public GameObject menu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("bullet"))
        {
            heal--;
            if (heal == 0)
            {
                Destroy(gameObject);
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            
        }
    }
}
