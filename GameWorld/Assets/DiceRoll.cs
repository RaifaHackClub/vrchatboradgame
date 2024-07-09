
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DiceRoll : UdonSharpBehaviour
{
    public float rollForce = 10f;
    public Transform[] diceFaces;

    private Rigidbody rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("DiceRoll script started");
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionX;
        //Rotate in random directions until interaction
        RollDice();

    }

    public override void Interact()
    {
        //freeze dice rotation and position at the closest face
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        Vector3 upwardsForce = Vector3.up * 3f;
        rb.AddForce(upwardsForce, ForceMode.Impulse);
    }

    public void Update(){
        if(rb.IsSleeping()){
            CheckDiceResult();
        }
    }

    public void RollDice(){
        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * rollForce;
        rb.AddTorque(randomTorque, ForceMode.Impulse);
    }

    public void CheckDiceResult(){
        Transform upFace = null;
        float maxY = float.MinValue;

        foreach (Transform face in diceFaces)
        {
            if (face.position.y > maxY)
            {
                maxY = face.position.y;
                upFace = face;
            }
        }

        if (upFace != null)
        {
            Debug.Log("Dice landed on face: " + upFace.name);
        }
    }
}
