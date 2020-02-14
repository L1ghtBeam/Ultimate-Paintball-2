using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerNetwork))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable = null;
    [SerializeField] GameObject[] gameObjectsToDisable = null;

    GameObject sceneCamera;

    private void Start()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            sceneCamera = GameObject.Find("SceneCamera");
            sceneCamera.SetActive(false);
        }
        else
        {
            DisableComponents();
            Util.SetLayerRecursively(gameObject, LayerMask.NameToLayer("RemotePlayer"));
        }
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        PlayerNetwork playerNetwork = GetComponent<PlayerNetwork>();

        GameManager.RegisterPlayer(netID, playerNetwork);
    }

    private void OnDisable()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // This is only to get rid of errors when exiting the game while in the unity editor
            if (sceneCamera != null) { sceneCamera.SetActive(true); }
        }

        GameManager.UnRegisterPlayer(transform.name);
    }

    // Disables components and objects that should not be on a remote player
    void DisableComponents()
    {
        foreach (Behaviour behaviour in componentsToDisable)
        {
            behaviour.enabled = false;
        }

        foreach (GameObject gameObject in gameObjectsToDisable)
        {
            gameObject.SetActive(false);
        }
    }
}
