const mysql = require('mysql2');

const db = mysql.createPool({
    host : "localhost",
    user : "leejj",
    password : "dydy8325",
    database : "maze_ranking",
    connectionLimit : 10,
    multipleStatements: true
})

module.exports = db;