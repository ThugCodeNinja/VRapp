using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

public class move : MonoBehaviour
{
    public float throttleIncrement = 5f;
    public  float maxthrotlle=300f;
    public float responsiveness=50f;
    public float lift = 150f;
    public GameObject objectToSpawn;
    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;
    public static int score=0;
    private float responseModifier{
        get {
            return (rb.mass/10f) * responsiveness;
        }
    }
     Rigidbody rb;
     AudioSource engineSound;
    [SerializeField] TextMeshProUGUI hud;

    private  void Start(){
     rb = GetComponent<Rigidbody>();
     engineSound = GetComponent<AudioSource>();
    }
    private void HandleIp(){
    roll=Input.GetAxis("Roll");
    pitch=Input.GetAxis("Pitch");
    yaw=Input.GetAxis("Yaw");
    // roll = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
    // pitch = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;
    // yaw = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;
    // throttle = Mathf.Clamp(throttle + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y * throttleIncrement, 0f, 100f);
    throttle = Mathf.Clamp(throttle,0f,100f);

    if(Input.GetKey(KeyCode.X) || OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.Three)){
            throttle -=throttleIncrement;
        }
    else if(Input.GetKey(KeyCode.Z) || OVRInput.Get(OVRInput.Button.Two) || OVRInput.Get(OVRInput.Button.Four)){
            throttle+=throttleIncrement;
        }
    throttle = Mathf.Clamp(throttle,0f,100f);
    }
    private void Update(){
        HandleIp();
        UpdateHUD();
        engineSound.volume=throttle * 0.01f;
    }
    private void FixedUpdate(){
        rb.AddForce(transform.forward * maxthrotlle *throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);
        rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);
    }
    private void UpdateHUD(){
        hud.text = "Score:" + score.ToString("F0")+"\n";
        hud.text += "Throttle:" + throttle.ToString("F0") +"\n";
        hud.text +="Airspeed:" + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
        hud.text +="Altitude:" + transform.position.y.ToString("F0") + " m";
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Sphere")
        {
            Debug.Log("Hit the balloon");
            score+= 100;
            Destroy(collision.gameObject);
        }
    }


}