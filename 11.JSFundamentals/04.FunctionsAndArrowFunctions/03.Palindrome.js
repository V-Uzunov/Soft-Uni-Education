function palindrome(word) {
    return word === word.split('').reverse().join('');
}

console.log(palindrome('haha'));
console.log(palindrome('racecar'));
console.log(palindrome('unitinu'));