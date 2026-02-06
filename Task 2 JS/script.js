
// 5.1
// let result = Math.sqrt(127);
// let round = Math.round(result);

// console.log(round)

// 5.2

// let random = Math.round(Math.random() * 50) +1;
// console.log(random);

// 5.3

// let result = Math.pow(56.23, 2);
// let integer = Math.trunc(result);

// console.log(integer);

// 5.4

// let bigNum = 98;
// let isBig;

// if (bigNum > 100) {
//     isBig = true;
// } else {
//     isBig = false
// }
// console.log(isBig);

// 5.5

// let num = 100;

// let notBetween;

// if (num <10 || num > 50){
//     notBetween = true;
// } else {
//     notBetween = false;
// }

// console.log(notBetween);

// 5.6

// let gender ='male';

// if (gender === 'female') {
//     console.log('მდედრობითი სქესი');
// } else if (gender === 'male') {
//     console.log('მამრობითი სქესი');
// } else {
//     console.log('გაურკვეველი სქესი')
// }

// 5.7

// let animal = 'სპილო';

// if (animal !== 'სპილო') {
//     console.log('ეს ცხოველი არაა სპილო');
// } else {
//     console.log('ეს ცხოველი სპილოა')
// }


// 5.8

// let num1 = 99;
// let num2 = 19;

// if (num1 > num2){
//     console.log('num1 მეტია num2-ზე');
// } else {
//     console.log('num1 ნაკლებია num2-ზე');
// }



// 5.9

// let month = 12;

// if ((month > 0 && month < 3) || month === 12) {
//     console.log('ზამთარია');
// } else if (month >= 3 && month <= 5) {
//     console.log('გაზაფხულია');
// } else if (month >= 6 && month <= 8) {
//     console.log('ზაფხულია');
// } else if (month >= 9 && month <= 11) {
//     console.log('შემოდგომაა');
// } else {
//     console.log('არასწორი თვე');
// }





// 5.10


// let season = 'autumn';

// switch (season) {
//     case 'winter':
//         console.log('ზამთარია');
//         break;
//     case 'spring':
//         console.log('გაზაფხულია');    
//         break;
//     case 'summer':
//         console.log('ზაფხულია');
//         break;
//     case 'autumn':
//         console.log('შემოდგომაა');
//         break;
//     default:
//         console.log('წლის პერიოდი არაა განსაზღვრული')            
// }

// 5.11
// ჩასწორებული ვარიანტი 

// let clock = 23;
// let dayPeriod;

// if (clock >= 0 && clock < 12) {
//  dayPeriod = 'AM - დღე–ღამის პირველი პერიოდია';
// } else {
//  dayPeriod = 'PM - დღე–ღამის მეორე პერიოდია';
// }
// console.log(dayPeriod);

// 5.12

// let clock = 23;

// let dayPeriod =
//   clock >= 0 && clock < 12
//   ? 'AM - დღე–ღამის პირველი პერიოდია'
//   : 'PM - დღე–ღამის მეორე პერიოდია';

//   console.log(dayPeriod);

// 5.13

// let text = "Text length here"

// if (text.length > 100) {
//     console.log('ტექსტის სიგრძე აჭარბებს დაშვებულ ნორმას');
// } else {
//     console.log('ტექსტის სსიგრძე დაშვებული ნორმის ფარგლებშია');
// }

// 5.14

// let arr = [-7, 55.4, 33, 102];

// if (arr.length > 10) {
//     console.log('ეს მასივი ვერ დამუშავდება, მისი სიგრძე აჭარბებს დაშვებულ ნორმას');
// } else {
//     let sum = 0;

//     for (let i = 0; i < arr.length; i++) {
//     sum += arr[i];
//   }

//   console.log(sum);
// }

// 5.15

// let phone = '+995 551 169 534';

// if (phone.includes = '+995') {
//     console.log ('ეს ქართული ტელეფონის ნომერია');
// } else {
//     console.log ('ეს არ არის ქართული ტელეფონის ნომერი');
// }

// 5.16

// let phone = '551 169 534';
// let myPhoneIndex = phone.substr(0, 3);

// let indexOfBeeline = ['568', '571', '574', '579', '592', '597']


// if (indexOfBeeline.includes (myPhoneIndex)) {
//     alert(`${phone} - ბილაინის ნომერი`);
// } else {
//     alert(`${phone} - გაურკვეველი ოპერატორის ნომერი`);
// }

// 5.17 

// let myPhone = prompt('Enter phone number:');
// let index = myPhone.substr(0, 3);

// let indexOfMagti = ['599', '511', '551','591', '595', '596', '598'];
// let indexOfSilknet = ['577', '593', '555','557', '558', '514', '570'];
// let indexOfBeeline = ['568', '571', '574','579', '592', '597'];

// if (indexOfMagti.includes(index)) {
//   alert('მაგთი');
// } else if (indexOfSilknet.includes(index)) {
//   alert('სილქნეტი');
// } else if (indexOfBeeline.includes(index)) {
//   alert('ბილაინი');
// } else {
//   alert('უცნობი ოპერატორი');
// }

// 5.18

// const delayedNotification = () => {
//   setTimeout(() =>{
//     console.log('თქვენი შეკვეთა შესრულებულია');
//   }, 2000);
// };

// delayedNotification();

// 5.19

// let timerId = setInterval(() => {
//   alert('პროცესი ჯერ არ დასრულებულა');
// }, 1000);

// setTimeout(() => {
//   clearInterval(timerId);
//   alert('პროცესი დასრულებულია');
// }, 10000);

// 5.20


// setInterval(() => {
//   const date = new Date();
//   document.getElementById("demo").innerHTML =
//     date.toLocaleTimeString();
// }, 1000);

