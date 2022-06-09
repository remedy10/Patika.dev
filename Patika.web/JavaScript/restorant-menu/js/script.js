const showroom = document.getElementById('showroom')
var tumUrunler = [
    { isim: "mercimek corbasi", resim: "https://picsum.photos/id/237/150/100", kategori: "corba", aciklama: "duz corba hem de mercimek", fiyat: "26₺" },
    { isim: "kelle paca corbasi", resim: "https://picsum.photos/id/238/150/100", kategori: "corba", aciklama: "kenid suyunda", fiyat: "36₺" },
    { isim: "ezo gelin corbasi", resim: "https://picsum.photos/id/239/150/100", kategori: "corba", aciklama: "duz corba hem de ezo gelin", fiyat: "27₺" },
    { isim: "kazandibi", resim: "https://picsum.photos/id/240/150/100", kategori: "tatli", aciklama: "guzel tatlidir", fiyat: "35₺" },
    { isim: "firin sutlac", resim: "https://picsum.photos/id/241/150/100", kategori: "tatli", aciklama: "guzel tatlidr", fiyat: "35₺" },
    { isim: "baklava", resim: "https://picsum.photos/id/242/150/100", kategori: "tatli", aciklama: "guzel tatlidir", fiyat: "32₺" },
    { isim: "adana", resim: "https://picsum.photos/id/40/150/100", kategori: "kebab", aciklama: "guzel tatlidir", fiyat: "50" },
    { isim: "urfa", resim: "https://picsum.photos/id/41/150/100", kategori: "kebab", aciklama: "guzel tatlidr", fiyat: "45" },
    { isim: "karisik", resim: "https://picsum.photos/id/42/150/100", kategori: "kebab", aciklama: "guzel tatlidir", fiyat: "70" },
    { isim: "kola", resim: "https://picsum.photos/id/31/150/100", kategori: "mesrubat", aciklama: "guzel tatlidir", fiyat: "10" },
    { isim: "fanta", resim: "https://picsum.photos/id/32/150/100", kategori: "mesrubat", aciklama: "guzel tatlidr", fiyat: "10₺" },
    { isim: "ayran", resim: "https://picsum.photos/id/33/150/100", kategori: "mesrubat", aciklama: "guzel tatlidir", fiyat: "10" }
]
const filtrele=(id) =>{
    let result=[];
    console.log(id)
    if (id=="all") {
        result= tumUrunler
        cardOlustur(result)
        return
    }
    result = tumUrunler.filter(item=>item.kategori===id)
    cardOlustur(result)
}
const cardOlustur = (arr) => {
    showroom.innerHTML = ""
    arr.forEach(element => {
        const card = document.createElement('div')
        card.classList.add("card", "m-3")
        card.style.width = "18rem"
        card.innerHTML = `
            <img src="${element.resim}" class="card-img-top p-2">
            <div class="card-body">
                <h5 class="card-title">${element.isim}</h5>
                <p class="card-text">${element.aciklama}(${element.fiyat})</p>
            </div>`
        showroom.append(card)
    });
}