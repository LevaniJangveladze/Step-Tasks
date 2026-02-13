// 3.1

// let num1 = 7.45,
//     num2 = '13.56';

// num2 = Number(num2);

// num1 = Math.round(num1);
// num2 = Math.round(num2);

// let result = num1 * num2;

// document.write(result);

// 3.2

// let num1 = 20.3;
// let num2 = 27.2;

// let result = num1 + num2;

// result = result.toFixed(2);

// document.write(result);

// 3.3

// let num = 77;

// let result = Math.sqrt(num).toFixed(1); თუ ფიქსდი აბრუნებს სტრინგს//

// console.log(result);

// 3.4

// let num = 3.55;

// let result = Math.pow(num, 3).toFixed(2);

// console.log(result);

// 3.5

// function info(message){
//     alert(message);
// }

// info("Hello World")

// 3.6

// function exponentiation(num1, num2){
//     let result = num1 ** num2;
//     alert(result);
//     return result;
// }

// exponentiation(2, 3);

// 3.7

// function isEven(num){
//     if (num % 2 === 0){
//         return true;
//     } else {
//         return false;
//     }
// }



// console.log(isEven(2))

// 3.8

// function getPart(text, length){
//    return text.slice(0, length);
// }

// let result = getPart("Javascript", 4);
// console.log(result)

// 3.9

// function address(addr){
//     let element = document.getElementById("my-Address");
//     element.innerHTML += " " + addr;
// }

// let userAddress = prompt("Enter your address");
// address(userAddress);

// 3.10

// function roundProduct(num1, num2, place) {
//     let result = num1 * num2;

//     if (place === "ones") {
//         return Math.round(result);
//     }

//     if (place === "tens") {
//         return Math.round(result / 10) * 10;
//     }

//     if (place === "hundreds") {
//         return Math.round(result / 100) * 100;
//     }
// }

// console.log(roundProduct(12.5, 3.4, "ones"));
// console.log(roundProduct(12.5, 3.4, "tens"));
// console.log(roundProduct(12.5, 3.4, "hundreds"));


// 3.11

// function removeHtml (text){
//     return text.replace("HTML", "")
// }

// console.log(removeHtml("HTML is simpler than JS"));

// 3.12

// let squared = (num) => {
//     return num ** 2;
// }

// console.log(squared(7));