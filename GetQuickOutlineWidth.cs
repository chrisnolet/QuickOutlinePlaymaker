//
//  GetQuickOutlineWidth.cs
//  QuickOutline
//
//  Created by Eric Vander Wal on 5/7/18.
//  Copyright © 2018 Eric Vander Wal. All rights reserved.
//

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
  [ActionCategory("Quick Outline")]
  [Tooltip("Get the width of an outline.")]
  public class GetQuickOutlineWidth : FsmStateAction
  {
    [CheckForComponent(typeof(Outline))]
    [RequiredField]
    [Tooltip("GameObject with the outline script.")]
    public FsmOwnerDefault gameObject;

    [RequiredField]
    [UIHint(UIHint.Variable)]
    [Tooltip("Width of the outline.")]
    public FsmFloat outlineWidth;

    public FsmBool everyFrame;

    private Outline outline;

    public override void Reset()
    {
      outlineWidth = null;
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
      outlineWidth.Value = outline.OutlineWidth;
    }
  }
}
