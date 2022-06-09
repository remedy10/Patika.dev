const board = document.querySelector('#todo')
const textBox = document.querySelector("#floatingTextarea2")
const liveToast = document.querySelector("#liveToast")
const toastMessage = document.querySelector("#toast-message")
const addCard = document.getElementById('addCard')
const x = document.getElementsByClassName('alert')


const card = (message) => {
  const wrapper = document.createElement('div')
  wrapper.innerHTML =
    `<div class="alert alert-secondary alert-dismissible" role="alert">
            <div><a href="javascript:doneFunc();">${message}</a></div>
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>`
  board.append(wrapper)
}
addCard.addEventListener('click', () => {
  if (textBox.value) {
    card(textBox.value)
    toast("Card ekleme basarili!", "success")
  } else {
    toast("Boş alan birakmayin!", "fail")
  }

})

const toast = (message, style) => {
  toastMessage.innerHTML = message
  const toast = new bootstrap.Toast(liveToast)
  toast.show()
}
const doneFunc=()=>{
  board.classList.add("bg-warning")
}

const addStorage = (message) => {
    if (localStorage.getItem("card")) {
      let item_arr=[]
      let old_item=JSON.parse(localStorage.getItem("card"))
      item_arr=item_arr.push(old_item)
      console.log(item_arr)
    } else if(!localStorage.getItem("card")){
      localStorage.setItem("card", JSON.stringify({ 'id': 0, 'text': message }));  
    }
  //localStorage.setItem("card", JSON.stringify({ 'id': 0, 'text': message }));
}
