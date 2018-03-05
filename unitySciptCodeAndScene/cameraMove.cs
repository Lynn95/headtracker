using UnityEngine;
using System.IO.Ports;

public class cameraMove : MonoBehaviour
{
    //Setup parameters to connect to Arduino
    public static SerialPort sp = new SerialPort("COM3", 115200, Parity.None, 8, StopBits.One);

    public static string strIn;

    //transform  attribute of camera
    private Transform headTracker;

    // Use this for initialization
    void Start()
    {
        print("start the open connection");
        OpenConnection();
        headTracker = Camera.main.transform;
    }

    void Update()
    {
        //Read incoming data
        strIn = sp.ReadLine();
        string[] array = strIn.Split(',');
        float yaw = System.Convert.ToSingle(array[0]);
        float pitch = System.Convert.ToSingle(array[1]);
        float roll = System.Convert.ToSingle(array[2]);
        float accuracy = System.Convert.ToSingle(0.1);
        print(strIn);
        headTracker.rotation = new Quaternion(0,yaw, pitch * accuracy, roll);


    }

    //Function connecting to Arduino
    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();

            }
            else
            {
                sp.Open();  // opens the connection
                sp.ReadTimeout = 50;  // sets the timeout value before reporting error

            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    void OnApplicationQuit()
    {
        sp.Close();
    }
}