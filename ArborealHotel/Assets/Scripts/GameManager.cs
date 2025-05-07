using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Construction mode")]
    [SerializeField] private LayerMask constructionZoneMask;
    [SerializeField] private LayerMask constructionMask;
    [SerializeField] private bool inConstruction = false;
    
    [Header("Object to place")]
    public GameObject currentObjectToPlace;

    [SerializeField] private GameObject[] _constructions;
    
    private Vector3 _mousePos;
    private Ray _ray;
    private RaycastHit _hit;
    private Camera _cam;
    
    private void Start()
    {
        _cam = Camera.main;
    }
    void Update()
    {
        _mousePos = Input.mousePosition;
        _mousePos.z = 1000f; 
        _mousePos = _cam.ScreenToWorldPoint(_mousePos);
        
        _ray = _cam.ScreenPointToRay(Input.mousePosition);
        
        ConstructionMode();
        ManageDestruction();
    }

    private void ConstructionMode()
    {
        if (inConstruction)
        {
            //Deactivate construction mode
            if (Input.GetMouseButtonDown(1))
            {
                inConstruction = false;
                Destroy(currentObjectToPlace);
            }

            if (Physics.Raycast(_ray, out _hit, 100,constructionZoneMask))
            {
                currentObjectToPlace.SetActive(true);
                currentObjectToPlace.transform.position = _hit.point;

                if (Input.GetMouseButtonDown(0))
                {
                    inConstruction = false;
                    currentObjectToPlace = null;
                }
            }
            else
            {
                currentObjectToPlace.SetActive(false);
            }
        }
    }

    public void SetConstructionMode(int index)
    {
        if(currentObjectToPlace != null) return;
        
        inConstruction = true;
        
        //Object selection
        currentObjectToPlace = Instantiate(_constructions[index]);
        currentObjectToPlace.gameObject.SetActive(false);
    }

    private void ManageDestruction()
    {
        if (Physics.Raycast(_ray, out _hit, 100,constructionMask))
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(_hit.transform.parent.gameObject);
            }
        }
    }
}
