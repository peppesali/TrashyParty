using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform component;
        
        component = this.gameObject.GetComponent<Transform>();
        component.position = new Vector3(component.position.x-0.01f, component.position.y, component.position.z);
    }
}
