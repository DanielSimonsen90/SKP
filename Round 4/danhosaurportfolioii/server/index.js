const express = require('express');
const app = express();

const { json } = require('body-parser');
app.use(json({ limit: '50mb' }));

const cors = require('cors');
app.use(cors());
app.use('/helloworld', require('./helloworld'));
app.use('/api/projects', require('./routes/api/projects'));
app.use('/api/projects/:id', require('./routes/api/projects'));
app.use('/api/admins', require('./routes/api/admins'));
// app.use('/postProjects', require('./runProjects'))

require('dotenv').config();
const port = process.env.PORT || 5000;

app.listen(port, () => console.log(`Server started on port ${port}!`));

module.exports = app;
module.exports.port = port;