using UnityEngine;

public class UnitController : MonoBehaviour
{
    [SerializeField] private LayerMask rayLayers;
    private UnitMove selectedUnit;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CastRay();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SendUnit();
        }
    }

    private void CastRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, rayLayers))
        {
            if (hit.transform.TryGetComponent(out UnitMove unitMove))
            {
                selectedUnit = unitMove;
            }
        }
    }

    private void SendUnit()
    {
        if (selectedUnit == null) { return; }

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, rayLayers))
        {
            selectedUnit.SetPoint(hit.point);
        }    
    }
}
