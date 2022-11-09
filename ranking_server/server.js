const express = require('express')
const mysql = require('mysql')
// const dbconfig = require('./config/database.js')
const app = express()
const path = require('path')
app.use(express.json())
var cors = require('cors')
app.use(cors())

// react 페이지 서버로 전송
app.use(express.static(path.join(__dirname, 'ranking_page/build')));
app.get('/', function(req, res) {
    res.sendFile(path.join(__dirname, 'ranking_page/build/index.html'))
})

app.listen(8080, function(){
    console.log('listening on 8080')
})

// react 라우팅 시
app.get('*', function(req, res) {
    res.sendFile(path.join(__dirname, '/ranking_page/build/index.html'))
})