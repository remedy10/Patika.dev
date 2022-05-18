package main

import (
	"fmt"
	_ "fmt"
)

func main() {
	slc_1 := []int{1, 2, 3}
	var slc_2 []int
	slc_2 = make([]int, 2)
	slc_2[0] = 1
	slc_2[1] = 2
	//slc_2 = append(slc_2, 1)
	for i, value := range slc_1 {
		fmt.Printf("index=%d,value=%d \n", i, value)
	}
	fmt.Println(slc_2)

	for i := 1; i <= 10; i++ {
		for j := 1; j <= 10; j++ {

			fmt.Printf("| %d x %d = %d ", i, j, i*j)
		}
		fmt.Printf("\n")
	}
}
