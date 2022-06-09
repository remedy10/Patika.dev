let laptopArray = []
let laptop = {
  brand: "apple",
  model: "macbook pro"
  //key value iliskisi JSON gibi
}
let laptop2 = {
  brand: "lenovo",
  models: "thinkpad"
}
let laptop3 = {
 brand: "asus",
 models: "rog pro"
}
const addLaptop=(value) =>{
  laptopArray.push(value)
  localStorage.setItem("laptops", JSON.stringify(laptopArray))
  // laptopArray = JSON.parse(localStorage.getItem("laptops"))
  // console.log("localStorage eklenen laptops=", laptopArray)
}
console.log("laptoplar localStorage eklenecek!")

if (!localStorage.getItem("laptops")) {
  //localStorage'de veri yoksa array initialize edilir.
  localStorage.setItem("laptops", JSON.stringify(  {
    brand: "kurulum",
    model: "laptop"
  }))
}
laptopArray.push(JSON.parse(localStorage.getItem("laptops")))
addLaptop({brand:"acer", model:"xpad"})
