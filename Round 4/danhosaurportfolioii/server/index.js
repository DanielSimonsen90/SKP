const express = require('express');
const app = express();

const { json } = require('body-parser');
app.use(json());

const cors = require('cors');
app.use(cors());
app.use('/api/projects', require('./routes/api/projects'));

require('dotenv').config();
const port = process.env.PORT || 5000;

app.listen(port, () => console.log(`Server started on port ${port}!`));

module.exports = app;
module.exports.port = port;