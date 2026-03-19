// const students = [
//   { name: "Giorgi", grades: [85, 90, 78], active: true },
//   { name: "Nino", grades: [95, 92, 88], active: true },
//   { name: "Luka", grades: [70, 60, 75], active: false },
//   { name: "Ana", grades: [100, 98, 95], active: true }
// ];


// let activeStudents = students.filter((filtered) => {
//  return filtered.active;

// });

// let highGrades = students.filter((students) =>{
//     return students.grades.every((grades) => {
//         return grades > 80;
//     });
//  });

//  let newArray = students.map((students) =>{
//     return {
//         name : students.name,
//         average: students.grades.reduce((acc, curr)=> {
//             return acc + curr;
//         }, 0) / students.grades.length
//     }
//  })


/////////2 

// const products = [
//   { name: "Laptop", price: 1500, category: "tech" },
//   { name: "Phone", price: 800, category: "tech" },
//   { name: "Shoes", price: 120, category: "fashion" },
//   { name: "Watch", price: 300, category: "fashion" }
// ];

// let tech = products.filter((products)=>{
//     return products.category === "tech"
// });


// let sale = products.map((product) =>{
//     return {
//         ...product,
//         price: product.price * 0.9,
//     }
// });

// products.forEach((product) => {
//     console.log(`${product.name} costs ${product.price}$`)
// });


////////////3

// const users = [
//   { username: "admin", age: 25, isLoggedIn: true },
//   { username: "gio", age: 17, isLoggedIn: false },
//   { username: "nino", age: 30, isLoggedIn: true },
//   { username: "luka", age: 15, isLoggedIn: true }
// ];

// let hasMinor = users.some((user) => {
//     return user.age < 18;

// });

// console.log(hasMinor);

// let allAuth = users.every((user) =>{
//     return user.isLoggedIn;
// });

// console.log(allAuth);

// let newArr = users.filter((user) =>{
//    return user.age >= 18 && user.isLoggedIn;
// });