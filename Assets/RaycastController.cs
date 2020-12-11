using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistaneRay = 10f;
    public static RaycastController instance;
    public Text birdName;
    public Transform gunFlashTarget;
    private float fireRate = 1.6f;
    private bool nextShot = true;
    private string objName = "";

    AudioSource audio;
    public AudioClip[] clips;

    void Awake(){
        if(instance == null) {
            instance = this;
        }
    }

    public void playSound(int sound) {
        audio.clip = clips[sound];
        audio.Play();
    }

    void Start()
    {
        StartCoroutine (spawnNewBird());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        if(nextShot) {
            StartCoroutine (takeShot());
        }
    }

    private IEnumerator takeShot(){
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        GameObject gunFlash = Instantiate(Resources.Load("gunFlashSmoke", typeof(GameObject))) as GameObject;
        gunFlash.transform.position = gunFlashTarget.position;
        yield return new WaitForSeconds(fireRate);
        nextShot = true;

    }

    private IEnumerator spawnNewBird(){
        yield return new WaitForSeconds(3f);
        GameObject newBird = Instantiate(Resources.Load("Bird_Asset",typeof(GameObject))) as GameObject;
        newBird.transform.localScale = new Vector3(10f,10f,10f);

        //random start position
        Vector3 temp;
        temp.x = Random.Range(-2.5f,2.5f);
        temp.y = Random.Range(0.4f,1f);
        temp.z = Random.Range(-2.5f,2.5f);
        newBird.transform.position = new Vector3 (temp.x, temp.y-6.5f, temp.z);
        
    }
}
