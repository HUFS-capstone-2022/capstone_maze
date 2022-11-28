const express = require('express');
const router = express.Router();

const db = require('../connectPool');

router.post("/", async(req, res) => {
    const body = req.body
    const PlayerId = body.userId
    const PlayerName = body.userName
    const PlayerClearTime = body.userClearTime.substr(0, 8)
    const rankType = body.userClearType
    // db에 보낼 query들
    const dbquery1 = `INSERT INTO ${rankType}_ending (id, name, clear_time) VALUES (${PlayerId}, '${PlayerName}', '${PlayerClearTime}'); `;
    const dbquery2 = `SELECT * FROM ${rankType}_ending ORDER BY clear_time LIMIT 8; `;
    try {
        let [rows, fields] = await db.promise().query(dbquery1 + dbquery2)
        const data = {end : rows[1]}
        console.log(data)
        res.json(data)
    } catch (err) {
        console.log(err);
    }
})

module.exports = router;