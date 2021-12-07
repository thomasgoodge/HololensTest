using UnityEngine;

public class Collisions : MonoBehaviour
{
    //Initiliase the audio clips for when objects collide
    [SerializeField] private AudioClip Pop;
    [SerializeField] private AudioClip Blop;
    [SerializeField] private AudioClip Clink;
    [SerializeField] private string sphereType;
    private AudioSource audiosource;


    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //Register collisions depending on the tags for the objects.
        //Play audio clip for each type of sphere. (AtPoint instead of OneShot because there are multiple different types of audio clips to play)
        if (collisionInfo.collider.tag == "Player" & sphereType == "Enemy")
        {
            ScoreManager.instance.SubtractPoint();
            AudioSource.PlayClipAtPoint(Pop, transform.position, 0.5f);
            Destroy(this.gameObject);
        }
        else if (collisionInfo.collider.tag == "Player" & sphereType == "Target Sphere")
        {
            ScoreManager.instance.AddPoint();
            AudioSource.PlayClipAtPoint(Blop, transform.position, 0.5f);
            Destroy(this.gameObject);
            //Debug.Log("Hit!");
        }

        else if (collisionInfo.collider.tag == "Player" & sphereType == "Hazard Sphere")
        {
            ScoreManager.instance.HazardPoint();
            AudioSource.PlayClipAtPoint(Clink, transform.position, 0.5f);
            Destroy(this.gameObject);
            //Debug.Log("Hit!");
        }
        // If the object hits the Wall object, destroy it
        else if (collisionInfo.collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
            
    }
}
