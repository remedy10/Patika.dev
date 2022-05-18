package main

import "fmt"

var mymap map[int]string

func main() {
	mymap = make(map[int]string)
	mymap[0] = "mustafa"
	mymap[2] = "kemal"
	mymap[3] = "atatürk"
	fmt.Println(mymap)
	fmt.Printf("len(map)=%d", len(mymap))
}
