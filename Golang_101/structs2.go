package main

import (
	"encoding/json"
	"fmt"
	"time"
)

type User struct {
	Name    string `json:"name"`
	Surname string `json:"surname"`
	Likes   []Like `json:"likes,omitempty"`
}

type Like struct {
	ID   string
	Date time.Time
}

func main() {
	u := User{
		Name:    "go",
		Surname: "turkiye",
		Likes: []Like{
			{
				ID:   "İsmet",
				Date: time.Now().UTC(),
			},
		},
	}

	arr, _ := json.Marshal(u)
	if arr != nil {
		fmt.Println(string(arr))
	} else {
		fmt.Println("is null")
	}
}
