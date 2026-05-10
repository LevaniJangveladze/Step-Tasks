let arr = [
    ["", "", ""],
    ["", "", ""],
    ["", "", ""],
];

let player = "x";

function printBoard() {
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            console.log(arr[i][j]);
        }
    }
}

function makeMove(row, col) {
    if (arr[row][col] === "") {
        arr[row][col] = player;
    }

    printBoard();
    checkWin();
    checkDraw();
    player = player === "x" ? "o" : "x";
}

function checkWin() {
 
    for (let i = 0; i < 3; i++) {
        if (arr[i][0] === arr[i][1] && arr[i][1] === arr[i][2] && arr[i][0] !== "") {
            console.log(player + " wins!");
        }
    }

  
    for (let i = 0; i < 3; i++) {
        if (arr[0][i] === arr[1][i] && arr[1][i] === arr[2][i] && arr[0][i] !== "") {
            console.log(player + " wins!");
        }
    }

    if (arr[0][0] === arr[1][1] && arr[1][1] === arr[2][2] && arr[0][0] !== "") {
        console.log(player + " wins!");
    }

 
    if (arr[0][2] === arr[1][1] && arr[1][1] === arr[2][0] && arr[0][2] !== "") {
        console.log(player + " wins!");
    }
}

function checkDraw() {
    for (let i = 0; i < 3; i++) {
        for (let j = 0; j < 3; j++) {
            if (arr[i][j] === "") {
                return;
            }
        }
    }
    console.log("It's a draw!");
}


makeMove(0, 0); 
makeMove(1, 0); 
makeMove(0, 1); 
makeMove(1, 1);
makeMove(0, 2); 