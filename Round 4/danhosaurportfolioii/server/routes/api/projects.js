const express = require('express');
const mongo = require('mongodb');
const mongoConnectionString = `mongodb+srv://DanhosaurPortfolioIIApplication:database-admin@danhosaurportfolioii.x1ocs.mongodb.net/DanhosaurPortfolioIIDB?retryWrites=true&w=majority`;
const router = express.Router();

const log = (message) => console.log(`%c[API]: %c${message}`, "color: lime", "%cwhite");
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
    log('Creating project');
    res.status(201).send();
});

router.get('/', async (req, res) => {
    const projects = await getProjects();
    log('Sending projects');
    res.send(await projects.find({}).toArray());
});
router.get('/:id', async (req, res) => {
    const projects = await getProjects();
    const project = await projects.findOne({ _id: parseInt(req.params.id) });
    log('Sending project');
    res.send(JSON.stringify(project))
})

router.put('/:id', async (req, res) => {
    const projects = await getProjects();
    await projects.updateOne({ _id: req.params.id }, req.body, { upsert: true });
    log('Updating project');
    res.status(200).send();
});

router.delete('/:id', async (req, res) => {
    const projects = await getProjects();
    await projects.deleteOne({ _id: req.params.id });
    log('Deleting project');
    res.status(200).send();
});

module.exports = router;