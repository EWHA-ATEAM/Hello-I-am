using System;

[Serializable]
public struct SendPacket
{
    public byte[] imgByte;
}


[Serializable]
public struct ReceivePacket
{
    public int motion;
}