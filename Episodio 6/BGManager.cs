using UnityEngine;
using System.Collections;

public class BGManager : MonoBehaviour {

    public Transform[] bgs;

    Transform lastBg;

    float lastXBg = 0f;


	// Use this for initialization
	void Start () {
        FindLastPoolingCoordinate(bgs);
	}

    /// ho un array di 4 oggetti: 0 1 2 3 
    void FindLastPoolingCoordinate(Transform[] objects)
    {
        for(int i =0; i <= objects.Length - 1; i++)
        {
            if(objects[i].position.x > lastXBg)
            {
                lastBg = objects[i];
                lastXBg = objects[i].position.x;
            }
        }
    }
	

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Background")
        {
            float size = col.bounds.size.x;
            Vector3 newPosition = new Vector3(lastBg.transform.position.x + size, col.transform.position.y, col.transform.position.z);
            col.transform.position = newPosition;
            lastBg = col.gameObject.transform;
        }
    }

}
