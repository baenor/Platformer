using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    float delayBetweenShots = 0.4f;

    float timePassedSinceLast = 0f; 

	// Use this for initialization
	void Start () {
        timePassedSinceLast = delayBetweenShots; 
	}
	
	// Update is called once per frame
	void Update () {
        Aiming();
        Shooting();
	}

    void Aiming()
    {
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - objectPos;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg));
    }

    void Shooting()
    {
        if(Input.GetMouseButton(0) && timePassedSinceLast >= delayBetweenShots)
        {
            GameObject dagger = (GameObject)Instantiate(Resources.Load("dagger"), transform.position, transform.rotation);
            timePassedSinceLast = 0f;
        }
        else
        {
            timePassedSinceLast += Time.deltaTime;
        }
        
    }
}
