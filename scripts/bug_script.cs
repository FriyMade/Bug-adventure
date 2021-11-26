using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bug_script : MonoBehaviour
{
    public GameObject[] arrows = new GameObject[4];
    public box_script box;
    public box_script boxWhithVid;
    public bool wasfirst = false;

    public float Angle;
    Quaternion startRot;
    public bool Rotate = false;
    float RotateAngle = 0;
    public bool UInotActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Rotate)
        {
            startRot = transform.rotation;
            RotateAngle += 0.1f;
            transform.rotation = Quaternion.Slerp(startRot, Quaternion.Euler(0, Angle, 0), RotateAngle);

            if (transform.rotation.eulerAngles == new Vector3(0, Angle, 0))
            {
                Rotate = false;
                RotateAngle = 0;
            }
        }
    }

    private void OnMouseDown()
    {
        if (UInotActive) 
        {
            switcher();
        }
    }

    public void switcher()
    {
        if (wasfirst)
        {
            for(int i = 0; i < 4; i++)
            {
                arrows[i].transform.position = new Vector3(0, 50, 0);
            }

            wasfirst= false;
            if (boxWhithVid != null)
            {
                boxWhithVid.switcher();
            }
        }
        else
        {
 
            foreach (Transform i in box.NearBox)
            {
                if (i != null)
                {
                    if (i.position.z > (transform.position.z))
                    {
                        arrows[0].transform.position = new Vector3(i.position.x, 11, i.position.z);
                    }
                    else if (i.position.z < transform.position.z)
                    {
                        arrows[2].transform.position = new Vector3(i.position.x, 11, i.position.z);
                    }
                    else if (i.position.x < transform.position.x)
                    {
                        arrows[3].transform.position = new Vector3(i.position.x, 11, i.position.z);
                    }
                    else if (i.position.x > transform.position.x)
                    {
                        arrows[1].transform.position = new Vector3(i.position.x, 11, i.position.z);
                    }

                    wasfirst = true;
                }
            }
        }
    }
}
