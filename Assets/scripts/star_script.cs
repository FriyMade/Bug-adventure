using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_script : MonoBehaviour
{
    public GameObject Bug;
    public GameObject Mesh;
    public GameObject GameManager;
    GameManager_script GameManager_script;
    // Start is called before the first frame update
    void Start()
    {
        GameManager_script = GameManager.GetComponent<GameManager_script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeLevel(float time)
    {
        yield return new WaitForSeconds(time);

        GameManager_script.nextLevel();
        GameManager_script.bug_Script.UInotActive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == Bug.GetComponent<BoxCollider>())
        {
            GameManager_script.bug_Script.UInotActive = false;
            GetComponent<AudioSource>().Play();
            GetComponent<ParticleSystem>().Play();
            Mesh.SetActive(false);
            StartCoroutine(ChangeLevel(1));
        }
    }
}
