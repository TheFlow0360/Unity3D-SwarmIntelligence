using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwarmManager : MonoBehaviour
{
    private List<SwarmElement> elements = new List<SwarmElement>();

    void Start () {

	}
	
	void Update () {
	    foreach (var element1 in elements)
	    {
            Vector3 movement = Vector3.zero;
	        foreach (var element2 in elements)
	        {
	            if (element1 == element2)
	            {
	                continue;
	            }
	            movement += element1.GetTargetMovement(element2.GetPos());
	        }
	        element1.ApplyMovement(movement);
	    }
    }

    public void RegisterElement(SwarmElement swarmElement)
    {
        elements.Add(swarmElement);
    }

    public void UnregisterElement(SwarmElement swarmElement)
    {
        elements.Remove(swarmElement);
    }
}
