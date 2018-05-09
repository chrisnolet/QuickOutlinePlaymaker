//
//  GetQuickOutlineMode.cs
//  QuickOutline
//
//  Created by Eric Vander Wal on 5/7/18.
//  Copyright © 2018 Eric Vander Wal. All rights reserved.
//

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
  [ActionCategory("Quick Outline")]
  [Tooltip("Get the outline mode for an outline.")]
  public class GetQuickOutlineMode : FsmStateAction
  {
    [CheckForComponent(typeof(Outline))]
    [RequiredField]
    [Tooltip("GameObject with the outline script.")]
    public FsmOwnerDefault gameObject;

    [RequiredField]
    [UIHint(UIHint.Variable)]
    [Tooltip("Type of outline.")]
    [ObjectType(typeof(Outline.Mode))]
    public FsmEnum outlineMode;

    public FsmBool everyFrame;

    private Outline outline;

    public override void Reset()
    {
      outlineMode = null;
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
      outlineMode.Value = outline.OutlineMode;
    }
  }
}
