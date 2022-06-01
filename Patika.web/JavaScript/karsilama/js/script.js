let yourName=prompt("ismini giriniz.")
let welcomeText=document.querySelector("#welcome-text")
welcomeText.innerHTML=`Hosgeldin ${yourName} ! Su anda patika.dev javascript odev 1'desin!`
welcomeText.classList.add("text-warning","text-center")
let datetime=document.querySelector("#date-time")
let currentdate = new Date();
var datetime2 = `Son guncelleme: ${currentdate.getDate()} / ${currentdate.getMonth()+1} / ${currentdate.getFullYear()}  @  
${currentdate.getHours()} : ${currentdate.getMinutes()} :  ${currentdate.getSeconds()}`
datetime.innerHTML=datetime2