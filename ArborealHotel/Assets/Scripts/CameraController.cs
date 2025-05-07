using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 moveDir;
    [Range(1,5)]
    [SerializeField] private float moveSpeed;

    [SerializeField] private float mouseSensitivityX = 100f;
    
    [Header("Key Bindings")]
    [SerializeField] private KeyCode forward;
    [SerializeField] private KeyCode backward;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode down;
    [SerializeField] private KeyCode cursorOn;
   
    [SerializeField] private Transform tr;
    [SerializeField] private Rigidbody _rb;
    
    private float xRotation = 0f;
    private bool cursorModeOn = true;

    void Update()
    {
        if (Input.GetKeyDown(cursorOn))
        {
            if (cursorModeOn)
            {
                Cursor.lockState = CursorLockMode.Locked;
                cursorModeOn = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                cursorModeOn = true;
            }

            moveDir = new Vector3(0, 0, 0);
        }

        if(cursorModeOn) return;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        tr.Rotate(Vector3.up * mouseX);
        
        if (Input.GetKeyDown(forward))
        {
            moveDir += new Vector3(0, 0, 1);
            Debug.Log("Forward");
        }
        if (Input.GetKeyUp(forward))
        {
            moveDir += new Vector3(0, 0, -1);
        }
        
        if (Input.GetKeyDown(backward))
        {
            moveDir += new Vector3(0, 0, -1);
            Debug.Log("Backward");
        }
        if (Input.GetKeyUp(backward))
        {
            moveDir += new Vector3(0, 0, 1);
        }
        
        if (Input.GetKeyDown(left))
        {
            moveDir += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyUp(left))
        {
            moveDir += new Vector3(1, 0, 0);
        }
        
        if (Input.GetKeyDown(right))
        {
            moveDir += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyUp(right))
        {
            moveDir += new Vector3(-1, 0, 0);
        }
        
        if (Input.GetKeyDown(up))
        {
            moveDir += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyUp(up))
        {
            moveDir += new Vector3(0, -1, 0);
        }
        
        if (Input.GetKeyDown(down))
        {
            moveDir += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyUp(down))
        {
            moveDir += new Vector3(0, 1, 0);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddRelativeForce(moveDir * moveSpeed,ForceMode.Impulse);
    }
}
