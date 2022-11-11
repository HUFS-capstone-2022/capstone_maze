const express = require('express');
const app = express();
const port = 4000;
const cors = require('cors');
const mysql = require('mysql');
const path = require('path');

const db = mysql.createPool({
    host : "localhost",
    user : "leejj",
    password : "dydy8325",
    database : "maze_ranking"
})

app.use(express.urlencoded({ extended: false }));
app.use(express.json());
app.use(cors());

app.get('/', (req, res) => {
    const sqlQuery = "select * from maze_ranking.True_ending;"
    db.query(sqlQuery, (err, result) => {
        res.send('success')
        res.send(result)
        console.log(err)
    })
})

app.listen(port, () => {
    console.log(`Server run : http://localhost:${port}`)
})

