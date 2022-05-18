package main

import (
	"fmt"
	_ "fmt"
	"strings"
)

type x *string

var _s x

func main() {
	var rstr x

	var pstr string

	fmt.Println(rstr) //pointerin cıktısı null olur
	fmt.Println(pstr) //stringler null alamaz ama boş olurlar

	pstr = "go turkiye"
	rstr = &pstr

	fmt.Println(rstr) //0xc000010250 gibi bir çıktı verir bu da gösterdiği yerin adı yani pstr alanını işaret ediyor içindeki değeri görmek için * koyarız
	fmt.Println(pstr) // bu zaten direkt atadığımız değer

	pstr = "go turkiye egitim kampi" //stringimizi değiştirdik

	fmt.Println(*rstr) //gördüğün gibi işaret ettiği değerin direkt değerini * ile gösterdik
	fmt.Println(pstr)  //değerin kendisi direkt

	*rstr = "go turkiye egitim kampi 2021" // burada pointerin işaret ettiği değeri yani pstryi değiştiriyoruz burada * koymadan atama yapamazsın pointere atama yapılmaz
	//* koyarak onun refere ettiği değerin içeriğini değiştiririsin

	fmt.Println(*rstr) //ayni şekilde pstr değeri go turkiye egitim kampi 2021 şeklinde değişti bizde onu temsil eden pointere * koyarak temsil ettiği değer görüyoruz
	fmt.Println(pstr)  //orijinal değer

	replaceStr(pstr)

	fmt.Println(*rstr) //burada değer değişmedi
	fmt.Println(pstr)

	_replaceStr(rstr) //burada pointerin işaret ettiği değer değiştiriyoruz zaten _replaceStr methodu da bir pointer kabul eder

	fmt.Println(*rstr)
	fmt.Println(pstr) //direkt pstr değeri değiştiği için onu büyük olarak görürüz
}

func replaceStr(s string) {
	s = strings.Replace(s, "go", "GO", 1)
	_s = &s
	fmt.Println("replaceStr içindeki değer:" + s)
	fmt.Printf("_s pointer degeri= " + *_s + "adresi:")
	fmt.Println(_s)
	// burada aslında ana metinde pstr'de hiçbir değişiklik olmaz çünkü pstr buraya kopyalanarak gelir yani burada s değerini yazdırmak daha mantıklı olur
	//yazdırdıgım zama içindeki değer byük olacaktır
}

func _replaceStr(s x) {
	*s = strings.Replace(*s, "go", "GO", 1)
	//direkt pointerin işaret ettiğin değeri değiştirir rstr giriyoruz rstr ise pstr dğeeri işaret ediyor dolasıyla pstr değer değişmiş olur.
}
