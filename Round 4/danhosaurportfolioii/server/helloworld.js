const express = require('express');
const router = express.Router();

router.get('/helloworld', (req, res) => res.status(200).send(`<h1>Hello, world!</h1>`));

module.exports = router;