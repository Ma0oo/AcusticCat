using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventelation : TransiterPlace, IInteractive
{
    private void Update()
    {
        if (IsUsed)
        {
            Debug.DrawRay(transform.position, -transform.position + Target.transform.position, Color.green);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ActionModule actionModeul))
        {
            actionModeul.TakeActiveItem(this);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ActionModule actionModeul))
        {
            actionModeul.RemoveActiveItem();
        }
    }

    public override void ConcreteOpen()
    {
        if(IsOpen == false)
        {
            Rigidbody rbOfDoor = Door.GetComponent<Rigidbody>();
            rbOfDoor.isKinematic = false;
            rbOfDoor.useGravity = true;
            Door.transform.position = Door.transform.position + Door.transform.right * -0.3f;
            rbOfDoor.AddForce(Vector3.up*4, ForceMode.Impulse);
            Destroy(rbOfDoor.gameObject, 3);

            IsOpen = true;
            GetComponent<BoxCollider>().enabled = false;

            Target?.Open();
        }
    }
    public override void Close()
    {
        
    }

    public string GetNameTrigerAnimator()
    {
        return "TryOpen";
    }
    public void Action()
    {
        Open();
    }

}
