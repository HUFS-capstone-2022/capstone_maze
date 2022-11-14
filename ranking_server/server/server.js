const express = require('express');
const app = express();
const port = 4000;
const cors = require('cors');
const mysql = require('mysql2/promise');
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
    res.send('success')
});


app.get("/ranking", async(req, res) => {
    const { rankType, PlayerId } = req.query;
    // const rankType = "True";
    // const PlayerId = 5;
    // console.log(`select * from maze_ranking.${rankType}_ending where id=${PlayerId}`)
    try {
        const infoRankData = await db.query(`select * from ${rankType}_ending where id=${PlayerId};`);
        console.log(infoRankData[0]);
        res.send(infoRankData[0])
    } catch (err) {
        console.log(err);
    }
})

app.listen(port, () => {
    console.log(`Server run : http://localhost:${port}`)
})

