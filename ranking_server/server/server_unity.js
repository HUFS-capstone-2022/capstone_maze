const express = require('express');
const app = express();
const cors = require('cors');
const rankingRouter = require('./routes/users');
const bodyParser = require('body-parser');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended:true}))
// app.use(express.json());
// app.use(express.urlencoded({ extended: false }));
app.use(cors());
app.use('/ranking', rankingRouter)

app.get('/', (req, res) => {
    res.send('success')
});

const port = 4000;
app.listen(port, () => {
    console.log(`Server run : http://localhost:${port}`)
})

