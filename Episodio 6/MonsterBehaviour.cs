using UnityEngine;
using System.Collections;

public class MonsterBehaviour : MonoBehaviour {

    GameObject player;
    Animator anim;
    Vector3 target;

    [SerializeField]
    float attackDelay = 3f;
    [SerializeField]
    float monsterSpeed = 3f;

    float timePassedSinceLast = 0f;
    bool isAttacking = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Giocatore");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        WaitForAttack();
        Movement();
	}

    void WaitForAttack()
    {
        if (!isAttacking)
        {
            timePassedSinceLast += Time.deltaTime;
            if(timePassedSinceLast > attackDelay)
            {
                target = player.transform.position;
                timePassedSinceLast = 0f;
                Attack();
            }
        }
    }

    void Attack()
    {
        var dir = target - transform.position;
        anim.SetBool("Attack", true);
        anim.applyRootMotion = true;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg));
        isAttacking = true;
    }

    void Movement()
    {
        if (isAttacking)
        {
            transform.position += transform.up * Time.deltaTime * monsterSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
