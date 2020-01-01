using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{

    public Rigidbody2D myRigidBody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       
        currentState = EnemyState.idle;
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform; // holds scale rotation, position
		anim.SetBool("wakeUp", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();   
    }

   // can be overwritten 
   public virtual void CheckDistance()
    {
        if (Vector3.Distance(target.position,
                             transform.position) <= chaseRadius
            && Vector3.Distance(target.position,
                                transform.position) > attackRadius)

        { 

            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                // the physics system should do this.
                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                   target.position,
                                                   moveSpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
            
                ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if(Vector3.Distance(target.position,
                             transform.position) > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }


    private void SetAnimFloat(Vector2 vec)
    {
        anim.SetFloat("moveX", vec.x);
        anim.SetFloat("moveY", vec.y);
    }

    public void changeAnim(Vector2 dir)
    {
        if(Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            if(dir.x > 0)
            {
                SetAnimFloat(Vector2.right);
            } else if(dir.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        } else if(Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
        {
            if (dir.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (dir.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
