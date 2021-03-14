using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarBehaviour : MonoBehaviour
{
    class WheelInfo
    {
        public WheelCollider collider;
        public WheelBehaviour behaviour;

        public WheelInfo(WheelCollider _collider, WheelBehaviour _behaviour)
        {
            collider = _collider;
            behaviour = _behaviour;
        }
    }

    const string horizontalInput = "Horizontal";
    const string verticalInput = "Vertical";

    [SerializeField] float m_maxTorque = 1;
    [SerializeField] float m_maxSteering = 1;

    SubscriberList m_subscriberList = new SubscriberList();

    Rigidbody m_rigidbody = null;
    List<WheelInfo> m_wheels = new List<WheelInfo>();
    Transform m_cameraPos;

    private void Awake()
    {
        m_subscriberList.Subscribe();

        m_rigidbody = GetComponent<Rigidbody>();
        var wheels = GetComponentsInChildren<WheelBehaviour>();
        foreach (var w in wheels)
        {
            var collider = w.GetComponent<WheelCollider>();
            if (collider != null)
                m_wheels.Add(new WheelInfo(collider, w));
        }
        m_cameraPos = transform.Find("Camera");
    }

    private void Start()
    {
        Event<CameraMoveInstantEvent>.Broadcast(new CameraMoveInstantEvent(transform.position, m_cameraPos.forward, m_cameraPos.up, m_cameraPos.position, Vector3.zero));
    }

    private void OnDestroy()
    {
        m_subscriberList.Unsubscribe();
    }

    private void FixedUpdate()
    {
        float motor = m_maxTorque * Input.GetAxis(verticalInput);
        float steering = m_maxSteering * Input.GetAxis(horizontalInput);

        foreach (var wheel in m_wheels)
        {
            if (wheel.behaviour.haveMotor)
                wheel.collider.motorTorque = motor;
            if (wheel.behaviour.haveSteering)
                wheel.collider.steerAngle = steering;
        }

        Event<CameraMoveEvent>.Broadcast(new CameraMoveEvent(transform.position, m_cameraPos.forward, m_cameraPos.up, m_cameraPos.position, m_rigidbody.velocity));
    }

    private void OnGUI()
    {
        float speed = m_rigidbody.velocity.magnitude * 3.6f; // to km/h

        GUI.Label(new Rect(10, 10, 100, 20), speed + " km/h");
    }
}
