let form = document.querySelector("#user-form")
let txtUsername = document.querySelector("#txt-username")
let txtScore = document.querySelector("#txt-score")
let scoreList = document.querySelector("#score-list")
form.addEventListener("submit", (event) => {
  event.preventDefault()
  //console.log(txtUsername.value + " " + txtScore.value)
  console.log(validateTexts(txtUsername.value, txtScore.value))
})
//preventDefault butona bassak bile sayfa yenilenmez
function createElementLi(username, score) {
  let li = document.createElement('li')
  li.innerHTML = `${txtUsername.value} <span class="badge bg-primary rounded-pill">${txtScore.value}</span>`
  li.classList.add("list-group-item", "d-flex", "justify-content-between", "align-items-center")
  scoreList.append(li)
}

function validateTexts(username, score) {
  if (username && score) {
    createElementLi(username, score)
    return true
  }
  throwException();
  return false
}
const throwException = (color = "warning",
  title = "Holy guacamole!",
  message = "You should check in on some of those fields below.") => {
   let alert= document.createElement('div')
   alert.innerHTML=  `<div class="alert alert-${color} alert-dismissible fade show" role="alert">
     <strong>
       ${title}
     </strong>
     You should check in on some of those fields below.
     <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
   </div>
   `
  scoreList.append(alert)
}
