const express = require('express');
const mongo = require('mongodb');
const mongoConnectionString = process.env.MONGO_CONNECTION_STRING;
const router = express.Router();

const log = (message) => console.log(`%c${new Date().toLocaleTimeString()} [API]: %c${message}`, "color: lime", "%cwhite");
async function getAdmins() {
    const client = await mongo.MongoClient.connect(mongoConnectionString, {
        useNewUrlParser: true,
        useUnifiedTopology: true,
    });

    return client.db('DanhosaurPortfolioIIDB').collection('admins');
}

router.post('/', async (req, res) => {
    const admins = await getAdmins();
    await admins.insertOne({ ...JSON.parse(req.body.postData) });
    log('Creating admin');
    res.status(201).send();
});

router.get('/', async (req, res) => {
    const admins = await getAdmins();
    log('Sending admins');
    res.send(await admins.find({}).toArray());
});
router.get('/:id', async (req, res) => {
    const admins = await getAdmins();
    const project = await admins.findOne({ _id: parseInt(req.params.id) });
    log('Sending admin');
    res.send(JSON.stringify(project))
})

router.put('/:id', async (req, res) => {
    const admins = await getAdmins();
    await admins.update({ _id: req.body._id }, req.body, { upsert: true });
    log('Updating admin');
    res.status(200).send();
});

router.delete('/:id', async (req, res) => {
    const admins = await getAdmins();
    await admins.deleteOne({ _id: req.params.id });
    log('Deleting admin');
    res.status(200).send();
});

module.exports = router;