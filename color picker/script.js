
let red = Math.floor(Math.random() * 256);
let green = Math.floor(Math.random() * 256);
let blue = Math.floor(Math.random() * 256);

let red2 = Math.floor(Math.random() * 256);
let green2 = Math.floor(Math.random() * 256);
let blue2 = Math.floor(Math.random() * 256);

let red3 = Math.floor(Math.random() * 256);
let green3 = Math.floor(Math.random() * 256);
let blue3 = Math.floor(Math.random() * 256);

let red4 = Math.floor(Math.random() * 256);
let green4 = Math.floor(Math.random() * 256);
let blue4 = Math.floor(Math.random() * 256);

let red5 = Math.floor(Math.random() * 256);
let green5 = Math.floor(Math.random() * 256);
let blue5 = Math.floor(Math.random() * 256);

let red6 = Math.floor(Math.random() * 256);
let green6 = Math.floor(Math.random() * 256);
let blue6 = Math.floor(Math.random() * 256);

let isHardMode = false

let colorsArr = 
   [`rgb(${red}, ${green}, ${blue})`, 
    `rgb(${red2}, ${green2}, ${blue2})`, 
    `rgb(${red3}, ${green3}, ${blue3})`,
    `rgb(${red4}, ${green4}, ${blue4})`,
    `rgb(${red5}, ${green5}, ${blue5})`,
    `rgb(${red6}, ${green6}, ${blue6})`,
   ];

let randomRgb = colorsArr[Math.floor(Math.random()*3)];
console.log(colorsArr.indexOf(randomRgb));

let showRgb = document.getElementById("rgbGenerator");

showRgb.innerHTML = randomRgb;

let boxColors = document.querySelectorAll(".color-box");
boxColors[0].style.backgroundColor = colorsArr[0];
boxColors[1].style.backgroundColor = colorsArr[1];
boxColors[2].style.backgroundColor = colorsArr[2];

let boxColors1 = document.querySelectorAll(".color-box1");
boxColors1[0].style.backgroundColor = colorsArr[3];
boxColors1[1].style.backgroundColor = colorsArr[4];
boxColors1[2].style.backgroundColor = colorsArr[5];



let score = document.getElementById("score");
let currentscore = 0;

let userMessage = document.getElementById("message");


function color(clicked){
  
  if (clicked === randomRgb){
    currentscore += 5;
    userMessage.innerHTML = "Good Job"
  } else {
    currentscore -= 10;
     userMessage.innerHTML = "You Failed"
  }

  score.innerHTML = currentscore;
  if (currentscore <= -20){
    userMessage.innerHTML =  "You Lose"
    currentscore = 0;
    score.innerHTML = 0;
  } else if(
    currentscore >= 15 ){
      console.log("hard mode triggered!")
      userMessage.innerHTML = "You got to next level"
      boxColors1[0].style.display="block"
      boxColors1[1].style.display="block"
      boxColors1[2].style.display="block"
      isHardMode = true;
    }
 
  resetGame();
  
}



  function resetGame(){
red = Math.floor(Math.random() * 256);
green = Math.floor(Math.random() * 256);
blue = Math.floor(Math.random() * 256);

 red2 = Math.floor(Math.random() * 256);
 green2 = Math.floor(Math.random() * 256);
 blue2 = Math.floor(Math.random() * 256);

 red3 = Math.floor(Math.random() * 256);
 green3 = Math.floor(Math.random() * 256);
 blue3 = Math.floor(Math.random() * 256);

 red4 = Math.floor(Math.random() * 256);
 green4 = Math.floor(Math.random() * 256);
 blue4 = Math.floor(Math.random() * 256);

 red5 = Math.floor(Math.random() * 256);
 green5 = Math.floor(Math.random() * 256);
 blue5 = Math.floor(Math.random() * 256);

 red6 = Math.floor(Math.random() * 256);
 green6 = Math.floor(Math.random() * 256);
 blue6 = Math.floor(Math.random() * 256);

 colorsArr = 
   [`rgb(${red},  ${green}, ${blue})`, 
    `rgb(${red2}, ${green2}, ${blue2})`, 
    `rgb(${red3}, ${green3}, ${blue3})`,
    `rgb(${red4}, ${green4}, ${blue4})`,
    `rgb(${red5}, ${green5}, ${blue5})`,
    `rgb(${red6}, ${green6}, ${blue6})`, 
  ];

randomRgb = colorsArr[Math.floor(Math.random() * (isHardMode? 6 :3))]
 console.log(colorsArr.indexOf(randomRgb));



showRgb.innerHTML = randomRgb;


boxColors[0].style.backgroundColor = colorsArr[0];
boxColors[1].style.backgroundColor = colorsArr[1];
boxColors[2].style.backgroundColor = colorsArr[2];

boxColors1[0].style.backgroundColor = colorsArr[3];
boxColors1[1].style.backgroundColor = colorsArr[4];
boxColors1[2].style.backgroundColor = colorsArr[5];


}

