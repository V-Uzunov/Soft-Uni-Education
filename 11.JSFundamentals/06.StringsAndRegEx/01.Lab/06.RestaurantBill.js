function resturantBill(array) {
    let product = array.filter((a, b) => b % 2 ===0).join(', ');
    let sum = array.filter((a, b) => b % 2 !==0).map(a=> Number(a)).reduce((a, b) => a + b);

    console.log(`You purchased ${product} for a total sum of ${sum}`);
}

resturantBill(['Beer Zagorka', '2.65', 'Tripe soup', '7.80','Lasagna', '5.69']);