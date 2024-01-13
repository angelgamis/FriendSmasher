using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera mainCam;

    [Header("Mouse")]
    private bool mouseIsDown;
    private Vector3 mouseWorldPosition;

    [Header("Player")]
    private Vector3 playerPosition;

    // Update is called once per frame
    void Update()
    {
        // While the mouse is being held down on player move the player to the mouse
        if(mouseIsDown)
        {
			Vector3 mouseWorldPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;
            transform.position = mouseWorldPosition;
		}
	}

    // Check when mouse is down and cache to mouseIsDown
	private void OnMouseDown()
	{
        mouseIsDown = true;
    }
    private void OnMouseUp()
    {
        mouseIsDown = false;
    }
}
