using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private GameObject pivotHand;
    private CharacterController characterController;
    [SerializeField] private AnimationCurve swingCurve;
    [SerializeField] private float handPosition = 0;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        pivotHand.SetActive(false);
    }

    private void Start()
    {
        characterController.onAttackMeleeEvent.AddListener((swing) => StartCoroutine(SwingSword(swing)));
    }
    


    public IEnumerator SwingSword(Melee melee)
    {
        pivotHand.SetActive(true);
        handPosition = pivotHand.transform.parent.rotation.eulerAngles.z;
        float currentTime = 0;
        while (currentTime < melee.swingDuration)
        {
            currentTime += Time.deltaTime;
            float step = Mathf.Clamp01(currentTime / melee.swingDuration);
            float angle = Mathf.Lerp(handPosition - melee.endOfSwingAngle
                , handPosition + melee.endOfSwingAngle
                , swingCurve.Evaluate(step));
            pivotHand.transform.rotation = Quaternion.Euler(0,0,angle);
            yield return null;
        }
        pivotHand.SetActive(false);
    }
}
