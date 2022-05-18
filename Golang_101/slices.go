package main

import "fmt"

var arr_1 [3]int                  // dizi yaratma
var arr_2 = [5]int{1, 2, 3, 4, 5} //diziyi yaratıp init. etmek
var slc_1 []int

func main() {

	fmt.Printf("arr_2=%d \n", arr_2)
	//! C dilindeki gibi de yazabiliriz . çıktısı=arr_2=[1 2 3 4 5]
	arr_3 := make([]int, 5)
	arr_3[0] = 1
	for i := 1; i < len(arr_3); i++ {
		arr_3[i] = i * (i + 1)
	}
	fmt.Printf("len(slc_1)=%d cap(sln_1)=%d |", len(slc_1), cap(slc_1))
	//slc_1[0] = 1 //!şeiklinde bir atama yapamıyoruz. appent kullanmak lazım

	fmt.Printf("len(slc_1)=%d cap(sln_1)=%d \n", len(slc_1), cap(slc_1))
	for j := 0; j < 7; j++ {
		slc_1 = append(slc_1, j*(j+1))
	}
	// The new built-in function allocates memory. The first argument is a type,
	// not a value, and the value returned is a pointer to a newly
	// allocated zero value of that type.
	//!arr_3 adında int tipinde 5 elemanlı dizi yaratıyor func içinde olduğmuz için var dememize gerek yok.
	fmt.Printf("arr_3=%d \n", arr_3)
	fmt.Println(slc_1)
	fmt.Printf("len(slc_1)=%d cap(sln_1)=%d |", len(slc_1), cap(slc_1))
	fmt.Printf("len(slc_1)=%d cap(sln_1)=%d \n", len(slc_1), cap(slc_1))
	//* bir de slice vardır slice ise boyutunu vermediğimiz dizilerdi csharptaki arraylist gibi düşünebiliriz
	slc_1 = append(slc_1, 999)
	fmt.Printf("len(slc_1)=%d cap(sln_1)=%d |", len(slc_1), cap(slc_1))
	fmt.Printf("len(slc_1)=%d cap(sln_1)=%d \n", len(slc_1), cap(slc_1))
}
