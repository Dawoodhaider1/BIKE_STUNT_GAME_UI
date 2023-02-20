using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BodyTrigger : MonoBehaviour
{
    public static bool finish = false;

    //used to play sounds
    public AudioClip bonesCrackSound;
    public AudioClip hitSound;
    public AudioClip oohCrowdSound;

    private AudioSource bonesCrackSC;
    private AudioSource hitSC;
    private AudioSource oohCrowdSC;

    //used to show text when entered in finish
    private Text winText;
    private Text crashText;

    //used to know if next level exists.
    private bool nextLevel = false;

    //Panels
    public GameObject Finish_Panel;
    public GameObject Loose_Panel;

    //Audio sources
    public AudioSource Loose_Sound;
    public AudioSource Win_Sound;


    void Start()
    {
        finish = false;

        //ignoring collision between biker's bodytrigger and motorcycle body
        Physics.IgnoreCollision(this.GetComponent<Collider>(), transform.parent.GetComponent<Collider>());

        //add new audio sources and add audio clips to them, used to play sounds
        bonesCrackSC = gameObject.AddComponent<AudioSource>();
        hitSC = gameObject.AddComponent<AudioSource>();
        oohCrowdSC = gameObject.AddComponent<AudioSource>();

        bonesCrackSC.playOnAwake = false;
        hitSC.playOnAwake = false;
        oohCrowdSC.playOnAwake = false;

        bonesCrackSC.rolloffMode = AudioRolloffMode.Linear;
        hitSC.rolloffMode = AudioRolloffMode.Linear;
        oohCrowdSC.rolloffMode = AudioRolloffMode.Linear;

        bonesCrackSC.clip = bonesCrackSound;
        hitSC.clip = hitSound;
        oohCrowdSC.clip = oohCrowdSound;
        //--------------------------------------------------
    }

    IEnumerator Wait_FinishPanel()
    {
        yield return new WaitForSeconds(2f);
        Motorcycle_Controller.score = 0;
        Finish_Panel.SetActive(true);
        Win_Sound.Play();
        MainManager.Instance.Coins = MainManager.Instance.Coins + Motorcycle_Controller.Total;
    }

    IEnumerator Wait_LoosePanel()
    {
        yield return new WaitForSeconds(3f);
        Motorcycle_Controller.score = 0;
        Loose_Panel.SetActive(true);
        Loose_Sound.Play();
    }

    void OnTriggerEnter(Collider obj)
    {

        if (obj.gameObject.tag == "Finish" && !Motorcycle_Controller.crash)//if entered in finish trigger
        {
            StartCoroutine(Wait_FinishPanel());
            Debug.Log("waiting for 2 seconds");
            finish = true;

            Motorcycle_Controller.isControllable = false; //disable motorcycle controlling

            //disable rear wheel rotation
            for(int i =0; i < 5; i++)
            {
                var m = transform.root.GetChild(i).GetComponent<Motorcycle_Controller>();
                m.rearWheel.freezeRotation = true;
            }

            //if (MainManager.Instance.Level_Index >= MainManager.Instance.Unlocked_Level)
            //{
            //    MainManager.Instance.Unlocked_Level++;
            //    Debug.Log("Unlocked Level is Updading");
            //}
        }
        else if (obj.tag != "Checkpoint") //if entered in any other trigger than "Finish" & "Checkpoint", that means player crashed
        {
            if (!Motorcycle_Controller.crash)
            {
                Motorcycle_Controller.crash = true;

                //play sounds
                bonesCrackSC.Play();
                hitSC.Play();
                oohCrowdSC.Play();

                //Activate the Loose Panel
                StartCoroutine(Wait_LoosePanel());
            }
        }
    }

    void Update()
    {
        //if (finish && (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))) //if motorcycle entered in finish and space is pressed
        //{
        //    if (nextLevel)
        //    {
        //        Application.LoadLevel(Application.loadedLevel + 1);	//load next level
        //    }
        //    else
        //        Application.LoadLevel(0); //load first level

        //    Motorcycle_Controller.score = 0;
        //}
    }
}