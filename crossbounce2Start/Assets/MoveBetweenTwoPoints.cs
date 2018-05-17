using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTwoPoints : MonoBehaviour {

	public Transform startPosition;
	public Transform endPosition;
    [HideInInspector]
    public bool isMovingToStart;
	[HideInInspector]
    public float speed = 4.0f;
	private bool started = false;

	void Start(){
		started = true;
	}

	void Update () {
        float moveMagnitude = speed * Time.deltaTime;
        if (startPosition != endPosition)
        {
            while (moveMagnitude > 0)
            {
                moveMagnitude = ResolveMovement(moveMagnitude);
            }
        }
    }

    public float ResolveMovement(float moveMagnitude)
    {
		Vector3 currentTarget = isMovingToStart ? startPosition.position : endPosition.position;
        Vector3 toCurrentTarget = currentTarget - transform.position;
        float targetDelta = Vector3.Distance(currentTarget, transform.position);
        if (moveMagnitude < targetDelta)
        {
            transform.position += toCurrentTarget.normalized * moveMagnitude;
			transform.GetChild(0).position -= toCurrentTarget.normalized * moveMagnitude;
            return 0;
        }
        else
        {
            isMovingToStart = !isMovingToStart;
            return moveMagnitude - toCurrentTarget.magnitude;
        }
    }

}
