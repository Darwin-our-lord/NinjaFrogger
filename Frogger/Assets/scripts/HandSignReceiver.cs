// HandSignReceiver.cs - WITH DEBUG OUTPUT
//
// Listens for UDP packets from python_bridge/predict_server.py on
// 127.0.0.1:5065 and exposes the latest detected hand sign to the rest of
// your Unity game.

using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class HandSignReceiver : MonoBehaviour
{
    [Tooltip("Must match UNITY_PORT in predict_server.py")]
    public int listenPort = 5065;

    public string CurrentSign { get; private set; } = "";
    public float CurrentConfidence { get; private set; } = 0f;

    public event Action<string, float> OnSignChanged;

    private UdpClient _udpClient;
    private Thread _receiveThread;
    private readonly ConcurrentQueue<(string sign, float confidence)> _incoming = new();
    private volatile bool _running;
    private int _packetCount = 0;

    private void Start()
    {
        try
        {
            _udpClient = new UdpClient(listenPort);
            _running = true;
            _receiveThread = new Thread(ReceiveLoop) { IsBackground = true };
            _receiveThread.Start();
            Debug.Log($"[HandSignReceiver] Listening for hand signs on UDP port {listenPort}");
        }
        catch (Exception e)
        {
            Debug.LogError($"[HandSignReceiver] Failed to bind to port {listenPort}: {e.Message}");
        }
    }

    private void ReceiveLoop()
    {
        var endpoint = new IPEndPoint(IPAddress.Any, listenPort);
        while (_running)
        {
            try
            {
                byte[] data = _udpClient.Receive(ref endpoint);
                string json = System.Text.Encoding.UTF8.GetString(data);
                Debug.Log($"[HandSignReceiver] Received UDP packet: {json}");
                var parsed = JsonUtility.FromJson<SignPacket>(json);
                if (parsed != null && !string.IsNullOrEmpty(parsed.sign))
                {
                    _incoming.Enqueue((parsed.sign, parsed.confidence));
                    _packetCount++;
                }
            }
            catch (SocketException)
            {
                break;
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[HandSignReceiver] Failed to parse packet: {e.Message}");
            }
        }
    }

    private void Update()
    {
        // Only process the LATEST incoming packet, not the whole queue.
        (string sign, float confidence) latest = ("", 0);
        bool hasNew = false;

        while (_incoming.TryDequeue(out var item))
        {
            latest = item;
            hasNew = true;
        }

        if (hasNew)
        {
            Debug.Log($"[HandSignReceiver] Processing packet: sign='{latest.sign}', confidence={latest.confidence}");
            if (latest.sign != CurrentSign)
            {
                CurrentSign = latest.sign;
                CurrentConfidence = latest.confidence;
                Debug.Log($"[HandSignReceiver] Sign changed to '{CurrentSign}'");
                OnSignChanged?.Invoke(CurrentSign, CurrentConfidence);
            }
            else
            {
                CurrentConfidence = latest.confidence;
            }
        }
    }

    private void OnGUI()
    {
        // Draw debug info on screen
        GUILayout.BeginArea(new Rect(10, 10, 300, 100));
        GUILayout.Label($"Port: {listenPort}");
        GUILayout.Label($"Packets received: {_packetCount}");
        GUILayout.Label($"Current sign: {CurrentSign} ({CurrentConfidence:F2})");
        GUILayout.EndArea();
    }

    private void OnDestroy()
    {
        _running = false;
        _udpClient?.Close();
        _receiveThread?.Join(200);
    }

    [Serializable]
    private class SignPacket
    {
        public string sign;
        public float confidence;
    }
}