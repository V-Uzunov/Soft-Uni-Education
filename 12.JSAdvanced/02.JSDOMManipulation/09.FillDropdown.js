function addItem() {
    let text = document.getElementById('newItemText');
    let values = document.getElementById('newItemValue');

    let valueText = document.createElement('option');
    valueText.value = values.value;
    valueText.textContent = text.value;
    
    document.getElementById('menu').appendChild(valueText);

    text.value = '';
    values.value = '';
}