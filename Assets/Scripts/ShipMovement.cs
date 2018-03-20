using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    Vector2 MovementArea;

    Camera Camera;

	// Use this for initialization
	void Start ()
    {
        Camera = FindObjectOfType<Camera>();
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, MovementArea * 2f);
    }

    // Update is called once per frame
    void Update ()
    {
        // check current mouse position and convert that point from screen to 3d world
        var targetPosition = (Vector2)Camera.ScreenToWorldPoint(Input.mousePosition);

        // setting boundaries of the scene
        targetPosition.x = Mathf.Clamp(targetPosition.x, -MovementArea.x, MovementArea.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -MovementArea.y, MovementArea.y);


        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);
	}
}
