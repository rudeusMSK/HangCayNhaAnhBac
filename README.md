<h1>ĐỀ BÀI: </h1>
Nhà anh Bắc có một hàng cây trước nhà gồm có n cây thuộc m loại cây khác nhau (n ≥ m). 
Anh Bắc muốn cắt bỏ (m-2) loại cây sao cho các cây còn lại thuộc 2 loại và chúng phải xem kẽ nhau (2 cây gần nhau không được cùng loại).
Hãy giúp anh Bắc tìm cách tỉa bớt cây thoả mãn yêu cầu trên và số cây còn lại là nhiều nhất.
Yêu cầu Hàng cây ban đầu được biểu diễn bởi 1 string gồm n chữ cái, các chữ cái giống nhau là cùng một loại cây.
Hãy tìm cách tỉa cây và đưa ra số cây nhiều nhất còn lại có thể. input s(string) output Số cây nhiều nhất còn lại có thể (integer).
(Nếu không thể tìm được cách cắt cây để còn lại một hàng cây xem kẽ như yêu cầu, hãy output 0) Giới hạn length(s) ≤ 100 
</br>
#Ví dụ:</br>
Ví dụ 1 </br>
input: s = "aabcdabc" Để còn lại nhiều cây nhất và thoả mãn điều kiện xem kẽ, ta phải loại đi các cây a, và các cây d. Hàng cây còn lại sẽ còn 4 cây là "bcbc". </br>
output: 4 </br>
Ví dụ 2 </br>
input: s = "affabbcfdabc" Để còn lại nhiều cây nhất và thoả mãn điều kiện xem kẽ, ta phải loại đi các cây a,f,b. Hàng cây còn lại sẽ còn 3 cây là "cdc". </br>
output: 3 </br>
Ví dụ 3 </br>
input: s = "affcacbbc" Không có cách cắt cây nào để còn lại hàng cây xem kẽ gồm 2 loại cây. </br>
output: 0 </br>

___

cần cải thiện: </br>
chưa tìm được cách lấy được nhiều cây nhất ! </br>
chưa tối ưu được code ! </br>
code chưa clean code! </br>
giải thuật chưa được tốt ! </br>
chưa đúng  output đề bài yêu cầu ! </br>
___

chạy thử: </br>

![image](https://github.com/rudeusMSK/HangCayNhaAnhBac/assets/160387470/145af2c1-d9fe-4085-b954-b1ba3fa3779f)
