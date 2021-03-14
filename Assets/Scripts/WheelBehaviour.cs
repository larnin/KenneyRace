using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WheelBehaviour : MonoBehaviour
{
    [SerializeField] bool m_haveMotor;
    public bool haveMotor { get { return m_haveMotor; } }

    [SerializeField] bool m_haveSteering;
    public bool haveSteering { get { return m_haveSteering; } }

    GameObject m_renderer;

    WheelCollider m_collider;

    private void Start()
    {
        var renderers = GetComponentsInChildren<Renderer>();
        foreach(var r in renderers)
        {
            if (r.gameObject == gameObject)
                continue;
            m_renderer = r.gameObject;
        }
        m_collider = GetComponent<WheelCollider>();
    }

    void FixedUpdate()
    {
        Vector3 position;
        Quaternion rotation;

        m_collider.GetWorldPose(out position, out rotation);


        m_renderer.transform.position = position;
        m_renderer.transform.rotation = rotation;
    }
}
