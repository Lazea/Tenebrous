using UnityEngine;

public class DrillTool : MonoBehaviour
{
    [Header("Stats")]
    public float drillRange = 1f;
    public float drillRadius = 0.2f;
    public LayerMask mask;

    bool useDrill;

    GameObject objectDrilled;

    // Components
    Controls.GameplayActions controls;
    Animator anim;
    AnimatorStateInfo animStateInfo
    {
        get { return anim.GetCurrentAnimatorStateInfo(0); }
    }

    void Awake()
    {
        anim = GetComponentInParent<Animator>();

        controls = new Controls().Gameplay;

        controls.Action.started += ctx => useDrill = true;
        controls.Action.canceled += ctx => useDrill = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        useDrill = false;
        anim.SetBool("Drilling", false);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Drilling", useDrill);
    }

    private void FixedUpdate()
    {
        GameObject _objectDrilled = null;
        if (animStateInfo.IsName("Drilling"))
        {
            Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward);
            RaycastHit hit;
            if(Physics.SphereCast(
                ray,
                drillRadius,
                out hit,
                drillRange,
                mask))
            {
                _objectDrilled = hit.collider.gameObject;
                // TODO: Play a drill particle effect based on object hit
            }
        }

        objectDrilled = _objectDrilled;
    }

    public void Drill()
    {
        if (objectDrilled == null)
            return;

        // TODO: Perform a drill action as in damage enemies or mine mineral based on objectDrilled
        Debug.Log("Drill");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 startPoint = Camera.main.transform.position;
        Vector3 endPoint = Camera.main.transform.forward * drillRange;
        endPoint += startPoint;
        Gizmos.DrawLine(startPoint, endPoint);
        Gizmos.DrawWireSphere(endPoint, drillRadius);
    }
}