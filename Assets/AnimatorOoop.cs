using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOoop : MonoBehaviour
{
    [SerializeField] bool isPlaying;
    [SerializeField] bool isLooping;
    [SerializeField] float playbackSpeed;
    [SerializeField] float playbackTime;
    [SerializeField] AnimClip clip;
    [SerializeField] EasingType easingType;
    int currentPosKey;
    int currentRotKey;
    int currentScaleKey;
    int change;

    // Start is called before the first frame update
    void Start()
    {
        playbackTime = 0;
        change = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            playbackTime += playbackSpeed * Time.deltaTime;
           
            if (playbackTime >= clip.duration)
            {
                if (isLooping)
                {
                    playbackTime = playbackTime + Time.deltaTime - clip.duration; 
                }
                else
                {
                    playbackTime = clip.duration;
                }
            }

        }
    }



}

struct AnimClip
{
    public float duration;
    public Vec3Key[] positionKeys;
    public Vec3Key[] rotationKeys;
    public Vec3Key[] scaleKeys;

}

struct Vec3Key
{
    public float time;
    public Vector3 value;
}

enum EasingType
{
    NONE,
    OUT_ELASTIC,
    IN_OUT_BACK,
    IN_EXPO
}
