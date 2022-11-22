const express = require('express');
const router = express.Router();

const db = require('../connectPool');

router.post("/", async(req, res) => {
    // const rankType = "";
    // const rankType = "True";
    // const PlayerId = 5;
    const body = req.body
    const PlayerId = body.userId
    const rankType = body.clearType
    const dbquery = `select * from ${rankType}_ending where id = ${PlayerId} limit 1;`;
    // // db에 보낼 query들
    // const dbquery1 = `INSERT IGNORE INTO Player (Player_id) VALUES (${PlayerId}); `;
    // const dbquery2 = `INSERT INTO ${rankType}_ending (id, name, clear_time, clear_type) VALUES (${PlayerId}, ${PlayerName}, ${PlayerClearTime}, ${PlayerClearType}); `;
    // const dbquery2 = `SELECT * FROM True_ending ORDER BY clear_time DESC LIMIT 8; `;
    // const dbquery3 = `SELECT * FROM Normal_ending ORDER BY clear_time DESC LIMIT 8; `;
    // const dbquery4 = `SELECT * FROM Bad_ending ORDER BY clear_time DESC LIMIT 8; `;
    try {
        // const infoRankData = await db.query(dbquery1 + dbquery2 + dbquery3 + dbquery4)
        // const infoRankData = await db.query(`select * from ${rankType}_ending where id=${PlayerId}; select * from ${rankType}_ending where id=${PlayerId};`);
        // const infoRankData = await db.promise().query(dbquery);
        let [rows, fields] = await db.promise().query(dbquery)
        // let [rows, fields] = await db.promise().query(dbquery1 + dbquery2 + dbquery3 + dbquery4)
        // const data = {"userData" : [infoRankData[0][0]]};
        // const dbJson = JSON.stringify(data);
        // res.send(infoRankData[0])
        // res.json(dbJson)
        // console.log(dbJson)
        const data = {userData : rows[0]}
        // const data1 = {True : rows[1]}
        // const data2 = {Normal : rows[2]}
        // const data3 = {Bad : rows[3]}
        // const data = [data1, data2, data3]
        console.log(data)
        res.json(data)
    } catch (err) {
        console.log(err);
    }
})

module.exports = router;