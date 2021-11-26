using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBox_script : MonoBehaviour
{

    public bool wasFirst = false;
    public box_script FirstBox;
    public box_script SecondBox;
    Vector3 med;

    public GameObject movementbox;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void ChangeBox()
    {
        FirstBox.transform.position -= new Vector3(0, 2, 0);

        med = SecondBox.transform.position;
        SecondBox.transform.position = FirstBox.transform.position;
        FirstBox.transform.position = med;

        FirstBox.transform.position += new Vector3(0, 2, 0);
        FirstBox.switcher();

    } 
    // Update is called once per frame
    void Update()
    {
    }
    
}
