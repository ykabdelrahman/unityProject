using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    [SerializeField] private Transform Player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Player.position.x,Player.position.y,transform.position.z);   
    }
}
