using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GlassesPickup : MonoBehaviour
{
    [Tooltip("Frequency at which the item will move up and down")]
    public float verticalBobFrequency = 1f;
    [Tooltip("Distance the item will move up and down")]
    public float bobbingAmount = 1f;
    [Tooltip("Rotation angle per second")]
    public float rotatingSpeed = 360f;
    public GameObject player;

    AudioSource pickUpSFX;
    Vector3 m_StartPosition;
    DepthOfField dof = null;
    PostProcessVolume volume;
    PlayerCharacterController playerController;

    void Start()
    {
        volume = Camera.main.GetComponent<PostProcessVolume>();
        playerController = player.GetComponent<PlayerCharacterController>();
        pickUpSFX = GetComponent<AudioSource>();

        m_StartPosition = transform.position;
    }

    private void Update()
    {
        // Handle bobbing
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;
        transform.position = m_StartPosition + Vector3.up * bobbingAnimationPhase;

        // Handle rotating
        transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime, Space.Self);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !playerController.playerHasGlasses())
        {
            playerController.setPlayerGlassesStatus(true);
            volume.profile.TryGetSettings(out dof);
            pickUpSFX.Play();

            dof.enabled.value = false;

            Destroy(gameObject);
        }
    }
}
