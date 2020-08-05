<?php
// File json yang akan dibaca
$file = "anggota.json";

// Mendapatkan file json
$anggota = file_get_contents($file);

// Mendecode anggota.json
$data = json_decode($anggota, true);

// Membaca data array menggunakan foreach
foreach ($data as $key => $d) {
    // Perbarui data kedua
    if ($d['no'] === $_POST['no']) {
        $data[$key]['alamat'] = $_POST['nama'];
		$data[$key]['alamat'] = $_POST['alamat'];
    }
}

// Mengencode data menjadi json
$jsonfile = json_encode($data, JSON_PRETTY_PRINT);

// Menyimpan data ke dalam anggota.json
$anggota = file_put_contents($file, $jsonfile);
