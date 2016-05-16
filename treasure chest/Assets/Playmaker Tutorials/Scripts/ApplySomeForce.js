
function ApplyForce (UserForce : float)
{
	GetComponent.<Rigidbody>().AddForce(0, UserForce, 0);
}