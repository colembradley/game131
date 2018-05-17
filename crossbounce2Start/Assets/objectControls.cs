using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectControls : MonoBehaviour {

	public float bounciness = 0.9f;

	public void UpdateBounciness(){
		try{
			GetComponent<BoxCollider2D> ().sharedMaterial.bounciness = bounciness;
		}
		catch(MissingComponentException e){
			Debug.Log ("The selected object is not a bouncy object");
		}
	}

    public void Move(Vector3 moveby)
    {
        transform.position += moveby;
    }

	public void Rotate(float angle)
	{
		transform.rotation *= Quaternion.Euler (0f, 0f, angle);
		if (transform.GetChild (0) != null && transform.GetChild (0).name == "track") {
			transform.GetChild(0).rotation *= Quaternion.Euler (0f, 0f, -angle);
		}
	}

	public void Scale(Vector3 scale)
	{
		var child = transform.GetChild (0);
		child.parent = null;
		transform.localScale += scale;
		child.parent = transform;
	}
}
