using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{
    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;


	// overrride CheckDistance()
	public override void CheckDistance()
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

				// ChangeState(EnemyState.walk);
				anim.SetBool("wakeUp", true);
			}
		}
		else if (Vector3.Distance(target.position,
							 transform.position) > chaseRadius)
		{
            if (Vector3.Distance(transform.position,
                path[currentPoint].position) > roundingDistance)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position,
                                                   path[currentPoint].position,
                                                   moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidBody.MovePosition(temp);
            } else
            {
                ChangeGoal();
            }

		}
	}


    private void ChangeGoal()
	{
        if(currentPoint == path.Length -1)
		{
            // reset everything
            currentPoint = 0;
            currentGoal = path[0];
		} else
		{
            currentPoint++;
            currentGoal = path[currentPoint];
		}
	}

}
