const express = require('express');
const fs = require('fs');
const app = express();
const port = 4000;
const cors = require('cors');
const mysql = require('mysql2/promise');
const { type } = require('os');
const db = mysql.createPool({
    host : "localhost",
    user : "leejj",
    password : "dydy8325",
    database : "maze_ranking",
    connectionLimit : 5,
    multipleStatements: true
})

app.use(express.urlencoded({ extended: false }));
app.use(express.json());
app.use(cors());

app.get('/', (req, res) => {
    res.send('success')
});


app.get("/ranking", async(req, res) => {
    // const rankType = "";
    // const rankType = "True";
    // const PlayerId = 5;
    const { rankType, PlayerId } = req.query;
    // const { PlayerId, PlayerName, PlayerClearTime, PlayerClearType} = req.query;
    // PlayerClearType === 1 
    // ? (rankType = "True")
    // : PlayerClearType === 2
    //     ? (rankType = "Normal")
    //     : PlayerClearType === 3
    //         ? (rankType = "Bad")
    //         : console.log("bad connection")
    const dbquery = `select * from ${rankType}_ending where id = ${PlayerId} limit 1;`;
    // // db에 보낼 query들
    // const dbquery1 = `INSERT IGNORE INTO Player (Player_id) VALUES (${PlayerId}); `;
    // const dbquery2 = `INSERT INTO ${rankType}_ending (id, name, clear_time, clear_type) VALUES (${PlayerId}, ${PlayerName}, ${PlayerClearTime}, ${PlayerClearType}); `;
    // const dbquery3 = `SELECT * FROM ${rankType}_ending WHERE id = ${PlayerId} ORDER BY clear_time DESC LIMIT 1; `;
    // const dbquery4 = `SELECT * FROM ${rankType}_ending ORDER BY clear_time DESC LIMIT 10; `;
    try {
        // const infoRankData = await db.query(dbquery1 + dbquery2 + dbquery3 + dbquery4)
        // const infoRankData = await db.query(`select * from ${rankType}_ending where id=${PlayerId}; select * from ${rankType}_ending where id=${PlayerId};`);
        const infoRankData = await db.query(dbquery + dbquery);
        const data = [infoRankData[0][0][0], infoRankData[0][1][0]];
        const dbJson = JSON.stringify(data);
        // res.send(infoRankData[0])
        res.json(dbJson)
        console.log(dbJson)
    } catch (err) {
        console.log(err);
    }
})

app.listen(port, () => {
    console.log(`Server run : http://localhost:${port}`)
})

