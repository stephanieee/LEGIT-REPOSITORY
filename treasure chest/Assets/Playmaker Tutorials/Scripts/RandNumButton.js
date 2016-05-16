var RandNumFSM : PlayMakerFSM;
RandNumFSM = gameObject.Find("GUIText_RandNum").GetComponent.<PlayMakerFSM>();

function OnGUI ()
{
	if (GUI.Button (Rect (295, 145, 75, 40), "Rand"))
	{
		RandNumFSM.Fsm.Event("set_number");
	}
}