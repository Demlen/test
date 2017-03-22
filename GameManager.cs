//EVENTS MANAGER CLASS - script to camera
//------------------------------------------------
using UnityEngine;
using System.Collections;
[RequireComponent (typeof (NotificationsManager))] //Component for sending and receiving notifications
public class GameManager : MonoBehaviour
{
    //C# property to retrieve currently active instance of object, if any
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameObject("GameManager").AddComponent<GameManager>(); //create game manager object if required
            return instance;
        }
    }
     
    //C# property to retrieve notifications manager
    public static NotificationManager Notifications
    {
        get
        {
            if (notification == null) notifications = instance.GetComponent<NotificationsManager>(); 
            return notifications;
        }
    }

    //Internal reference to single active instance of object - for singleton behaviour
    private static GameManager instance = null;

    //Internal reference to notifications object
    private static NotificationsManager notifications = null;

    void Awake()
    {
        if ((instance) && (instance.GetInstanceID() != GetIstanceID()))
            DestroyImmediate(gameObject); // Delete duplicate
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Set as do not destroy
        }
    }

}
