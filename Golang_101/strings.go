package main

import (
	"fmt"
	"strings"
)

func main() {
	isim := "serif"
	soyisim := "güler"
	buyukIsım := "SERİF"
	fmt.Println(isim, soyisim, buyukIsım)

	fmt.Println(strings.EqualFold(buyukIsım, isim))
	fmt.Println(strings.EqualFold(strings.ToLower(buyukIsım), isim))
}
