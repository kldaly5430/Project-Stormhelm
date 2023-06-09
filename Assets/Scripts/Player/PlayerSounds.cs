using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    string stone = "Audio/Stone";
    string grass = "Audio/Grass";
    string mud = "Audio/Mud";
    string wood = "Audio/Wood";

    public List<AudioClip> stoneFootSteps = new List<AudioClip>();
    public List<AudioClip> grassFootSteps = new List<AudioClip>();
    public List<AudioClip> mudFootSteps = new List<AudioClip>();
    public List<AudioClip> woodFootSteps = new List<AudioClip>();

    private AudioSource audioSource;

    public AudioClip clip;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        var audio = Resources.LoadAll<AudioClip>(stone);
        foreach(var step in audio)
        {
            stoneFootSteps.Add(step);
        }
        audio = Resources.LoadAll<AudioClip>(grass);
        foreach(var step in audio)
        {
            grassFootSteps.Add(step);
        }
        audio = Resources.LoadAll<AudioClip>(mud);
        foreach(var step in audio)
        {
            mudFootSteps.Add(step);
        }
        audio = Resources.LoadAll<AudioClip>(wood);
        foreach(var step in audio)
        {
            woodFootSteps.Add(step);
        }
    }

    private void Step()
    { 
        audioSource.PlayOneShot(clip);
        
    }

    // private void OnCollisionEnter(Collision col) {
    //     var floortag = col.gameObject.tag;
    //     Debug.Log(floortag);
    //     if (floortag == "Stone")
    //     {
    //         int randomClip = Random.Range(0,(stoneFootSteps.Count-1));
    //         clip = stoneFootSteps[randomClip];
            
    //     }
    //     else if (floortag == "Grass")
    //     {
    //         int randomClip = Random.Range(0,(grassFootSteps.Count-1));
    //         clip = grassFootSteps[randomClip];
    //     }
    //     else if (floortag == "Mud")
    //     {
    //         int randomClip = Random.Range(0,(mudFootSteps.Count-1));
    //         clip = mudFootSteps[randomClip];
    //     }
    //     else if (floortag == "Wood")
    //     {
    //         int randomClip = Random.Range(0,(woodFootSteps.Count-1));
    //         clip = woodFootSteps[randomClip];
    //     }
    // }

    private void Update() {
        RaycastHit hit;

            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y+1,transform.position.z), transform.TransformDirection(Vector3.down), out hit))
            {
                var floortag = hit.collider.gameObject.tag;
                // Debug.Log(transform.position);
                if (floortag == "Stone")
                {
                    int randomClip = Random.Range(0,(stoneFootSteps.Count-1));
                    clip = stoneFootSteps[randomClip];
                    
                }
                else if (floortag == "Grass")
                {
                    int randomClip = Random.Range(0,(grassFootSteps.Count-1));
                    clip = grassFootSteps[randomClip];
                }
                else if (floortag == "Mud")
                {
                    int randomClip = Random.Range(0,(mudFootSteps.Count-1));
                    clip = mudFootSteps[randomClip];
                }
                else if (floortag == "Wood")
                {
                    int randomClip = Random.Range(0,(woodFootSteps.Count-1));
                    clip = woodFootSteps[randomClip];
                }
            }
    }
}
