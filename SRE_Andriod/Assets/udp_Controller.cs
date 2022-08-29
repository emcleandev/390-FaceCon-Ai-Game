using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class udp_Controller : MonoBehaviour {

    // 1. Declare Variables

    Thread receiveThread; //1
    static UdpClient client; //2
    int port; //3
    public Manger manager;
    public GameObject Player; //4
    AudioSource jumpSound; //5
    bool jump = false; //6
    bool rested = true;

    bool leapUp = false;
    bool leapDown = false;
    bool runForward = false;
    bool runBackward = false;

    Victim_Movement playercon;


    void Start () {
       
        port = 5065; //1 
        jump = false; //2 

        playercon =  Player.GetComponent<Victim_Movement>();

        InitUDP(); //4
        

    }

    private void InitUDP()
    {
        print("UDP Initialized");
        receiveThread = new Thread(new ThreadStart(ReceiveData)); //1 
        receiveThread.IsBackground = true; //2
        receiveThread.Start(); //3
    }


    private void ReceiveData()
    {
        if (client == null)
        {
            client = new UdpClient(port); //1
        }
        while (true) //2
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), port); //3
                byte[] data = client.Receive(ref anyIP); //4

                string text = Encoding.UTF8.GetString(data); //5
                print(">> " + text);

                // depending on text
                if (text.Contains("JUMP!"))
                {
                    print("JUMP BABY JUMP");
                
                    jump = true;
                }
                
                else if (text.Contains("LEAPUP!"))
                {
                    leapUp = true;
                    print("LEAP UP TRIGGER");

                }
                else if (text.Contains("LEAPDOWN!"))
                {
                    leapDown = true;
                    print("LEAP DOWN TRIGGER");

                }

                else if (text.Contains("FORWARD!"))
                {
                    runForward = true;
                    print("LEAP UP TRIGGER");

                }
                else if (text.Contains("BACKWARD!"))
                {
                    runBackward = true;
                    print("LEAP DOWN TRIGGER");

                }

            }
            catch (Exception e)
            {
                print(e.ToString()); //7
            }
        }
    }


    // Update is called once per frame
    void FixedUpdate () {

        if (jump == true)
        {
            //manager.run_Pause();
            playercon.Jump();
            jump = false;
            leapDown = false;
            leapUp = false;
        }

        else if (true)
        {
            if (leapUp)
            {
                print("leap  up");
                playercon.Leap_Up();
                jump = false;
                leapDown = false;
                leapUp = false;
            }
            else if (leapDown)
            {
                print("leap down action");
                playercon.Leap_Down();
                jump = false;
                leapDown = false;
                leapUp = false;
            }
            else if (runForward) {
                print("run forward");
                playercon.runForward();

                runForward = false;
                jump = false;
                leapDown = false;
                leapUp = false;

            }

            else if (runBackward)
            {
                print("run backwards");
                playercon.runBackward();
                runBackward = false;
                jump = false;
                leapDown = false;
                leapUp = false;

            }

        }
	}

    void OnApplicationQuit()
    {
        try {
            receiveThread.Abort();
            client.Close();
        }
        catch(Exception e) { try { client.Close(); } catch (Exception ex) { } }
        
    }
}
