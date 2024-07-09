
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DiceRoll : UdonSharpBehaviour
{
    public float rollForce = 5f;
    public Transform[] diceFaces;

    private Rigidbody rb;

    public void start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("DiceRoll script started");

        if (rb == null)
        {
            Debug.LogError("DiceRoll requires a Rigidbody component on the same GameObject");
        }

        if (diceFaces.Length != 6)
        {
            Debug.LogError("DiceRoll requires 6 dice faces to be assigned");
        }

    }

    public override void Interact()
    {
        //unfreeze dice rotation and position
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Debug.Log("DiceRoll script started");
        RollDice();
    }

    public void Update(){
        if (GetComponent<Rigidbody>().IsSleeping())
        {
            transform.position = new Vector3(4f,1.5f,4f);
            transform.
            //freeze dice rotation and position
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            CheckDiceResult();
        }
    }

    public void RollDice(){
        Vector3 randomForce = new Vector3(Random.Range(-1f, 1f), Random.Range(1f, 1.5f), Random.Range(-1f, 1f)) * rollForce;
        Vector3 randomTorque = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * rollForce;


        GetComponent<Rigidbody>().AddForce(randomForce, ForceMode.Impulse);
        GetComponent<Rigidbody>().AddTorque(randomTorque, ForceMode.Impulse);
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
