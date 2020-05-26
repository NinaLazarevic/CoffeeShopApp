function changePrice(id, price) {

    var changedPrice = document.getElementById(id);
    var priceDiv = document.getElementById("price");

    var currentPrice = parseFloat(priceDiv.innerHTML);

    if (changedPrice.checked) {
        currentPrice += price;
    }
    else {
        currentPrice -= price;
    }
    priceDiv.innerHTML = currentPrice;
    
}