using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

/// <summary> Implemented from Unity UI: Samples package.
/// Panel manager handles the animation transitions and functionality
/// of the Menu.
/// </summary>
public class PanelManager : MonoBehaviour {
	/// <summary>
	/// Holds the Animator for the panel that is intially open on startup.
	/// </summary>
	public Animator initiallyOpen;

	/// <summary>
	/// Holds the identifier for Open Panels.
	/// </summary>
	private int m_OpenParameterId;
	/// <summary>
	/// The current open panel.
	/// </summary>
	private Animator m_Open;
	/// <summary>
	/// Holds the previous panel that was selected which is used to 
	/// go back and forth between panels.
	/// </summary>
	private GameObject m_PreviouslySelected;

	/// <summary>
	/// The name of the Open transition Paramater in the Animator.
	/// </summary>
	const string k_OpenTransitionName = "Open";
	/// <summary>
	/// The name of the Closed state in the Animator.
	/// </summary>
	const string k_ClosedStateName = "Closed";

	/// <summary> MonoBehavior Class method.
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	public void OnEnable()
	{
		// Set the ID to the first panel open
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);
			
		if (initiallyOpen == null)			
			return;		

		OpenPanel(initiallyOpen);
	}//End OnEnable()

	/// <summary>
	/// Invoked when a new panel needs to be loaded which will also close 
	/// the panel that was last open.
	/// </summary>
	/// <param name="anim">The animations for the new panel.</param>
	public void OpenPanel (Animator anim)
	{
		// If the panel is already open, exit this function
		if (m_Open == anim)
			return;

		// Set the new panel animations on
		anim.gameObject.SetActive(true);
		// Holds the current panel object
		var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

		// Puts the panel to the end of the transform list 
		anim.transform.SetAsLastSibling();

		CloseCurrent();

		// Set the current panel to the be the previous panel
		m_PreviouslySelected = newPreviouslySelected;

		// Set the new panel's animations to be the current one
		m_Open = anim;
		// Transition back to Open State
		m_Open.SetBool(m_OpenParameterId, true);

		GameObject go = FindFirstEnabledSelectable(anim.gameObject);

		SetSelected(go);
	}//End OpenPanel(Animator)

	/// <summary>
	/// Finds the first GameObject that is active and interactable in the
	/// Selectable list.
	/// </summary>
	/// <returns>The first GameObject that was found active and interactable.</returns>
	/// <param name="gameObject">Game object to select.</param>
	static GameObject FindFirstEnabledSelectable (GameObject gameObject)
	{
		GameObject go = null;
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive() && selectable.IsInteractable()) {
				go = selectable.gameObject;
				break;
			}
		}
		return go;
	}//End FindFirstEnabledSelectable(GameObject)

	/// <summary>
	/// Closes the current panel that is open.
	/// </summary>
	public void CloseCurrent()
	{
		if (m_Open == null)
			return;

		m_Open.SetBool(m_OpenParameterId, false);
		SetSelected(m_PreviouslySelected);
		StartCoroutine(DisablePanelDelayed(m_Open));
		m_Open = null;
	}//End CloseCurrent()

	/// <summary>
	/// This waits for the panel to finish its animation before disabling it.
	/// </summary>
	/// <returns>The panel disabled.</returns>
	/// <param name="anim">Animation of the panel that needs to finish closing.</param>
	IEnumerator DisablePanelDelayed(Animator anim)
	{
		bool closedStateReached = false;
		bool wantToClose = true;
		while (!closedStateReached && wantToClose)
		{//Keep running animation until it has completely finished
			if (!anim.IsInTransition(0))
				closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);

			wantToClose = !anim.GetBool(m_OpenParameterId);

			yield return new WaitForEndOfFrame();
		}

		//Once the animation has finished, disable panel
		if (wantToClose)
			anim.gameObject.SetActive(false);
	}//End DisablePanelDelayed(Animator)

	/// <summary>
	/// Highlights the GameObject.
	/// </summary>
	/// <param name="go">The GameObject to be the new Highlighted object.</param>
	private void SetSelected(GameObject go)
	{
		EventSystem.current.SetSelectedGameObject(go);
	}//End SetSelected(GameObject)
}
