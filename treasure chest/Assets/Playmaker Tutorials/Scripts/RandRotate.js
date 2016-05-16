var rotAmount : int;

function RandRotCube () {
	rotAmount = Random.Range(-40,40);
	print(rotAmount);
	
	transform.rotation = Quaternion.Euler(0, rotAmount, 0);
}