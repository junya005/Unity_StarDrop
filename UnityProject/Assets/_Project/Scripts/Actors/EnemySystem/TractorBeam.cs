using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    [SerializeField]
    private TractorBeamEffect _tractorBeamEffect;

    [SerializeField]
    private TractorBeamHitAction _tractorBeamHitAction;

    public void PlayTractorBeamEffect()
    {
        _tractorBeamEffect.PlayParticle("TractorBeamParticle");
    }

    public void StopTractorBeamEffect()
    {
        _tractorBeamEffect.StopParticle("TractorBeamParticle");
    }
}
