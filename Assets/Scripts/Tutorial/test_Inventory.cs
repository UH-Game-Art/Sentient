using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[5];
    //public GameObject[] guns = new GameObject[3];


    public void AddItem(GameObject item){

        bool itemAdded = false;


        for(int i = 0; i < inventory.Length; i++){
            if(inventory[i] == null){
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
            }
        }
        
        if(!itemAdded){
            Debug.Log("Inventory full");
        }
    }

    public bool FindItem(GameObject item){
        for(int i = 0; i < inventory.Length; i++){
            if(inventory[i] == item){
                return true;
            }

        }
        return false;
    }

    public void DeleteItem(GameObject item){
        for(int i = 0; i < inventory.Length; i++){
            if(inventory[i] == item){
                inventory[i] = null;
            }
        }
    }

    public GameObject FindType(string itemType){
        for(int i = 0; i < inventory.Length; i++){
            if(inventory[i] != null){
                if(inventory[i].GetComponent<InteractionObject>().Type == itemType){
                    return inventory[i];
                }
            }
        }
        return null;
    }

}
