using UnityEngine;
using System.Collections;

public class ParallaxBG : MonoBehaviour {

    float lastCameraX;
    float currentCameraX;

    [SerializeField]
    float parallaxSpeed = 3f;

    Transform cam; 

	// Use this for initialization
	void Start () {
        cam = Camera.main.transform;
        lastCameraX = cam.position.x;
        currentCameraX = lastCameraX;
	}
	
	// Update is called once per frame
	void Update () {
        currentCameraX = cam.position.x;
        float delta = currentCameraX - lastCameraX;
        if(Mathf.Abs(delta) > 0)
        {
            Vector3 newPosition = new Vector3(transform.position.x - delta, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * parallaxSpeed);

            lastCameraX = currentCameraX;
        }

	}
}
