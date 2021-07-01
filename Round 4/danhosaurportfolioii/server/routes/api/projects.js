const express = require('express');
const mongo = require('mongodb');
const mongoConnectionString = `mongodb+srv://DanhosaurPortfolioIIApplication:database-admin@danhosaurportfolioii.x1ocs.mongodb.net/DanhosaurPortfolioIIDB?retryWrites=true&w=majority`;
const router = express.Router();

async function getProjects() {
    const client = await mongo.MongoClient.connect(mongoConnectionString, {
        useNewUrlParser: true,
        useUnifiedTopology: true 
    });

    return client.db('DanhosaurPortfolioIIDB').collection('projects');
}

router.post('/', async (req, res) => {
    const projects = await getProjects();
    await projects.insertOne({ ...JSON.parse(req.body.postData) });
    res.status(201).send();
});
router.get('/', async (req, res) => {
    const projects = await getProjects();
    res.send(await projects.find({}).toArray());
});
router.put('/:id', async (req, res) => {
    const projects = await getProjects();
    await projects.updateOne({ _id: new mongo.ObjectID(req.params._id) });
    res.status(200).send();
});
router.delete('/:id', async (req, res) => {
    const projects = await getProjects();
    await projects.deleteOne({ _id: new mongo.ObjectID(req.params._id) })
    res.status(200).send();
});

module.exports = router;