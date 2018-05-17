using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track : MonoBehaviour {

    public bool useTrack = false;
    public float moveSpeed = 1.0f;
	public float position = 0.5f;
	public bool moveBackwards = false;
	public bool started = false;

    public Transform startPoint;
    public Transform endPoint;

	void Start(){
		started = true;
        transform.parent.GetComponent<MoveBetweenTwoPoints>().enabled = useTrack;
        MoveBackwards();
	}

    public void Move(Vector3 moveby)
    {
		transform.parent.position += moveby;
    }

    public void Scale(Vector3 scale)
    {
        transform.localScale += scale;
    }

	public void UpdateSpeed()
	{
		transform.parent.GetComponent<MoveBetweenTwoPoints> ().speed = moveSpeed;
	}

	public void TuneObstaclePos()
	{
        if (!started)
        {
            Vector3 dir = endPoint.position - startPoint.position;
            //dir.Normalize();
            Vector3 startPointPos = startPoint.transform.position;
            transform.parent.position = startPointPos + (position * dir);
            transform.position = transform.parent.position + (-position * dir);
        }
	}

	public void MoveBackwards()
	{
		transform.parent.GetComponent<MoveBetweenTwoPoints> ().isMovingToStart = moveBackwards;
	}

	void OnDrawGizmosSelected(){
		if (useTrack) {
			Gizmos.color = Color.green;
			Gizmos.DrawSphere (startPoint.position, 0.1f);
			Gizmos.DrawSphere (endPoint.position, 0.1f);
			Gizmos.color = Color.white;
			Gizmos.DrawLine (startPoint.position, endPoint.position);
		}
	}

}
