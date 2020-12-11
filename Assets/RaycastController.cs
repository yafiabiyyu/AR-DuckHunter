using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxDistaneRay = 10f;
    public static RaycastController instance;
    public Transform gunFlashTarget;
    private float fireRate = 1.6f;
    private bool nextShot = true;
    private string objName = "";

    void Awake(){
        if(instance == null) {
            instance = this;
        }
    }

    void Start()
    {
        StartCorountine (spawnNewBird());
    }

    // Update is called once per frame
    void Update()
    {
        
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
