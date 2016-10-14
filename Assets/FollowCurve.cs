using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FollowCurve : MonoBehaviour {

    public BezierCurve bezier;
    [Range(0,1)]
    public float t = 0;
    public float velocity = 5f;
    public float lerp = 2f; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -.1f)
        {
            //if(t > 0.2 || t < 0.8)
            //    t += Input.GetAxis("Vertical") * (velocity/ bezier.length ) * Time.deltaTime;
            //else 
                t += Mathf.Sign(Input.GetAxis("Vertical")) * (velocity/ bezier.length ) * Time.deltaTime; 
        }

        t = Mathf.Clamp(t, 0.01f, 0.99f); 
        transform.position = bezier.GetPointAt(t);

        float _lookAt = Mathf.Clamp(t + (0.1f * Mathf.Sign(Input.GetAxis("Vertical"))), 0f, 1f);
        //float _lookAt = Mathf.Lerp(t, Mathf.Clamp(t + (0.1f * Mathf.Sign(Input.GetAxis("Vertical"))), 0f, 1f), lerp * Time.deltaTime);


        //Debug.Log(_lookAt); 
        if (Input.GetAxis("Vertical") > 0.1 || Input.GetAxis("Vertical") < -.1f)
        {
            transform.LookAt(bezier.GetPointAt(_lookAt));
        }
	}
}
