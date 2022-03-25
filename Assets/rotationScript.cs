using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotationScript : MonoBehaviour
{
    public Transform gameBoard;

    private ControlSystem controlSysyem;
    private void Awake()
    {
        controlSysyem = new ControlSystem();
    }

    // Start is called before the first frame update
    void Start()
    {
        InputSystem.EnableDevice(UnityEngine.InputSystem.Gyroscope.current);
    }

    // Update is called once per frame
    void Update()
    {
        gameBoard.transform.Rotate(-Input.gyro.rotationRateUnbiased.x, 0, 0);
        gameBoard.transform.Rotate(0, 0, -Input.gyro.rotationRateUnbiased.y);
        //Debug.Log(controlSysyem.Player.Rotate.ReadValueAsObject().ToString());
    }
}
