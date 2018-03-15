using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBalonPies : State {

	public void conducirBalon(){
		if (flipY) {
			Vector3 posbal = new Vector3 (transform.position.x, transform.position.y - 0.5f);
			balon.setPosicion (posbal);
		}
		if (!flipY){
			Vector3 posbal = new Vector3 (transform.position.x, transform.position.y + 0.5f);
			balon.setPosicion (posbal);
		}
	}


}
