using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{

    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal_Event raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (!isOpen)
            {
                // Open the chest
                OpenChest();

            } else
            {
                // Chest is already open
                ChestAlreadyOpen();
            }
        }

    }


    public void OpenChest()
    {
        // Dialog window on
        dialogBox.SetActive(true);
        // dialog text = contains text
        dialogText.text = contents.itemDescription;
        // add contents to the inventory
        playerInventory.currentItem = contents;
        playerInventory.currentItem = contents;
        // Raise the signal to the player to animate correctly
        raiseItem.Raise();
        // raise the context clue so it turns off

        context.Raise();
        // set the chest to opened
        isOpen = true;
        anim.SetBool("opened", true);

    }

    public void ChestAlreadyOpen()
    {
        // Dialog off
        dialogBox.SetActive(false);

        // raise the signal to the player to stop animating
        raiseItem.Raise();
    }

    // override
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            context.Raise();
            playerInRange = true;
            Debug.Log("YO! 1");
        }
    }

    // override
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            playerInRange = false;
            context.Raise();
        }
    }
}
