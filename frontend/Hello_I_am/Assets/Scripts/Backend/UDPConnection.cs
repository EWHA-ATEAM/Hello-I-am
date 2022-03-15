using System;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

public class UDPConnection : MonoBehaviour
{
    private string _receiverIp = "아이피주소";
    private int _port = 50001;  // 포트 번호
    private IPEndPoint _ipEndPoint;
    private Socket _socket;

    private SendPacket _sendPacket = new SendPacket();
    private ReceivePacket _receivePacket = new ReceivePacket();

    public bool isConnected { get; private set; }

    private byte[] _sendPacketBytes;

    private void OnEnable()
    {
        InitSocket();

        if (isConnected)
            ConnectServer();
    }

    private void Update()
    {
        // 연결 안 됐을 경우 계속해서 접속 시도
        if (!isConnected)
            ConnectServer();

        else // 연결 된 경우 보내고 받음
        {
            Send();
            Receive();
        }
    }

    private void OnDisable()
    {
        _socket.Close();
        _socket = null;
    }

    private void InitSocket()
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress ipAddress = IPAddress.Parse(_receiverIp);
        _ipEndPoint = new IPEndPoint(ipAddress, _port);
    }

    private void ConnectServer()
    {
        try
        {
            _socket.Connect(_ipEndPoint);
            isConnected = true;
        }

        catch (SocketException ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private void setPacketData(byte[] data)
    {
        _sendPacket.imgByte = new byte[data.Length];
        _sendPacket.imgByte = data;
    }   

    private void Send()
    {
        try
        {
            // 아래 data값 관련해서 수정 필요
            // 다른 스크립트에서 함수 불러오는 등의 처리
            //setPacketData(data);
            byte[] sendPacket = StructToByteArray(_sendPacket);
            _socket.Send(sendPacket);
        }
        catch (SocketException ex)
        {
            Debug.Log(ex.Message);
        }
    }

    void Receive()
    {
        int receive = 0;

        try
        {
            byte[] receivedbytes = new byte[512];
            receive = _socket.Receive(receivedbytes);

            _receivePacket = ByteArrayToStruct<ReceivePacket>(receivedbytes);
        }

        catch (Exception ex)
        {
            Debug.Log(ex);
            return;
        }

        if (receive > 0)
        {
            Debug.Log("모션 판단 결과:"+_receivePacket.motion); // 받은 값 처리
        }
    }

    /* packet 직렬화,역직렬화 함수 */

    byte[] StructToByteArray(object obj)
    {
        int size = Marshal.SizeOf(obj);
        byte[] arr = new byte[size];
        IntPtr ptr = Marshal.AllocHGlobal(size);

        Marshal.StructureToPtr(obj, ptr, true);
        Marshal.Copy(ptr, arr, 0, size);
        Marshal.FreeHGlobal(ptr);
        return arr;
    }
    T ByteArrayToStruct<T>(byte[] buffer) where T : struct
    {
        int size = Marshal.SizeOf(typeof(T));
        if (size > buffer.Length)
        {
            throw new Exception();
        }

        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.Copy(buffer, 0, ptr, size);
        T obj = (T)Marshal.PtrToStructure(ptr, typeof(T));
        Marshal.FreeHGlobal(ptr);
        return obj;
    }
}
