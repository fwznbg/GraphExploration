# People You May Know
### What?
Aplikasi ini merupakan GUI sederhana yang dapat memodelkan beberapa fitur dari People You May Know dalam jejaring sosial media (Social Network). Dengan memanfaatkan algoritma Breadth First Search (BFS) dan Depth First Search (DFS), aplikasi ini dapat menelusuri social network pada akun facebook untuk mendapatkan rekomendasi teman seperti pada fitur People You May Know. Selain untuk mendapatkan rekomendasi teman, aplikasi juga diminta untuk mengembangkan fitur lain agar dua akun yang belum berteman dan tidak memiliki mutual friends sama sekali bisa berkenalan melalui jalur tertentu.
### Requirement
* Visual Studio
* .NET
* MSAGL Package
### How to?
1. Jalankan aplikasi pada folder bin/DarjoWarehouseProject.exe atau buka project pada Visual Studio dan tekan Start
2. Pilih file (.txt) yang berisi jumlah keterhubungan node dengan node lain, dan keterhubungan node dengan node lain, dengan cara menekan choose graph pada bagian bawah layout program. Pastikan format file (.txt) seperti di bawah ini.
```
13
A B
A C
A D
B C
B E
B F
C F
C G
D G
D F
E H
E F
F H
```
4. Pilih account yang akan dicari friend recommendation dan/atau explore friend nya pada bagian kiri atas layout program
5. Pilih algoritma yang dipakai DFS/BFS pada bagian bawah layout sebelah choose graph
6. Akan muncul friend recommendation dari akun tersebut di bagian kanan atas 
7. Untuk mencari explore friends dengan akun lain pertama pilih akun pada explore friends with bagian kanan bawah layout program
8. Akan muncul hasil explore friends pada bagian kanan atas dibawah daftar friend recommendation

### Author
* Arsa Daris Gintara			13519037
* Muhammad Afif Akromi	 	13519110
* Muhammad Fawwaz Naabigh	13519206
