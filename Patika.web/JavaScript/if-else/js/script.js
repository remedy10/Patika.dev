let not=prompt("notunuzu giriniz")
if (not>=85 && not<=100) {
    document.querySelector("#not").innerHTML="AA"
    document.querySelector("#not").classList.add("bg-success")
}else if(not>=70 && not<=84){
    document.querySelector("#not").innerHTML="BB"
    document.querySelector("#not").classList.add("bg-info")
}else if(not>=40 && not<=69){
    document.querySelector("#not").innerHTML="CC"
    document.querySelector("#not").classList.add("bg-warning")
}else if(not>=0 && not<=39){
    document.querySelector("#not").innerHTML="DD || FF"
    document.querySelector("#not").classList.add("bg-danger")
}

