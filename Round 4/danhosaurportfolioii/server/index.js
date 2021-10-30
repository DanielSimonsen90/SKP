const express = require('express');
const serverless = require('serverless-http');
const app = express();
const router = express.Router();

const { json } = require('body-parser');
app.use(json({ limit: '50mb' }));

const cors = require('cors');
app.use(cors());

router.get('/', (req, res) => {
    res.send('Hello there!');
})

const prefix = '/.netlifly/functions';
app.use(prefix, router)
app.use(`${prefix}/helloworld`, require('./helloworld'));
app.use(`${prefix}/api/projects`, require('./routes/api/projects'));
app.use(`${prefix}/api/projects/:id`, require('./routes/api/projects'));
app.use(`${prefix}/api/admins`, require('./routes/api/admins'));
// app.use(`${prefix}/postProjects`, require('./runProjects'))

require('dotenv').config();
// const port = process.env.PORT || 5000;
// app.listen(port, () => console.log(`Server started on port ${port}!`));

module.exports = app;
module.exports.port = port;
module.exports.handler = serverless(app);