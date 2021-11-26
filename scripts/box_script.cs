using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_script : MonoBehaviour
{
    public GameObject Group;
    public GroupBox_script GroupScript;
    public GameObject Bug;
    public bug_script Bug_script;
    public GameObject star;

    bool HaveStar = false;
    public bool block = false;
    public bool vid = false;
    public bool HaveBug = false;
    public bool rock = false;

    public Transform[] NearBox = new Transform[5];
    // Start is called before the first frame update
    void Start()
    {
        GroupScript = Group.GetComponent<GroupBox_script>();
        Bug_script = Bug.GetComponent<bug_script>();
    }

    private void OnMouseDown()
    {
        if(HaveBug || Bug_script.wasfirst || HaveStar || rock)
        {

        }
        else if(GroupScript.wasFirst && GroupScript.FirstBox != this)
        {
            GroupScript.SecondBox = this;
            GroupScript.ChangeBox();
        }
        else
        {
            switcher();
        }
    }

    public void switcher()
    {
        GetComponent<AudioSource>().Play();

        if (vid)
        {
            transform.position -= new Vector3(0, 2, 0);

            GroupScript.FirstBox = null;
            GroupScript.wasFirst = false;
            Bug_script.boxWhithVid = null;
        }
        else
        {
            transform.position +=new Vector3(0, 2, 0);

            GroupScript.FirstBox = this;
            GroupScript.wasFirst = true;
            Bug_script.boxWhithVid = this;
        }
        vid = !vid;
    }
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == Bug.GetComponent<BoxCollider>())
        {
            HaveBug = true;
            Bug_script.box = this;
        }
        else if (other == star.GetComponent<BoxCollider>())
        {
            HaveStar = true;
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (NearBox[i] == null && !other.gameObject.GetComponent<box_script>().block)
                {
                    NearBox[i] = other.gameObject.transform;
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == Bug.GetComponent<BoxCollider>())
        {
            HaveBug = false;
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (NearBox[i] == other.gameObject.transform)
                {
                    NearBox[i] = null;
                    break;
                }
            }
        }
    }
}

