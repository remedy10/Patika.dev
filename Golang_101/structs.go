package main

import (
	"encoding/json"
	"fmt"
)

type Takipci struct {
	Name    string
	Surname string
}

type Userr struct {
	name    string    `json:"name"`
	surname string    `json:"surname"`
	takipci []Takipci `json:"takipci,omitempty"`
}

func main() {
	kullanici := Userr{
		name:    "Kemal",
		surname: "Atakum",
		takipci: []Takipci{
			{
				Name: "ismet", Surname: "inönü",
			},
			{
				Name: "fevzi", Surname: "çakmak",
			},
		},
	}
	userMarshaled, _ := json.Marshal(kullanici)
	if userMarshaled != nil {
		fmt.Println(userMarshaled)
	} else {
		fmt.Println("is null")
	}
	//bune amk

}
