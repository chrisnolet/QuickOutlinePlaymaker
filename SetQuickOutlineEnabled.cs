//
//  SetQuickOutlineEnabled.cs
//  QuickOutline
//
//  Created by Chris Nolet on 5/8/18.
//  Copyright © 2018 Eric Vander Wal, Chris Nolet. All rights reserved.
//

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
  [ActionCategory("Quick Outline")]
  [Tooltip("Set the enabled state of an outline.")]
  public class SetQuickOutlineEnabled : FsmStateAction
  {
    [CheckForComponent(typeof(Outline))]
    [RequiredField]
    [Tooltip("GameObject with the outline script.")]
    public FsmOwnerDefault gameObject;

    [RequiredField]
    [Tooltip("Enabled state of the outline.")]
    public FsmBool enabled;

    public FsmBool everyFrame;

    private Outline outline;

    public override void Reset()
    {
      enabled = null;
      everyFrame = false;
    }

    public override void OnEnter()
    {
      var go = Fsm.GetOwnerDefaultTarget(gameObject);

      if (go == null)
      {
        return;
      }

      outline = go.GetComponent<Outline>();

      if (outline == null)
      {
        return;
      }

      UpdateProperty();

      if (!everyFrame.Value)
      {
        Finish();
      }
    }

    public override void OnUpdate()
    {
      if (everyFrame.Value)
      {
        UpdateProperty();
      }
    }

    void UpdateProperty()
    {
      outline.enabled = enabled.Value;
    }
  }
}
