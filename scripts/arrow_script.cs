using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_script : MonoBehaviour
{
    public GameObject bug;
    bug_script Bug_Script;
    // Start is called before the first frame update
    void Start()
    {
        Bug_Script = bug.GetComponent<bug_script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        Bug_Script.Angle = transform.rotation.eulerAngles.y + 90 == 360 ? 0 : transform.rotation.eulerAngles.y + 90;
        Bug_Script.Rotate = true; 
        bug.transform.localPosition =( transform.localPosition - new Vector3(0, 1.0f, 0));

        Bug_Script.switcher();
    }
}
