﻿//
//  SetQuickOutlineColor.cs
//  QuickOutline
//
//  Created by Eric Vander Wal on 5/7/18.
//  Copyright © 2018 Eric Vander Wal. All rights reserved.
//

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
  [ActionCategory("Quick Outline")]
  [Tooltip("Set the color of an outline.")]
  public class SetQuickOutlineColor : FsmStateAction
  {
    [CheckForComponent(typeof(Outline))]
    [RequiredField]
    [Tooltip("GameObject with the outline script.")]
    public FsmOwnerDefault gameObject;

    [RequiredField]
    [Tooltip("Color of the outline.")]
    public FsmColor outlineColor;

    public FsmBool everyFrame;

    private Outline outline;

    public override void Reset()
    {
      outlineColor = Color.white;
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
      outline.OutlineColor = outlineColor.Value;
    }
  }
}
