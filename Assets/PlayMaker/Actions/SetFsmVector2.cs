// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.StateMachine)]
	[Tooltip("Set the value of a Vector2 Variable in another FSM.")]
	public class SetFsmVector2 : FsmStateAction
	{
		[RequiredField]
		public FsmOwnerDefault gameObject;
		[UIHint(UIHint.FsmName)]
		[Tooltip("Optional name of FSM on Game Object")]
		public FsmString fsmName;
		[RequiredField]
		[UIHint(UIHint.FsmVector2)]
		public FsmString variableName;
		[RequiredField]
		public FsmVector2 setValue;
		public bool everyFrame;

		GameObject goLastFrame;
		PlayMakerFSM fsm;
		
		public override void Reset()
		{
			gameObject = null;
			fsmName = "";
			setValue = null;
		}

		public override void OnEnter()
		{
			DoSetFsmVector2();
			
			if (!everyFrame)
				Finish();		
		}

		void DoSetFsmVector2()
		{
			if (setValue == null)
			{
			    return;
			}

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			
            if (go == null)
            {
                return;
            }
			
			if (go != goLastFrame)
			{
				goLastFrame = go;
				
				// only get the fsm component if go has changed
				
				fsm = ActionHelpers.GetGameObjectFsm(go, fsmName.Value);
			}			
			
			if (fsm == null)
			{
			    return;
			}
			
			var fsmVector2 = fsm.FsmVariables.GetFsmVector2(variableName.Value);
			
			if (fsmVector2 == null)
			{
			    return;
			}
			
			fsmVector2.Value = setValue.Value;
		}

		public override void OnUpdate()
		{
			DoSetFsmVector2();
		}

	}
}