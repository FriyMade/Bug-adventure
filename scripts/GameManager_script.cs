using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_script : MonoBehaviour
{
    public GameObject UI;
    public Camera Cam;
    public GameObject Bug;
    public GameObject grass;
    public GameObject[] levels;
    public GameObject CamManager;
    public GameObject Text;
    public GameObject Exit;
    public bug_script bug_Script;

    float Angle;
    Quaternion startRot;
    bool Rotate = false;
    float RotateAngle = 0;

    float scalingpoint;
    int levelnum = 0;
    float max = 30.5f;
    bool scaling = false;
    // Start is called before the first frame update
    void Start()
    {
        bug_Script = Bug.GetComponent<bug_script>();
    }

    public void nextLevel()
    {
        levels[levelnum].SetActive(false);
        levelnum++;
        if (levelnum == 11)
        {
            Bug.SetActive(false);
            Exit.SetActive(true);
            Text.SetActive(true);
        }
        else
        {
            levels[levelnum].SetActive(true);
            if (levelnum == 1 || levelnum > 4)
            {
                CamManager.transform.position = new Vector3(10, 0, 10);
            }
            else
            {
                CamManager.transform.position = new Vector3(5, 0, 5);
            }
            if (levelnum == 5)
            {
                scaling = true;
                scalingpoint = 60;
            }
        }
    }
    public void OnStartClick()
    {
        scaling = true;
        scalingpoint = 50;
        bug_Script.UInotActive = true;
        nextLevel();
    }
    // Update is called once per frame
    void Update()
    {
        if (scaling)
        {
            Cam.fieldOfView = max;
            max += 0.5f;
            if(max == scalingpoint)
            {
                scaling = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Angle -= 90;
            Rotate = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Angle += 90;
            Rotate = true;
        }

        if (Rotate)
        {
            startRot = CamManager.transform.rotation;
            RotateAngle += 0.1f;
            CamManager.transform.rotation = Quaternion.Slerp(startRot, Quaternion.Euler(0, Angle, 0), RotateAngle);

            if (Quaternion.Euler(0, Angle, 0) == CamManager.transform.rotation)
            {
                Rotate = false;
                RotateAngle = 0;
            }
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
