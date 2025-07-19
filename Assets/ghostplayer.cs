using UnityEngine;
using System.Collections.Generic;

public class GhostPlayerSync : MonoBehaviour
{
    public Transform realPlayer;
    public float delay = 0.2f;
    public float smoothTime = 0.1f;

    private Queue<FrameData> buffer = new Queue<FrameData>();
    private Vector3 velocity;

    void Update()
    {
        
        buffer.Enqueue(new FrameData
        {
            time = Time.time,
            position = realPlayer.position
        });

   
        while (buffer.Count > 0 && Time.time - buffer.Peek().time >= delay)
        {
            FrameData frame = buffer.Dequeue();
            transform.position = Vector3.SmoothDamp(transform.position, frame.position, ref velocity, smoothTime);
        }
    }

    struct FrameData
    {
        public float time;
        public Vector3 position;
    }
}