const express = require('express');
const router = express.Router();

const db = require('../connectPool');

router.post("/", async(req, res) => {
    const body = req.body
    const PlayerId = body.userId
    // db에 보낼 query들
    const dbquery1 = `INSERT IGNORE INTO Player (Player_id) VALUES (${PlayerId}); `;
    const dbquery2 = `SELECT * FROM True_ending ORDER BY clear_time LIMIT 8; `;
    const dbquery3 = `SELECT * FROM Normal_ending ORDER BY clear_time LIMIT 8; `;
    const dbquery4 = `SELECT * FROM Bad_ending ORDER BY clear_time LIMIT 8; `;
    try {
        let [rows, fields] = await db.promise().query(dbquery1 + dbquery2 + dbquery3 + dbquery4)
        const data = {True: rows[1], Normal: rows[2], Bad: rows[3]}
        console.log(data)
        res.json(data)
    } catch (err) {
        console.log(err);
    }
})

module.exports = router;