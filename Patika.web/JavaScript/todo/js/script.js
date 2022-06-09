function addTODO() {
  let cardTitle = prompt("Card basligini giriniz", "")
  let cardText = prompt("Card text giriniz", "")
  let card = document.createElement('li')
  card.innerHTML = `
    <div class="card text-white bg-secondary mb-3">
      <div class="card-header">${cardTitle} =></div>
      <div class="card-body">
        <p class="card-text">
          ${cardText}
        </p>
      </div>
    </div>`
  document.querySelector("#list-todo").append(card)
}
function cardTasi() {
  
}