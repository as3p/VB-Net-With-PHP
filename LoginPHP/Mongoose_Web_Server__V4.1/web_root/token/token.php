<?php

if (isset($_POST['token']))
{
    $tkn = $_POST['token'];

	//No Machine : 
	//Password   :
    if($tkn == "GX-01")
        echo "ADMIN";
	
			//No Machine : 
			//Password   :
		    else if($tkn == "GX-02")
        echo "VALID JUGA";
	
			//No Machine : 
			//Password   :
		    else if($tkn == "GX-03")
        echo "VALID";
	
    else
        echo "TOKEN NOT VALID";

}

?>