using UnityEngine;
using System.Collections;

public class SwarmElement : MonoBehaviour
{
    private Rigidbody body;

    public float attractionFactor = 0.1f;
    public float repulsionFactor1 = 20;
    public float repulsionFactor2 = 15;

    void Start()
    {
        body = GetComponent<Rigidbody>();
	}

    void OnEnable()
    {
        var manager = GetComponentInParent<SwarmManager>();
        if (manager != null)
        {
            manager.RegisterElement(this);
        }
    }

    void OnDestroy()
    {
        var manager = GetComponentInParent<SwarmManager>();
        if (manager != null)
        {
            manager.UnregisterElement(this);
        }
    }
	
	void Update() {
	    
	}

    public Vector3 GetPos()
    {
        return body.position;
    }

    public Vector3 GetTargetMovement(Vector3 target)
    {
        var movement = target - body.position;
        movement *= attractionFactor - Mathf.Pow(repulsionFactor1, -Mathf.Pow(Vector3.Distance(target, body.position), 2) / repulsionFactor2);
        //movement *= attractionFactor - repulsionFactor1/Mathf.Pow(Vector3.Distance(body.position, target),2);
        return movement;
    }

    public void ApplyMovement(Vector3 movement)
    {
        body.velocity = movement;
    }
}
