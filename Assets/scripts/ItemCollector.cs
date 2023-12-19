using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int apples = 0;
    public AudioSource s1;
    
    [SerializeField] private Text appleText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject); 
            apples++;
            appleText.text = "Score:" + apples;
            s1.Play();
            
        }
        else if (collision.gameObject.CompareTag("minus"))
        {
            Destroy(collision.gameObject); 
            apples--;
            appleText.text = "Score:" + apples;
            s1.Play();
            
            
        }
        else if (collision.gameObject.CompareTag("plus"))
        {
            Destroy(collision.gameObject); 
            apples= apples+10;
            appleText.text = "Score:" + apples;
            s1.Play();
            
        }
    
    }

}
