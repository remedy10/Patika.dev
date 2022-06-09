let display=document.querySelector("#display")
let counterIncrease = document.querySelector("#arttir")
let counterDowncrease=document.querySelector("#azalt")
let i=localStorage.getItem("counter")
/* counterIncrease.addEventListener("click",()=>display.innerHTML=++i)
counterDowncrease.addEventListener("click",()=>display.innerHTML=--i) */

function counter(clickedId){
  console.log(typeof(i))
    display.innerHTML=clickedId ==  "arttir"   ?  ++i   :   --i
    localStorage.setItem("counter",i)
}
